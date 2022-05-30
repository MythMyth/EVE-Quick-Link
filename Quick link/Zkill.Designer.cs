
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
            this.webbrowse = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // zkilllink
            // 
            this.zkilllink.AutoSize = true;
            this.zkilllink.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zkilllink.Location = new System.Drawing.Point(13, 13);
            this.zkilllink.Name = "zkilllink";
            this.zkilllink.Size = new System.Drawing.Size(73, 18);
            this.zkilllink.TabIndex = 0;
            this.zkilllink.TabStop = true;
            this.zkilllink.Text = "linkLabel1";
            this.zkilllink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zkilllink_MouseClick);
            // 
            // webbrowse
            // 
            this.webbrowse.AllowNavigation = false;
            this.webbrowse.AllowWebBrowserDrop = false;
            this.webbrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webbrowse.IsWebBrowserContextMenuEnabled = false;
            this.webbrowse.Location = new System.Drawing.Point(16, 40);
            this.webbrowse.MinimumSize = new System.Drawing.Size(20, 20);
            this.webbrowse.Name = "webbrowse";
            this.webbrowse.ScriptErrorsSuppressed = true;
            this.webbrowse.Size = new System.Drawing.Size(1230, 705);
            this.webbrowse.TabIndex = 3;
            this.webbrowse.WebBrowserShortcutsEnabled = false;
            this.webbrowse.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webbrowse_DocumentCompleted);
            // 
            // Zkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.webbrowse);
            this.Controls.Add(this.zkilllink);
            this.Name = "Zkill";
            this.Text = "Zkill";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Zkill_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel zkilllink;
        private System.Windows.Forms.WebBrowser webbrowse;
    }
}