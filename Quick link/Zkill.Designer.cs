
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
            this.killlist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // killlist
            // 
            this.killlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.killlist.FullRowSelect = true;
            this.killlist.GridLines = true;
            this.killlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.killlist.HideSelection = false;
            this.killlist.Location = new System.Drawing.Point(16, 97);
            this.killlist.Name = "killlist";
            this.killlist.Size = new System.Drawing.Size(557, 379);
            this.killlist.TabIndex = 2;
            this.killlist.UseCompatibleStateImageBehavior = false;
            this.killlist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ship";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "System";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Victim";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Final blow";
            // 
            // Zkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 486);
            this.Controls.Add(this.killlist);
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
        private System.Windows.Forms.ListView killlist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}