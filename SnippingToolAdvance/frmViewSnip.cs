using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippingToolAdvance
{
    public partial class frmViewSnip : Form
    {
        public frmViewSnip()
        {
            InitializeComponent();
        }

        private void frmViewSnip_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SnippingTool.Image;
        }
    }
}
