
namespace Quick_link
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.startUpCheckbox = new System.Windows.Forms.CheckBox();
            this.autoMinimizeCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copy Dscan then hit Ctrl + Shift + D to get dscan link";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // startUpCheckbox
            // 
            this.startUpCheckbox.AutoSize = true;
            this.startUpCheckbox.Location = new System.Drawing.Point(13, 13);
            this.startUpCheckbox.Name = "startUpCheckbox";
            this.startUpCheckbox.Size = new System.Drawing.Size(99, 17);
            this.startUpCheckbox.TabIndex = 2;
            this.startUpCheckbox.Text = "Run on start up";
            this.startUpCheckbox.UseVisualStyleBackColor = true;
            this.startUpCheckbox.CheckedChanged += new System.EventHandler(this.startUpCheckbox_CheckedChanged);
            // 
            // autoMinimizeCheckbox
            // 
            this.autoMinimizeCheckbox.AutoSize = true;
            this.autoMinimizeCheckbox.Location = new System.Drawing.Point(176, 13);
            this.autoMinimizeCheckbox.Name = "autoMinimizeCheckbox";
            this.autoMinimizeCheckbox.Size = new System.Drawing.Size(143, 17);
            this.autoMinimizeCheckbox.TabIndex = 3;
            this.autoMinimizeCheckbox.Text = "Auto minimize on start up";
            this.autoMinimizeCheckbox.UseVisualStyleBackColor = true;
            this.autoMinimizeCheckbox.CheckedChanged += new System.EventHandler(this.autoMinimizeCheckbox_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 94);
            this.Controls.Add(this.autoMinimizeCheckbox);
            this.Controls.Add(this.startUpCheckbox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox startUpCheckbox;
        private System.Windows.Forms.CheckBox autoMinimizeCheckbox;
    }
}

