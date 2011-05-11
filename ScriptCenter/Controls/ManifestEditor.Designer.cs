namespace ScriptCenter.Controls
{
    partial class ManifestEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManifestEditor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.scriptDescription = new System.Windows.Forms.TextBox();
            this.scriptInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptName = new System.Windows.Forms.TextBox();
            this.scriptManifestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptId = new ScriptCenter.Controls.TextBoxDefaultText();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.scriptVersionMajor = new System.Windows.Forms.NumericUpDown();
            this.scriptVersionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.scriptVersionMinor = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.scriptVersionRevision = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptManifestBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMajor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMinor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionRevision)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.scriptDescription, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.scriptAuthor, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scriptName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.scriptId, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 286);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Icon";
            // 
            // scriptDescription
            // 
            this.scriptDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptInfoBindingSource, "Description", true));
            this.scriptDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptDescription.Location = new System.Drawing.Point(77, 114);
            this.scriptDescription.Multiline = true;
            this.scriptDescription.Name = "scriptDescription";
            this.scriptDescription.Size = new System.Drawing.Size(249, 103);
            this.scriptDescription.TabIndex = 8;
            // 
            // scriptInfoBindingSource
            // 
            this.scriptInfoBindingSource.DataSource = typeof(ScriptCenter.Xml.ScriptInfo);
            // 
            // scriptAuthor
            // 
            this.scriptAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptInfoBindingSource, "Author", true));
            this.scriptAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptAuthor.Location = new System.Drawing.Point(77, 88);
            this.scriptAuthor.Name = "scriptAuthor";
            this.scriptAuthor.Size = new System.Drawing.Size(249, 20);
            this.scriptAuthor.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Identifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // scriptName
            // 
            this.scriptName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Name", true));
            this.scriptName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptName.Location = new System.Drawing.Point(77, 3);
            this.scriptName.Name = "scriptName";
            this.scriptName.Size = new System.Drawing.Size(249, 20);
            this.scriptName.TabIndex = 1;
            // 
            // scriptManifestBindingSource
            // 
            this.scriptManifestBindingSource.DataSource = typeof(ScriptCenter.Xml.ScriptManifest);
            // 
            // scriptId
            // 
            this.scriptId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Id", true));
            this.scriptId.DefaultText = "com.yourwebsite.scriptname";
            this.scriptId.DefaultTextForeColor = System.Drawing.SystemColors.GrayText;
            this.scriptId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptId.ForeColor = System.Drawing.Color.Black;
            this.scriptId.Location = new System.Drawing.Point(77, 28);
            this.scriptId.Name = "scriptId";
            this.scriptId.Size = new System.Drawing.Size(249, 20);
            this.scriptId.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.scriptVersionMajor);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.scriptVersionMinor);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.scriptVersionRevision);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(74, 51);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(255, 34);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // scriptVersionMajor
            // 
            this.scriptVersionMajor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scriptVersionBindingSource, "Major", true));
            this.scriptVersionMajor.Location = new System.Drawing.Point(3, 3);
            this.scriptVersionMajor.Name = "scriptVersionMajor";
            this.scriptVersionMajor.Size = new System.Drawing.Size(44, 20);
            this.scriptVersionMajor.TabIndex = 10;
            // 
            // scriptVersionBindingSource
            // 
            this.scriptVersionBindingSource.DataSource = typeof(ScriptCenter.Xml.ScriptVersion);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = ".";
            // 
            // scriptVersionMinor
            // 
            this.scriptVersionMinor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scriptVersionBindingSource, "Minor", true));
            this.scriptVersionMinor.Location = new System.Drawing.Point(64, 3);
            this.scriptVersionMinor.Name = "scriptVersionMinor";
            this.scriptVersionMinor.Size = new System.Drawing.Size(44, 20);
            this.scriptVersionMinor.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(111, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = ".";
            // 
            // scriptVersionRevision
            // 
            this.scriptVersionRevision.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scriptVersionBindingSource, "Revision", true));
            this.scriptVersionRevision.Location = new System.Drawing.Point(125, 3);
            this.scriptVersionRevision.Name = "scriptVersionRevision";
            this.scriptVersionRevision.Size = new System.Drawing.Size(44, 20);
            this.scriptVersionRevision.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Author";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(74, 220);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(255, 66);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(41, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ManifestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManifestEditor";
            this.Size = new System.Drawing.Size(329, 286);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptManifestBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMajor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMinor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionRevision)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scriptName;
        private TextBoxDefaultText scriptId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scriptDescription;
        private System.Windows.Forms.TextBox scriptAuthor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown scriptVersionMajor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown scriptVersionMinor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown scriptVersionRevision;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource scriptInfoBindingSource;
        private System.Windows.Forms.BindingSource scriptManifestBindingSource;
        private System.Windows.Forms.BindingSource scriptVersionBindingSource;
    }
}
