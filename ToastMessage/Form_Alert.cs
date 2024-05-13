using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToastMessage.Properties;

namespace ToastMessage
{
    public partial class Form_Alert : Form
    {
        public Form_Alert()
        {
            InitializeComponent();
        }

        public enum enumAction
        {
            wait,
            start,
            close

        }
        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private Form_Alert.enumAction action ;
        private int x,y ;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enumAction.close ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(this.action)
            {
                case enumAction.wait :
                    timer1.Interval = 5000;
                    action = enumAction.close;
                    break;

                case enumAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if(this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if(this.Opacity == 1.0)
                        {
                            action= enumAction.wait ;
                        }
                    }
                    break;

                case enumAction.close :
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if(base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for(int i = 0; i < 10; i++)
            {
                fname = "alert " + i.ToString();
                Form_Alert frm = (Form_Alert)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - (this.Height * (i + 1)) - (5 * (i+1));
                    this.Location = new Point(this.x,this.y);
                    break;
                }

            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.labMessage.Text = msg;

            this.Show();
            this.action = enumAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
