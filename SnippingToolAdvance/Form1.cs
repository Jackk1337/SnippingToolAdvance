using System;
using System.Drawing;
using System.Windows.Forms;
using HotkeyClass;
using System.IO;
using Tesseract;
using Tesseract.Interop;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Converters;
using Microsoft.Win32;

namespace SnippingToolAdvance
{
    public partial class frmMain : Form
    {
        private bool _capturing;
        private IntPtr _clipboardViewerNext;
        private readonly Hotkey _hotkey = new Hotkey();
        private bool _isSnipping = false;
        public string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string tesseract_string { get; set; }
        public static string api_key { get; set; }

        public frmMain()
        {
            InitializeComponent();
            firstRunCheck();
            SnippingTool.AreaSelected += SnippingToolOnAreaSelected;
            SnippingTool.Cancel += SnippingToolOnCancel;
            WindowState = FormWindowState.Minimized;
            Form frmTessResult = new frmTesseractResult();
            ntyMenuStrip.Items.Insert(0, new ToolStripLabel("Snip Mode"));
            ntyMenuStrip.Items.Insert(1, new ToolStripSeparator());

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RegisterClipboardViewer();
        }



        private void RegisterClipboardViewer()
        {
            _clipboardViewerNext = Win32.User32.SetClipboardViewer(this.Handle);
        }

        private void btnNewSnip_Click(object sender, EventArgs e)
        {
            StartSnipping();
        }

        private void StartSnipping()
        {
            if (!_isSnipping)
            {
                _isSnipping = true;
                SnippingTool.Snip();
            }
        }

