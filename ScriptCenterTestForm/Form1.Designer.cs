namespace ScriptCenterTestForm
{
    partial class Form1
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
            this.browsePage1 = new ScriptCenter.Controls.BrowsePage();
            this.SuspendLayout();
            // 
            // browsePage1
            // 
            this.browsePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browsePage1.Location = new System.Drawing.Point(0, 0);
            this.browsePage1.Name = "browsePage1";
            this.browsePage1.Padding = new System.Windows.Forms.Padding(3);
            this.browsePage1.Size = new System.Drawing.Size(439, 369);
            this.browsePage1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 369);
            this.Controls.Add(this.browsePage1);
            this.Name = "Form1";
            this.Text = "Script Center";
            this.ResumeLayout(false);

        }

        #endregion

        private ScriptCenter.Controls.BrowsePage browsePage1;
    }
}

