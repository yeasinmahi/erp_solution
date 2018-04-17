using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AkijFTPConnector
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        public void Init(string maxSize, string text)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = int.Parse(maxSize);
            label1.Text = text;
            //Update();
     
        }

        public void MoveProgress(int nstep, string txt)
        {
            progressBar1.Value = nstep;
            label1.Text = txt;
            Update();
        }

    }
}
