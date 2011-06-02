namespace ScriptCenter.Project.Forms
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptRefsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addScriptRefButton = new System.Windows.Forms.Button();
            this.removeScriptRefButton = new System.Windows.Forms.Button();
            this.moveScriptRefUpButton = new System.Windows.Forms.Button();
            this.moveScriptRefDownButton = new System.Windows.Forms.Button();
            this.scriptRefPropertyGrid = new ScriptCenter.Controls.CustomPropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.scriptRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptRepositoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.scriptRefsListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.scriptRefPropertyGrid, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 391);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // scriptRefsListView
            // 
            this.scriptRefsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.tableLayoutPanel1.SetColumnSpan(this.scriptRefsListView, 2);
            this.scriptRefsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptRefsListView.FullRowSelect = true;
            this.scriptRefsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scriptRefsListView.HideSelection = false;
            this.scriptRefsListView.Location = new System.Drawing.Point(3, 32);
            this.scriptRefsListView.MultiSelect = false;
            this.scriptRefsListView.Name = "scriptRefsListView";
            this.scriptRefsListView.ShowItemToolTips = true;
            this.scriptRefsListView.Size = new System.Drawing.Size(383, 233);
            this.scriptRefsListView.TabIndex = 0;
            this.scriptRefsListView.UseCompatibleStateImageBehavior = false;
            this.scriptRefsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Script Identifier";
            this.columnHeader1.Width = 152;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Script Manifest Path";
            this.columnHeader2.Width = 225;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addScriptRefButton);
            this.flowLayoutPanel1.Controls.Add(this.removeScriptRefButton);
            this.flowLayoutPanel1.Controls.Add(this.moveScriptRefUpButton);
            this.flowLayoutPanel1.Controls.Add(this.moveScriptRefDownButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(389, 29);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(82, 239);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // addScriptRefButton
            // 
            this.addScriptRefButton.Location = new System.Drawing.Point(3, 3);
            this.addScriptRefButton.Name = "addScriptRefButton";
            this.addScriptRefButton.Size = new System.Drawing.Size(74, 23);
            this.addScriptRefButton.TabIndex = 2;
            this.addScriptRefButton.Text = "Add";
            this.addScriptRefButton.UseVisualStyleBackColor = true;
            // 
            // removeScriptRefButton
            // 
            this.removeScriptRefButton.Location = new System.Drawing.Point(3, 32);
            this.removeScriptRefButton.Name = "removeScriptRefButton";
            this.removeScriptRefButton.Size = new System.Drawing.Size(75, 23);
            this.removeScriptRefButton.TabIndex = 5;
            this.removeScriptRefButton.Text = "Remove";
            this.removeScriptRefButton.UseVisualStyleBackColor = true;
            // 
            // moveScriptRefUpButton
            // 
            this.moveScriptRefUpButton.Location = new System.Drawing.Point(3, 61);
            this.moveScriptRefUpButton.Name = "moveScriptRefUpButton";
            this.moveScriptRefUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveScriptRefUpButton.TabIndex = 3;
            this.moveScriptRefUpButton.Text = "Move Up";
            this.moveScriptRefUpButton.UseVisualStyleBackColor = true;
            // 
            // moveScriptRefDownButton
            // 
            this.moveScriptRefDownButton.Location = new System.Drawing.Point(3, 90);
            this.moveScriptRefDownButton.Name = "moveScriptRefDownButton";
            this.moveScriptRefDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveScriptRefDownButton.TabIndex = 4;
            this.moveScriptRefDownButton.Text = "Move Down";
            this.moveScriptRefDownButton.UseVisualStyleBackColor = true;
            // 
            // scriptRefPropertyGrid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.scriptRefPropertyGrid, 2);
            this.scriptRefPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptRefPropertyGrid.Location = new System.Drawing.Point(3, 271);
            this.scriptRefPropertyGrid.Name = "scriptRefPropertyGrid";
            this.scriptRefPropertyGrid.PropertyNameColumnWidth = 130;
            this.scriptRefPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.scriptRefPropertyGrid.Size = new System.Drawing.Size(383, 117);
            this.scriptRefPropertyGrid.TabIndex = 5;
            this.scriptRefPropertyGrid.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.scriptRepositoryBindingSource, "Name", true));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(44, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 20);
            this.textBox1.TabIndex = 7;
            // 
            // scriptRepositoryBindingSource
            // 
            this.scriptRepositoryBindingSource.DataSource = typeof(ScriptCenter.Repository.ScriptRepository);
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
        private System.Windows.Forms.ListView scriptRefsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addScriptRefButton;
        private System.Windows.Forms.Button removeScriptRefButton;
        private System.Windows.Forms.Button moveScriptRefUpButton;
        private System.Windows.Forms.Button moveScriptRefDownButton;
        private ScriptCenter.Controls.CustomPropertyGrid scriptRefPropertyGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource scriptRepositoryBindingSource;
    }
}
