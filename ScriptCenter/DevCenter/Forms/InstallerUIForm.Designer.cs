namespace ScriptCenter.DevCenter.Forms
{
    partial class InstallerUIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerUIForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.icon64 = new System.Windows.Forms.TextBox();
            this.icon16 = new System.Windows.Forms.TextBox();
            this.icon64Label = new System.Windows.Forms.Label();
            this.icon16Label = new System.Windows.Forms.Label();
            this.browseIcon64 = new System.Windows.Forms.Button();
            this.icon64PictureBox = new System.Windows.Forms.PictureBox();
            this.browseIcon16 = new System.Windows.Forms.Button();
            this.icon16PictureBox = new System.Windows.Forms.PictureBox();
            this.selectIconDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon64PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon16PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel.Controls.Add(this.icon64, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.icon16, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.icon64Label, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.icon16Label, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.browseIcon64, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.icon64PictureBox, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.browseIcon16, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.icon16PictureBox, 3, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(555, 369);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // icon64
            // 
            this.icon64.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.icon64.Location = new System.Drawing.Point(74, 62);
            this.icon64.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.icon64.Name = "icon64";
            this.icon64.Size = new System.Drawing.Size(322, 20);
            this.icon64.TabIndex = 30;
            // 
            // icon16
            // 
            this.icon16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.icon16.Location = new System.Drawing.Point(74, 10);
            this.icon16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.icon16.Name = "icon16";
            this.icon16.Size = new System.Drawing.Size(322, 20);
            this.icon16.TabIndex = 29;
            // 
            // icon64Label
            // 
            this.icon64Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.icon64Label.AutoSize = true;
            this.icon64Label.Location = new System.Drawing.Point(3, 67);
            this.icon64Label.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.icon64Label.Name = "icon64Label";
            this.icon64Label.Size = new System.Drawing.Size(60, 13);
            this.icon64Label.TabIndex = 27;
            this.icon64Label.Text = "Icon 64x64";
            // 
            // icon16Label
            // 
            this.icon16Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.icon16Label.AutoSize = true;
            this.icon16Label.Location = new System.Drawing.Point(3, 15);
            this.icon16Label.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.icon16Label.Name = "icon16Label";
            this.icon16Label.Size = new System.Drawing.Size(60, 13);
            this.icon16Label.TabIndex = 22;
            this.icon16Label.Text = "Icon 16x16";
            // 
            // browseIcon64
            // 
            this.browseIcon64.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.browseIcon64.Location = new System.Drawing.Point(405, 60);
            this.browseIcon64.Name = "browseIcon64";
            this.browseIcon64.Size = new System.Drawing.Size(67, 23);
            this.browseIcon64.TabIndex = 10;
            this.browseIcon64.Text = "Browse";
            this.browseIcon64.UseVisualStyleBackColor = true;
            this.browseIcon64.Click += new System.EventHandler(this.browseIcon64_Click);
            // 
            // icon64PictureBox
            // 
            this.icon64PictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.icon64PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("icon64PictureBox.Image")));
            this.icon64PictureBox.Location = new System.Drawing.Point(485, 40);
            this.icon64PictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.icon64PictureBox.Name = "icon64PictureBox";
            this.icon64PictureBox.Size = new System.Drawing.Size(64, 64);
            this.icon64PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icon64PictureBox.TabIndex = 21;
            this.icon64PictureBox.TabStop = false;
            // 
            // browseIcon16
            // 
            this.browseIcon16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.browseIcon16.Location = new System.Drawing.Point(405, 8);
            this.browseIcon16.Name = "browseIcon16";
            this.browseIcon16.Size = new System.Drawing.Size(67, 23);
            this.browseIcon16.TabIndex = 6;
            this.browseIcon16.Text = "Browse";
            this.browseIcon16.UseVisualStyleBackColor = true;
            this.browseIcon16.Click += new System.EventHandler(this.browseIcon16_Click);
            // 
            // icon16PictureBox
            // 
            this.icon16PictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.icon16PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("icon16PictureBox.Image")));
            this.icon16PictureBox.Location = new System.Drawing.Point(508, 11);
            this.icon16PictureBox.Name = "icon16PictureBox";
            this.icon16PictureBox.Size = new System.Drawing.Size(17, 17);
            this.icon16PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icon16PictureBox.TabIndex = 3;
            this.icon16PictureBox.TabStop = false;
            // 
            // selectIconDialog
            // 
            this.selectIconDialog.Filter = "Image Files (*.gif, *.jpg, *.png)|*.gif;*.jpg;*.png";
            // 
            // InstallerUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "InstallerUIForm";
            this.Size = new System.Drawing.Size(555, 369);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon64PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon16PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.OpenFileDialog selectIconDialog;
        private System.Windows.Forms.PictureBox icon64PictureBox;
        private System.Windows.Forms.Label icon64Label;
        private System.Windows.Forms.Button browseIcon16;
        private System.Windows.Forms.Label icon16Label;
        private System.Windows.Forms.PictureBox icon16PictureBox;
        private System.Windows.Forms.Button browseIcon64;
        private System.Windows.Forms.TextBox icon64;
        private System.Windows.Forms.TextBox icon16;

    }
}
