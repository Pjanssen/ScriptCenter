namespace ScriptCenter.Controls
{
    partial class SupportedMaxVersionsEditorUI
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
            this.minVersionSpinner = new System.Windows.Forms.NumericUpDown();
            this.minVersionCheckBox = new System.Windows.Forms.CheckBox();
            this.maxVersionCheckBox = new System.Windows.Forms.CheckBox();
            this.maxVersionSpinner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.minVersionSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVersionSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // minVersionSpinner
            // 
            this.minVersionSpinner.Enabled = false;
            this.minVersionSpinner.Location = new System.Drawing.Point(113, 3);
            this.minVersionSpinner.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.minVersionSpinner.Minimum = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.minVersionSpinner.Name = "minVersionSpinner";
            this.minVersionSpinner.Size = new System.Drawing.Size(49, 20);
            this.minVersionSpinner.TabIndex = 7;
            this.minVersionSpinner.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.minVersionSpinner.ValueChanged += new System.EventHandler(this.minVersionSpinner_ValueChanged);
            // 
            // minVersionCheckBox
            // 
            this.minVersionCheckBox.AutoSize = true;
            this.minVersionCheckBox.Location = new System.Drawing.Point(3, 6);
            this.minVersionCheckBox.Name = "minVersionCheckBox";
            this.minVersionCheckBox.Size = new System.Drawing.Size(105, 17);
            this.minVersionCheckBox.TabIndex = 8;
            this.minVersionCheckBox.Text = "Minimum Version";
            this.minVersionCheckBox.UseVisualStyleBackColor = true;
            this.minVersionCheckBox.CheckedChanged += new System.EventHandler(this.minVersionCheckBox_CheckedChanged);
            // 
            // maxVersionCheckBox
            // 
            this.maxVersionCheckBox.AutoSize = true;
            this.maxVersionCheckBox.Location = new System.Drawing.Point(3, 29);
            this.maxVersionCheckBox.Name = "maxVersionCheckBox";
            this.maxVersionCheckBox.Size = new System.Drawing.Size(108, 17);
            this.maxVersionCheckBox.TabIndex = 10;
            this.maxVersionCheckBox.Text = "Maximum Version";
            this.maxVersionCheckBox.UseVisualStyleBackColor = true;
            this.maxVersionCheckBox.CheckedChanged += new System.EventHandler(this.maxVersionCheckBox_CheckedChanged);
            // 
            // maxVersionSpinner
            // 
            this.maxVersionSpinner.Enabled = false;
            this.maxVersionSpinner.Location = new System.Drawing.Point(113, 27);
            this.maxVersionSpinner.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.maxVersionSpinner.Minimum = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.maxVersionSpinner.Name = "maxVersionSpinner";
            this.maxVersionSpinner.Size = new System.Drawing.Size(49, 20);
            this.maxVersionSpinner.TabIndex = 9;
            this.maxVersionSpinner.Value = new decimal(new int[] {
            2008,
            0,
            0,
            0});
            this.maxVersionSpinner.ValueChanged += new System.EventHandler(this.maxVersionSpinner_ValueChanged);
            // 
            // SupportedMaxVersionsEditorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maxVersionCheckBox);
            this.Controls.Add(this.maxVersionSpinner);
            this.Controls.Add(this.minVersionCheckBox);
            this.Controls.Add(this.minVersionSpinner);
            this.Name = "SupportedMaxVersionsEditorUI";
            this.Size = new System.Drawing.Size(171, 55);
            ((System.ComponentModel.ISupportInitialize)(this.minVersionSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVersionSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown minVersionSpinner;
        private System.Windows.Forms.CheckBox minVersionCheckBox;
        private System.Windows.Forms.CheckBox maxVersionCheckBox;
        private System.Windows.Forms.NumericUpDown maxVersionSpinner;


    }
}
