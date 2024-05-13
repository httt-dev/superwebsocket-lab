using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToastMessage
{
    public partial class ToastForm : Form
    {
        int toastX , toastY ;

        public ToastForm(string typpe , string message)
        {
            InitializeComponent();

            labType.Text = typpe;
            labMessage.Text = message;
            switch (typpe)
            {
                case "SUCCESS":
                    toastBorder.BackColor = Color.FromArgb(57, 155, 53);
                    picIcon.Image = Properties.Resources.success;
                    break;

                case "ERROR":
                    toastBorder.BackColor = Color.FromArgb(227, 50, 45);
                    picIcon.Image = Properties.Resources.error;
                    break ;

                case "INFO":
                    toastBorder.BackColor = Color.FromArgb(18, 136, 191);
                    picIcon.Image = Properties.Resources.info;
                    break;

                case "WARNING":
                    toastBorder.BackColor = Color.FromArgb(245, 171, 35);
                    picIcon.Image = Properties.Resources.warning;
                    break;

            }
        }

        private void ToastForm_Load(object sender, EventArgs e)
        {
            Postion();
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastY -= 10;
            this.Location = new Point(toastX, toastY);
            if(toastY <=950)
            {
                toastTimer.Stop();
                toastHide.Start();
            }
        }

        int y = 100;
        private void toastHide_Tick(object sender, EventArgs e)
        {
            y--;
            if(y <= 0)
            {
                toastY += 1;
                this.Location = new Point(toastX , toastY+=10);

                if(toastY > 1000)
                {
                    toastHide.Stop();
                    y = 100;
                    this.Close();
                }
            }

        }

        private void Postion()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = screenWidth - this.Width - 5;
            toastY = screenHeight - this.Height + 70;

            this.Location = new Point(toastX, toastY);
        }
    }
}
