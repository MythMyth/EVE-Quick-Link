
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
            // Zkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 679);
            this.Controls.Add(this.zkilllink);
            this.Name = "Zkill";
            this.Text = "Zkill";
            this.Shown += new System.EventHandler(this.Zkill_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel zkilllink;
    }
}