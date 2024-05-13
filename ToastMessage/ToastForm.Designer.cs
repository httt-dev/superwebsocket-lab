namespace ToastMessage
{
    partial class ToastForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toastBorder = new System.Windows.Forms.Panel();
            this.labType = new System.Windows.Forms.Label();
            this.labMessage = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.toastHide = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // toastBorder
            // 
            this.toastBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(155)))), ((int)(((byte)(53)))));
            this.toastBorder.Location = new System.Drawing.Point(-43, -10);
            this.toastBorder.Name = "toastBorder";
            this.toastBorder.Size = new System.Drawing.Size(49, 80);
            this.toastBorder.TabIndex = 0;
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labType.Location = new System.Drawing.Point(64, 6);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(47, 20);
            this.labType.TabIndex = 2;
            this.labType.Text = "Type";
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMessage.Location = new System.Drawing.Point(64, 30);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(118, 20);
            this.labMessage.TabIndex = 3;
            this.labMessage.Text = "Toast Message";
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Image = global::ToastMessage.Properties.Resources.success;
            this.picIcon.Location = new System.Drawing.Point(12, 6);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(46, 46);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // toastTimer
            // 
            this.toastTimer.Enabled = true;
            this.toastTimer.Interval = 10;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // toastHide
            // 
            this.toastHide.Interval = 10;
            this.toastHide.Tick += new System.EventHandler(this.toastHide_Tick);
            // 
            // ToastForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(298, 59);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.labType);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.toastBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastForm";
            this.Text = "ToastForm";
            this.Load += new System.EventHandler(this.ToastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toastBorder;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label labType;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Timer toastHide;
    }
}