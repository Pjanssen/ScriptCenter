﻿namespace ScriptCenter.DevCenter.Forms
{
    partial class InstallerActionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerActionsForm));
            this.actionsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.actionsComboBox = new System.Windows.Forms.ComboBox();
            this.addActionButton = new System.Windows.Forms.Button();
            this.moveActionUpButton = new System.Windows.Forms.Button();
            this.moveActionDownButton = new System.Windows.Forms.Button();
            this.removeActionButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.actionPropertyGrid = new ScriptCenter.Controls.CustomPropertyGrid();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionsListView
            // 
            this.actionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.actionsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsListView.FullRowSelect = true;
            this.actionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.actionsListView.HideSelection = false;
            this.actionsListView.Location = new System.Drawing.Point(3, 29);
            this.actionsListView.MultiSelect = false;
            this.actionsListView.Name = "actionsListView";
            this.actionsListView.ShowItemToolTips = true;
            this.actionsListView.Size = new System.Drawing.Size(411, 160);
            this.actionsListView.SmallImageList = this.icons;
            this.actionsListView.TabIndex = 0;
            this.actionsListView.UseCompatibleStateImageBehavior = false;
            this.actionsListView.View = System.Windows.Forms.View.Details;
            this.actionsListView.SelectedIndexChanged += new System.EventHandler(this.actionsListView_SelectedIndexChanged);
            this.actionsListView.SizeChanged += new System.EventHandler(this.actionsListView_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Action";
            this.columnHeader1.Width = 152;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Details";
            this.columnHeader2.Width = 225;
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "action");
            this.icons.Images.SetKeyName(1, "copy_dir");
            this.icons.Images.SetKeyName(2, "copy_file");
            this.icons.Images.SetKeyName(3, "hotkey");
            this.icons.Images.SetKeyName(4, "toolbar");
            this.icons.Images.SetKeyName(5, "toolbar_button");
            this.icons.Images.SetKeyName(6, "toolbar_separator");
            // 
            // actionsComboBox
            // 
            this.actionsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionsComboBox.FormattingEnabled = true;
            this.actionsComboBox.Location = new System.Drawing.Point(3, 3);
            this.actionsComboBox.Name = "actionsComboBox";
            this.actionsComboBox.Size = new System.Drawing.Size(411, 21);
            this.actionsComboBox.Sorted = true;
            this.actionsComboBox.TabIndex = 1;
            // 
            // addActionButton
            // 
            this.addActionButton.Location = new System.Drawing.Point(420, 2);
            this.addActionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.addActionButton.Name = "addActionButton";
            this.addActionButton.Size = new System.Drawing.Size(74, 23);
            this.addActionButton.TabIndex = 2;
            this.addActionButton.Text = "Add";
            this.addActionButton.UseVisualStyleBackColor = true;
            this.addActionButton.Click += new System.EventHandler(this.addActionButton_Click);
            // 
            // moveActionUpButton
            // 
            this.moveActionUpButton.Location = new System.Drawing.Point(3, 29);
            this.moveActionUpButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.moveActionUpButton.Name = "moveActionUpButton";
            this.moveActionUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveActionUpButton.TabIndex = 3;
            this.moveActionUpButton.Text = "Move Up";
            this.moveActionUpButton.UseVisualStyleBackColor = true;
            this.moveActionUpButton.Click += new System.EventHandler(this.moveActionUpButton_Click);
            // 
            // moveActionDownButton
            // 
            this.moveActionDownButton.Location = new System.Drawing.Point(3, 55);
            this.moveActionDownButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.moveActionDownButton.Name = "moveActionDownButton";
            this.moveActionDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveActionDownButton.TabIndex = 4;
            this.moveActionDownButton.Text = "Move Down";
            this.moveActionDownButton.UseVisualStyleBackColor = true;
            this.moveActionDownButton.Click += new System.EventHandler(this.moveActionDownButton_Click);
            // 
            // removeActionButton
            // 
            this.removeActionButton.Location = new System.Drawing.Point(3, 3);
            this.removeActionButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.removeActionButton.Name = "removeActionButton";
            this.removeActionButton.Size = new System.Drawing.Size(75, 23);
            this.removeActionButton.TabIndex = 5;
            this.removeActionButton.Text = "Remove";
            this.removeActionButton.UseVisualStyleBackColor = true;
            this.removeActionButton.Click += new System.EventHandler(this.removeActionButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.Controls.Add(this.actionsComboBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.actionsListView, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.addActionButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.actionPropertyGrid, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(497, 396);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.removeActionButton);
            this.flowLayoutPanel1.Controls.Add(this.moveActionUpButton);
            this.flowLayoutPanel1.Controls.Add(this.moveActionDownButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(417, 26);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(80, 166);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // actionPropertyGrid
            // 
            this.actionPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionPropertyGrid.Location = new System.Drawing.Point(3, 195);
            this.actionPropertyGrid.Name = "actionPropertyGrid";
            this.actionPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.actionPropertyGrid.Size = new System.Drawing.Size(411, 198);
            this.actionPropertyGrid.TabIndex = 5;
            this.actionPropertyGrid.ToolbarVisible = false;
            // 
            // InstallerActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InstallerActionsForm";
            this.Size = new System.Drawing.Size(497, 396);
            this.tableLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView actionsListView;
        private System.Windows.Forms.ComboBox actionsComboBox;
        private System.Windows.Forms.Button addActionButton;
        private System.Windows.Forms.Button moveActionUpButton;
        private System.Windows.Forms.Button moveActionDownButton;
        private System.Windows.Forms.Button removeActionButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ScriptCenter.Controls.CustomPropertyGrid actionPropertyGrid;
        private System.Windows.Forms.ImageList icons;
    }
}
