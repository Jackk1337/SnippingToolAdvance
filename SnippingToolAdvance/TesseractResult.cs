using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnippingToolAdvance;
using System.IO;

namespace SnippingToolAdvance
{
    public partial class frmTesseractResult : Form
    {
        public frmTesseractResult()
        {
            InitializeComponent();
        }

        private void frmTesseractResult_Load(object sender, EventArgs e)
        {
            txtResult.Text = frmMain.tesseract_string;
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtResult.Text);
            }
        }

        private void btnCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
        }
    }
}
