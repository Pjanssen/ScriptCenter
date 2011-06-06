namespace ScriptCenter.DevCenter.Forms
{
    partial class PackageRootPathWarning
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageBeforeTextLabel1 = new ScriptCenter.Controls.ImageBeforeTextLabel();
            this.SuspendLayout();
            // 
            // imageBeforeTextLabel1
            // 
            this.imageBeforeTextLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBeforeTextLabel1.AutoSize = true;
            this.imageBeforeTextLabel1.Image = global::ScriptCenter.SCResources.error;
            this.imageBeforeTextLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imageBeforeTextLabel1.Location = new System.Drawing.Point(119, 158);
            this.imageBeforeTextLabel1.Name = "imageBeforeTextLabel1";
            this.imageBeforeTextLabel1.Size = new System.Drawing.Size(152, 13);
            this.imageBeforeTextLabel1.TabIndex = 0;
            this.imageBeforeTextLabel1.Text = "Root path must be set first.";
            this.imageBeforeTextLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageRootPathWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageBeforeTextLabel1);
            this.Name = "PackageRootPathWarning";
            this.Size = new System.Drawing.Size(391, 328);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ImageBeforeTextLabel imageBeforeTextLabel1;
    }
}
