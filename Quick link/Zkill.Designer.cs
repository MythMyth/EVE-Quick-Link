
namespace Quick_link
{
    partial class Zkill
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
            this.zkilllink = new System.Windows.Forms.LinkLabel();
            this.dangerousBar = new System.Windows.Forms.ProgressBar();
            this.gangComp = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zkilllink
            // 
            this.zkilllink.AutoSize = true;
            this.zkilllink.Location = new System.Drawing.Point(13, 13);
            this.zkilllink.Name = "zkilllink";
            this.zkilllink.Size = new System.Drawing.Size(55, 13);
            this.zkilllink.TabIndex = 0;
            this.zkilllink.TabStop = true;
            this.zkilllink.Text = "linkLabel1";
            this.zkilllink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zkilllink_MouseClick);
            // 
            // dangerousBar
            // 
            this.dangerousBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.dangerousBar.ForeColor = System.Drawing.Color.Red;
            this.dangerousBar.Location = new System.Drawing.Point(16, 54);
            this.dangerousBar.Name = "dangerousBar";
            this.dangerousBar.Size = new System.Drawing.Size(223, 23);
            this.dangerousBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.dangerousBar.TabIndex = 1;
            this.dangerousBar.Value = 20;
            // 
            // gangComp
            // 
            this.gangComp.Location = new System.Drawing.Point(331, 54);
            this.gangComp.Name = "gangComp";
            this.gangComp.Size = new System.Drawing.Size(223, 23);
            this.gangComp.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 102);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(638, 293);
            this.textBox1.TabIndex = 2;
            // 
            // Zkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 679);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gangComp);
            this.Controls.Add(this.dangerousBar);
            this.Controls.Add(this.zkilllink);
            this.Name = "Zkill";
            this.Text = "Zkill";
            this.Shown += new System.EventHandler(this.Zkill_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel zkilllink;
        private System.Windows.Forms.ProgressBar dangerousBar;
        private System.Windows.Forms.ProgressBar gangComp;
        private System.Windows.Forms.TextBox textBox1;
    }
}