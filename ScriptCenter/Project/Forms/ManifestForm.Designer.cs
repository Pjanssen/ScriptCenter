using ScriptCenter.Controls;
namespace ScriptCenter.Project.Forms
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.addVersionButton = new System.Windows.Forms.Button();
            this.removeVersionButton = new System.Windows.Forms.Button();
            this.versionPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.versionsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptAuthor = new System.Windows.Forms.TextBox();
            this.scriptManifestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scriptId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptManifestBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.versionPropertyGrid, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.versionsListView, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.scriptAuthor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scriptName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 373);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addVersionButton);
            this.flowLayoutPanel2.Controls.Add(this.removeVersionButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(390, 96);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(81, 122);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // addVersionButton
            // 
            this.addVersionButton.Location = new System.Drawing.Point(3, 3);
            this.addVersionButton.Name = "addVersionButton";
            this.addVersionButton.Size = new System.Drawing.Size(75, 23);
            this.addVersionButton.TabIndex = 5;
            this.addVersionButton.Text = "Add";
            this.addVersionButton.UseVisualStyleBackColor = true;
            this.addVersionButton.Click += new System.EventHandler(this.addVersionButton_Click);
            // 
            // removeVersionButton
            // 
            this.removeVersionButton.Location = new System.Drawing.Point(3, 32);
            this.removeVersionButton.Name = "removeVersionButton";
            this.removeVersionButton.Size = new System.Drawing.Size(75, 23);
            this.removeVersionButton.TabIndex = 3;
            this.removeVersionButton.Text = "Remove";
            this.removeVersionButton.UseVisualStyleBackColor = true;
            this.removeVersionButton.Click += new System.EventHandler(this.removeVersionButton_Click);
            // 
            // versionPropertyGrid
            // 
            this.versionPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionPropertyGrid.HelpVisible = false;
            this.versionPropertyGrid.Location = new System.Drawing.Point(78, 221);
            this.versionPropertyGrid.Name = "versionPropertyGrid";
            this.versionPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.versionPropertyGrid.Size = new System.Drawing.Size(309, 149);
            this.versionPropertyGrid.TabIndex = 23;
            this.versionPropertyGrid.ToolbarVisible = false;
            // 
            // versionsListView
            // 
            this.versionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.versionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionsListView.FullRowSelect = true;
            this.versionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.versionsListView.HideSelection = false;
            this.versionsListView.Location = new System.Drawing.Point(78, 99);
            this.versionsListView.MultiSelect = false;
            this.versionsListView.Name = "versionsListView";
            this.versionsListView.ShowItemToolTips = true;
            this.versionsListView.Size = new System.Drawing.Size(309, 116);
            this.versionsListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.versionsListView.TabIndex = 22;
            this.versionsListView.UseCompatibleStateImageBehavior = false;
            this.versionsListView.View = System.Windows.Forms.View.Details;
            this.versionsListView.SelectedIndexChanged += new System.EventHandler(this.versionsListView_SelectedIndexChanged);
            this.versionsListView.Resize += new System.EventHandler(this.versionsListView_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Version";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Script Path";
            this.columnHeader2.Width = 180;
            // 
            // scriptAuthor
            // 
            this.scriptAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Author", true));
            this.scriptAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptAuthor.Location = new System.Drawing.Point(78, 28);
            this.scriptAuthor.Name = "scriptAuthor";
            this.scriptAuthor.Size = new System.Drawing.Size(309, 20);
            this.scriptAuthor.TabIndex = 2;
            this.scriptAuthor.Validated += new System.EventHandler(this.scriptAuthor_Validated);
            // 
            // scriptManifestBindingSource
            // 
            this.scriptManifestBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptManifest);
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
            this.scriptName.Location = new System.Drawing.Point(78, 3);
            this.scriptName.Name = "scriptName";
            this.scriptName.Size = new System.Drawing.Size(309, 20);
            this.scriptName.TabIndex = 1;
            this.scriptName.Validated += new System.EventHandler(this.scriptName_Validated);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.scriptId);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(78, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 39);
            this.panel1.TabIndex = 3;
            this.panel1.TabStop = true;
            // 
            // scriptId
            // 
            this.scriptId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptManifestBindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.scriptId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptId.Location = new System.Drawing.Point(0, 0);
            this.scriptId.Name = "scriptId";
            this.scriptId.Size = new System.Drawing.Size(309, 20);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Versions";
            // 
            // ManifestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManifestForm";
            this.Size = new System.Drawing.Size(471, 373);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scriptManifestBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scriptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource scriptManifestBindingSource;
        private System.Windows.Forms.TextBox scriptAuthor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox scriptId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView versionsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PropertyGrid versionPropertyGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button addVersionButton;
        private System.Windows.Forms.Button removeVersionButton;
    }
}
