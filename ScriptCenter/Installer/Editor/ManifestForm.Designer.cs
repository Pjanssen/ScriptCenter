using ScriptCenter.Controls;
namespace ScriptCenter.Installer.Editor
{
    partial class ManifestForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.scriptDescription = new System.Windows.Forms.TextBox();
            this.scriptManifestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptName = new System.Windows.Forms.TextBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.scriptId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.scriptRequirementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptManifestBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMajor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMinor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionRevision)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptRequirementsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.scriptDescription, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.scriptAuthor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scriptName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 336);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "3dsmax versions";
            // 
            // scriptDescription
            // 
            this.scriptDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Description", true));
            this.scriptDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptDescription.Location = new System.Drawing.Point(94, 173);
            this.scriptDescription.Multiline = true;
            this.scriptDescription.Name = "scriptDescription";
            this.scriptDescription.Size = new System.Drawing.Size(237, 89);
            this.scriptDescription.TabIndex = 10;
            // 
            // scriptManifestBindingSource
            // 
            this.scriptManifestBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptManifest);
            // 
            // scriptAuthor
            // 
            this.scriptAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Author", true));
            this.scriptAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptAuthor.Location = new System.Drawing.Point(94, 28);
            this.scriptAuthor.Name = "scriptAuthor";
            this.scriptAuthor.Size = new System.Drawing.Size(237, 20);
            this.scriptAuthor.TabIndex = 2;
            this.scriptAuthor.Validated += new System.EventHandler(this.scriptAuthor_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Identifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Script Name";
            // 
            // scriptName
            // 
            this.scriptName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Name", true));
            this.scriptName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptName.Location = new System.Drawing.Point(94, 3);
            this.scriptName.Name = "scriptName";
            this.scriptName.Size = new System.Drawing.Size(237, 20);
            this.scriptName.TabIndex = 1;
            this.scriptName.Validated += new System.EventHandler(this.scriptName_Validated);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.scriptVersionMajor);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.scriptVersionMinor);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.scriptVersionRevision);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(91, 102);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.TabStop = true;
            // 
            // scriptVersionMajor
            // 
            this.scriptVersionMajor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scriptVersionBindingSource, "Major", true));
            this.scriptVersionMajor.Location = new System.Drawing.Point(3, 3);
            this.scriptVersionMajor.Name = "scriptVersionMajor";
            this.scriptVersionMajor.Size = new System.Drawing.Size(55, 20);
            this.scriptVersionMajor.TabIndex = 4;
            // 
            // scriptVersionBindingSource
            // 
            this.scriptVersionBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptVersion);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = ".";
            // 
            // scriptVersionMinor
            // 
            this.scriptVersionMinor.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scriptVersionBindingSource, "Minor", true));
            this.scriptVersionMinor.Location = new System.Drawing.Point(75, 3);
            this.scriptVersionMinor.Name = "scriptVersionMinor";
            this.scriptVersionMinor.Size = new System.Drawing.Size(55, 20);
            this.scriptVersionMinor.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(133, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = ".";
            // 
            // scriptVersionRevision
            // 
            this.scriptVersionRevision.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.scriptVersionBindingSource, "Revision", true));
            this.scriptVersionRevision.Location = new System.Drawing.Point(147, 3);
            this.scriptVersionRevision.Name = "scriptVersionRevision";
            this.scriptVersionRevision.Size = new System.Drawing.Size(55, 20);
            this.scriptVersionRevision.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Author";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Description";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scriptId);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(94, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 45);
            this.panel1.TabIndex = 3;
            this.panel1.TabStop = true;
            // 
            // scriptId
            // 
            this.scriptId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.scriptId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptId.Location = new System.Drawing.Point(0, 0);
            this.scriptId.Name = "scriptId";
            this.scriptId.Size = new System.Drawing.Size(237, 20);
            this.scriptId.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(-3, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Recommended: author.scriptname";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.comboBox1);
            this.flowLayoutPanel3.Controls.Add(this.label11);
            this.flowLayoutPanel3.Controls.Add(this.comboBox2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(91, 131);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(243, 39);
            this.flowLayoutPanel3.TabIndex = 5;
            this.flowLayoutPanel3.TabStop = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.scriptRequirementsBindingSource, "Minimal3dsmaxVersion", true));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(55, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBox1_Format);
            // 
            // scriptRequirementsBindingSource
            // 
            this.scriptRequirementsBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptRequirements);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(61, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "-";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.scriptRequirementsBindingSource, "Maximum3dsmaxVersion", true));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(75, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(55, 21);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBox1_Format);
            // 
            // ManifestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManifestForm";
            this.Size = new System.Drawing.Size(334, 336);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptManifestBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMajor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionMinor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptVersionRevision)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptRequirementsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scriptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scriptDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown scriptVersionMajor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown scriptVersionMinor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown scriptVersionRevision;
        private System.Windows.Forms.BindingSource scriptManifestBindingSource;
        private System.Windows.Forms.BindingSource scriptVersionBindingSource;
        private System.Windows.Forms.TextBox scriptAuthor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox scriptId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource scriptRequirementsBindingSource;
    }
}
