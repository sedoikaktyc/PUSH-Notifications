namespace PUSH_Notifications
{
    partial class CactusPush
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
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.cactusGradienPanels1 = new PUSH_Notifications.CactusGradienPanels();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.cactusGradienPanels1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // cactusGradienPanels1
            // 
            this.cactusGradienPanels1.BackColor = System.Drawing.Color.Transparent;
            this.cactusGradienPanels1.ColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(152)))), ((int)(((byte)(157)))));
            this.cactusGradienPanels1.ColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(236)))), ((int)(((byte)(160)))));
            this.cactusGradienPanels1.Controls.Add(this.MessageLabel);
            this.cactusGradienPanels1.Controls.Add(this.IconBox);
            this.cactusGradienPanels1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cactusGradienPanels1.Location = new System.Drawing.Point(0, 0);
            this.cactusGradienPanels1.Name = "cactusGradienPanels1";
            this.cactusGradienPanels1.Size = new System.Drawing.Size(350, 90);
            this.cactusGradienPanels1.TabIndex = 2;
            this.cactusGradienPanels1.Click += new System.EventHandler(this.cactusGradienPanels1_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MessageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MessageLabel.Location = new System.Drawing.Point(105, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Padding = new System.Windows.Forms.Padding(5);
            this.MessageLabel.Size = new System.Drawing.Size(245, 90);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MessageLabel.Click += new System.EventHandler(this.MessageLabel_Click);
            // 
            // IconBox
            // 
            this.IconBox.BackColor = System.Drawing.Color.Transparent;
            this.IconBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconBox.Location = new System.Drawing.Point(0, 0);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(105, 90);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.IconBox_Click);
            // 
            // CactusPush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 90);
            this.Controls.Add(this.cactusGradienPanels1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CactusPush";
            this.Text = "CactusPush";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CactusPush_FormClosing);
            this.cactusGradienPanels1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private CactusGradienPanels cactusGradienPanels1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Timer Timer;
    }
}