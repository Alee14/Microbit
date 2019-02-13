/***********************************************************************
 * 
 *   Microbits
 *   Copyright (C) 2019 Alee14
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *   
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>.
 *
 ****************************************************************************/
using System;
using Microbit.Main;
using System.IO;
using Microbit.Kernel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microbit
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
#if DEBUG
            btnDebug.Visible = true;
            btnDebug.Enabled = true;
#endif
            if (Directory.Exists(MicroFS.MicrobitFolder))
            {
                btnReset.Enabled = true;
            }
            else
            {
                btnReset.Enabled = false;
                MicroFS.CreateSystemFiles();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Are you sure that you want to reset this OS?\nTHIS ACTION WILL DESTROY YOUR FILES AND RESTORE TO THE DEFAULT SETTINGS.", "Are you sure?", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (string file in Directory.GetFiles(MicroFS.MicrobitFolder))
                {
                    File.Delete(file);
                }

                foreach (string directory in Directory.GetDirectories(MicroFS.MicrobitFolder))
                {
                    Directory.Delete(directory);
                }

                Directory.Delete(MicroFS.MicrobitFolder);
            }
            btnReset.Enabled = false;
            MessageBox.Show("OS has been restored to the default settings and all files are deleted.");
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Debug debug = new Debug();
            debug.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
