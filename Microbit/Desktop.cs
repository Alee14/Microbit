using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microbit.Main
{
    public partial class Desktop : Form
    {
        public Desktop()
        {
            InitializeComponent();
        }

        private void Desktop_Load(object sender, EventArgs e)
        {

        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