        private void SnippingToolOnAreaSelected(object sender, EventArgs e)
        {
            _isSnipping = false;
            if (copyToClipboardStripMenuItem.Checked == true)
            {
                Clipboard.SetImage(SnippingTool.Image);
                if (chkShowImage.Checked)
                {
                    frmViewSnip viewSnip = new frmViewSnip();
                    viewSnip.Visible = true;
                    viewSnip.BringToFront();
                }
            }
            else {
                if (saveToFileToolStripMenuItem.Checked == true)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "png files (*.png)|*.png";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        SnippingTool.Image.Save(sfd.FileName);
                    }
                    if (chkShowImage.Checked) {
                        frmViewSnip viewSnip = new frmViewSnip();
                        viewSnip.Visible = true;
                        viewSnip.BringToFront();
                    }


                }
                else {
                    if (uploadToImgurToolStripMenuItem.Checked == true)
                    {
                        if (File.Exists(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png"))
                        {
                            File.Delete(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png");
                        }
                        SnippingTool.Image.Save(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png");
                        PostToImgur(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png", "cfbda10839094ce6640888558534c0073bb24bd1");
                    }
                    else {
                        if (convertToTextToolStripMenuItem.Checked == true)
                        {
                            if (File.Exists(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png"))
                            {
                                File.Delete(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png");
                            }
                            SnippingTool.Image.Save(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png");
                            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                            {
                                using (var img = Pix.LoadFromFile(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png"))
                                {
                                    using (var page = engine.Process(img))
                                    {
                                        var text = page.GetText();
                                        frmMain.tesseract_string = text;
                                        Form frmTessShow = new frmTesseractResult();
                                        frmTessShow.Show();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SnippingToolOnCancel(object sender, EventArgs e)
        {
            _isSnipping = false;
        }

        private void ShowBaloonMessage(string text, string title)
        {
            ntyIcon.BalloonTipText = text;
            ntyIcon.BalloonTipTitle = title;
            ntyIcon.ShowBalloonTip(1000);
        }

        private void ntyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StartSnipping();
        }

        private void showDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (copyToClipboardStripMenuItem.Checked == true) {
                saveToFileToolStripMenuItem.Checked = false;
                uploadToImgurToolStripMenuItem.Checked = false;
                convertToTextToolStripMenuItem.Checked = false;
                StartSnipping();
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveToFileToolStripMenuItem.Checked == true) {
                copyToClipboardStripMenuItem.Checked = false;
                uploadToImgurToolStripMenuItem.Checked = false;
                convertToTextToolStripMenuItem.Checked = false;
                StartSnipping();
            }
        }

        private void uploadToImgurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uploadToImgurToolStripMenuItem.Checked == true) {
                if (api_key == string.Empty || api_key == null)
                {
                    MessageBox.Show("You must set an Imgur API before using this service!");
                }
                else {
                    copyToClipboardStripMenuItem.Checked = false;
                    saveToFileToolStripMenuItem.Checked = false;
                    convertToTextToolStripMenuItem.Checked = false;
                    StartSnipping();
                }
            }
        }

        private void convertToTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (convertToTextToolStripMenuItem.Checked == true)
            {
                copyToClipboardStripMenuItem.Checked = false;
                saveToFileToolStripMenuItem.Checked = false;
                uploadToImgurToolStripMenuItem.Checked = false;
                StartSnipping();
            }
        }

        public void PostToImgur(string imagFilePath, string apiKey)
        {

            var client = new RestClient("https://api.imgur.com/3/image");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Client-ID " + api_key);
            request.AlwaysMultipartFormData = true;
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            byte[] imageArray = System.IO.File.ReadAllBytes(userPath + "\\Pictures\\SnippingToolAdvanced\\tempSnip.png");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            request.AddParameter("image", base64ImageRepresentation);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<Root>(response.Content);
            if (result.success)
            {
                SetBalloonTip();
                ntyIcon.ShowBalloonTip(2000);
                Clipboard.SetText(result.data.link);
                DeleteHashList.hashes.Add(result.data.deletehash);

                if (chkOpenBrowser.Checked) {
                    System.Diagnostics.Process.Start(result.data.link);
                }
            }
            else {
                MessageBox.Show("Problem uploading image to imgur, error code:" + result.status);
            }
        }

        private void firstRunCheck() {
            if (!(Directory.Exists(userPath + "\\Pictures\\SnippingToolAdvanced"))) {
                Directory.CreateDirectory(userPath + "\\Pictures\\SnippingToolAdvanced");
            }
            if (!File.Exists(userPath + "\\Pictures\\SnippingToolAdvanced\\settings.json"))
            {
                CreateSettingsJson();
            }
            else {
                ReadSettingsJson();
            }
        }

        private void SetBalloonTip()
        {
            ntyIcon.BalloonTipTitle = "Uploaded to Imgur";
            ntyIcon.BalloonTipText = "The image was uploaded to Imgur and the link is on your clipboard";
        }

        private void CreateSettingsJson() {
            Settings settings = new Settings();
            settings.OpenImageAfterSnip = false;
            chkOpenBrowser.Checked = false;
            settings.RunAtSysStartup = false;
            chkAutoStart.Checked = false;
            settings.AutoDelete = 0;
            cmbAutoDeleteOptions.Text = "Never auto delete";
            settings.APIKey = null;
            lblAPIKeyStatusSet.Text = "Not set!";
            lblAPIKeyStatusSet.ForeColor = Color.Red;
            settings.OpenBrowser = false;
            chkOpenBrowser.Checked = false;
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Include;
            using (StreamWriter sw = new StreamWriter(userPath + "\\Pictures\\SnippingToolAdvanced\\settings.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }

        }

        private void ReadSettingsJson() {
            string settingsFile = File.ReadAllText(userPath + "\\Pictures\\SnippingToolAdvanced\\settings.json");
            Settings settings = new Settings();
            settings = JsonConvert.DeserializeObject<Settings>(settingsFile);

            //Set auto delete
            switch (settings.AutoDelete) {
                case 0:
                    cmbAutoDeleteOptions.Text = "Auto delete on exit";
                    break;
                case 1:
                    cmbAutoDeleteOptions.Text = "Auto delete after 5 minutes";
                    tmrAutoDelete.Interval = 10000;
                    tmrAutoDelete.Enabled = true;
                    tmrAutoDelete.Start();
                    break;
                case 2:
                    cmbAutoDeleteOptions.Text = "Auto delete after 10 minutes";
                    tmrAutoDelete.Interval = 10000;
                    tmrAutoDelete.Enabled = true;
                    tmrAutoDelete.Start();
                    break;
                case 3:
                    cmbAutoDeleteOptions.Text = "Never auto delete";
                    break;
            }
            //Set API Key
            if (settings.APIKey != null) {
                lblAPIKeyStatusSet.Text = "API Key Set!";
                lblAPIKeyStatusSet.LinkColor = Color.Green;
                api_key = settings.APIKey;
            }
            else
            {
                lblAPIKeyStatusSet.Text = "Not set!";
                lblAPIKeyStatusSet.LinkColor = Color.Red;
            }
            //Set OpenBrowser
            if (settings.OpenBrowser) {
                chkOpenBrowser.Checked = true;
            }
            //Set OpenImageAfterStartup
            if (settings.OpenImageAfterSnip) {
                chkShowImage.Checked = true;
            }
            //Set RunAtSysStartup
            if (settings.RunAtSysStartup) {
                chkAutoStart.Checked = true;
                if (chkAutoStart.Checked)
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.SetValue("SnippingToolAdvanced", Application.ExecutablePath);
                }
                else
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.DeleteValue("SnippingToolAdvanced");
                }
            }


        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        public void SaveSettingsJson() {
            File.Delete(userPath + "\\Pictures\\SnippingToolAdvanced\\settings.json");
            Settings settings = new Settings();
            if (chkShowImage.Checked) {
                settings.OpenImageAfterSnip = true;
            }
            else {
                settings.OpenImageAfterSnip = false;
            }
            if (chkOpenBrowser.Checked) {
                chkOpenBrowser.Checked = true;
            }
            else {
                chkOpenBrowser.Checked = false;
            }
            if (chkAutoStart.Checked) {
                settings.RunAtSysStartup = true;
            }
            else {
                settings.RunAtSysStartup = false;
            }
            switch (cmbAutoDeleteOptions.Text) {
                case "Auto delete on exit":
                    settings.AutoDelete = 0;
                    break;
                case "Auto delete after 5 minutes":
                    settings.AutoDelete = 1;
                    tmrAutoDelete.Interval = 10000;
                    tmrAutoDelete.Enabled = true;
                    tmrAutoDelete.Start();
                    break;
                case "Auto delete after 10 minutes":
                    settings.AutoDelete = 2;
                    tmrAutoDelete.Interval = 10000;
                    tmrAutoDelete.Enabled = true;
                    tmrAutoDelete.Start();
                    break;
                case "Never auto delete":
                    settings.AutoDelete = 3;
                    break;
            }
            if (chkOpenBrowser.Checked) {
                settings.OpenBrowser = true;
            }
            else {
                settings.OpenBrowser = false;
            }
            settings.APIKey = api_key;
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Include;
            using (StreamWriter sw = new StreamWriter(userPath + "\\Pictures\\SnippingToolAdvanced\\settings.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }
        }

        private void lblAPIKeyStatusSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter Imgur API Key", "Imgur API Key");
            api_key = input;
            lblAPIKeyStatusSet.Text = "API Key Set!";
            lblAPIKeyStatusSet.LinkColor = Color.Green;
            SaveSettingsJson();
        }

        private void cmbAutoDeleteOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.AutoDelete = cmbAutoDeleteOptions.SelectedIndex;
            SaveSettingsJson();
        }

        private void chkOpenBrowser_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsJson();
        }

        private void chkShowImage_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsJson();
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsJson();
            if (chkAutoStart.Checked) {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("SnippingToolAdvanced", Application.ExecutablePath);
            }
            else
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.DeleteValue("SnippingToolAdvanced");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmbAutoDeleteOptions.Text == "Auto delete on exit") {
                DeleteImgurUploads();
            }
        }

        public void DeleteImgurUploads() {
            foreach (string hash in DeleteHashList.hashes) {
                var client = new RestClient("https://api.imgur.com/3/image/" + hash);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Client-ID " + api_key);
                request.AlwaysMultipartFormData = true;
                IRestResponse response = client.Execute(request);
            }
        }

        private void tmrAutoDelete_Tick(object sender, EventArgs e)
        {
            if (DeleteHashList.hashes.Count > 0) {
                DeleteImgurUploads();
            }
        }

        private void lblLaura_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("I love you<3");
        }
    }
}

public class Data
{
    public string id { get; set; }
    public object title { get; set; }
    public object description { get; set; }
    public int datetime { get; set; }
    public string type { get; set; }
    public bool animated { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int size { get; set; }
    public int views { get; set; }
    public int bandwidth { get; set; }
    public object vote { get; set; }
    public bool favorite { get; set; }
    public object nsfw { get; set; }
    public object section { get; set; }
    public object account_url { get; set; }
    public int account_id { get; set; }
    public bool is_ad { get; set; }
    public bool in_most_viral { get; set; }
    public bool has_sound { get; set; }
    public List<object> tags { get; set; }
    public int ad_type { get; set; }
    public string ad_url { get; set; }
    public string edited { get; set; }
    public bool in_gallery { get; set; }
    public string deletehash { get; set; }
    public string name { get; set; }
    public string link { get; set; }
}

public class Root
{
    public Data data { get; set; }
    public bool success { get; set; }
    public int status { get; set; }
}

public class Settings {
    public bool OpenImageAfterSnip { get; set; }
    public bool RunAtSysStartup { get; set; }
    public int AutoDelete { get; set; }
    public bool OpenBrowser { get; set; }
    public string APIKey { get; set; }
}

public class DeleteHashList {
    public static List<string> hashes = new List<string>();
}

