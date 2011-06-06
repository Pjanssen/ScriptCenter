namespace ScriptCenter.DevCenter.Forms
{
    partial class RepositoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepositoryForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addScriptButton = new System.Windows.Forms.Button();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.repositoryNameTextBox = new System.Windows.Forms.TextBox();
            this.scriptRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scriptsTreeView = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptRepositoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.repositoryNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.scriptsTreeView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 391);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addScriptButton);
            this.flowLayoutPanel1.Controls.Add(this.addCategoryButton);
            this.flowLayoutPanel1.Controls.Add(this.removeButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(382, 30);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(89, 361);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // addScriptButton
            // 
            this.addScriptButton.Location = new System.Drawing.Point(3, 3);
            this.addScriptButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.addScriptButton.Name = "addScriptButton";
            this.addScriptButton.Size = new System.Drawing.Size(83, 23);
            this.addScriptButton.TabIndex = 3;
            this.addScriptButton.Text = "Add Script";
            this.addScriptButton.UseVisualStyleBackColor = true;
            this.addScriptButton.Click += new System.EventHandler(this.addScriptButton_Click);
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Location = new System.Drawing.Point(3, 29);
            this.addCategoryButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(83, 23);
            this.addCategoryButton.TabIndex = 4;
            this.addCategoryButton.Text = "Add Category";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(3, 55);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(83, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Repository Name";
            // 
            // repositoryNameTextBox
            // 
            this.repositoryNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptRepositoryBindingSource, "Name", true));
            this.repositoryNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.repositoryNameTextBox.Location = new System.Drawing.Point(97, 3);
            this.repositoryNameTextBox.Name = "repositoryNameTextBox";
            this.repositoryNameTextBox.Size = new System.Drawing.Size(282, 20);
            this.repositoryNameTextBox.TabIndex = 1;
            // 
            // scriptRepositoryBindingSource
            // 
            this.scriptRepositoryBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptRepository);
            // 
            // scriptsTreeView
            // 
            this.scriptsTreeView.AllowDrop = true;
            this.tableLayoutPanel1.SetColumnSpan(this.scriptsTreeView, 2);
            this.scriptsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptsTreeView.HideSelection = false;
            this.scriptsTreeView.ImageIndex = 0;
            this.scriptsTreeView.ImageList = this.icons;
            this.scriptsTreeView.LabelEdit = true;
            this.scriptsTreeView.Location = new System.Drawing.Point(3, 33);
            this.scriptsTreeView.Name = "scriptsTreeView";
            this.scriptsTreeView.SelectedImageIndex = 0;
            this.scriptsTreeView.Size = new System.Drawing.Size(376, 355);
            this.scriptsTreeView.TabIndex = 2;
            this.scriptsTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.scriptsTreeView_AfterLabelEdit);
            this.scriptsTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.scriptsTreeView_ItemDrag);
            this.scriptsTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.scriptsTreeView_DragDrop);
            this.scriptsTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.scriptsTreeView_DragOver);
            this.scriptsTreeView.DragLeave += new System.EventHandler(this.scriptsTreeView_DragLeave);
            this.scriptsTreeView.DoubleClick += new System.EventHandler(this.scriptsTreeView_DoubleClick);
            this.scriptsTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scriptsTreeView_MouseUp);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "manifest_link");
            this.icons.Images.SetKeyName(1, "manifest_warning");
            this.icons.Images.SetKeyName(2, "repository_category");
            // 
            // RepositoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RepositoryForm";
            this.Size = new System.Drawing.Size(471, 391);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scriptRepositoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addScriptButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox repositoryNameTextBox;
        private System.Windows.Forms.BindingSource scriptRepositoryBindingSource;
        private System.Windows.Forms.TreeView scriptsTreeView;
        private System.Windows.Forms.ImageList icons;
    }
}
