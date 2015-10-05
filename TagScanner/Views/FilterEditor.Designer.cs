namespace TagScanner.Views
{
	partial class FilterEditor
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
			this.TreeView = new System.Windows.Forms.TreeView();
			this.PropertyBox = new System.Windows.Forms.ComboBox();
			this.OperatorBox = new System.Windows.Forms.ComboBox();
			this.ValueBox = new System.Windows.Forms.Panel();
			this.QuantifierBox = new System.Windows.Forms.ComboBox();
			this.btnMoveDown = new System.Windows.Forms.Button();
			this.btnMoveUp = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnAddRootFilter = new System.Windows.Forms.Button();
			this.btnAddRootGroup = new System.Windows.Forms.Button();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnClear = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.popupAddChildFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.popupAddChildGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.popupDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.popupInsertSiblingGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.popupInsertSiblingFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.PopupMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// TreeView
			// 
			this.TreeView.AllowDrop = true;
			this.TreeView.ContextMenuStrip = this.PopupMenu;
			this.TreeView.HideSelection = false;
			this.TreeView.Location = new System.Drawing.Point(23, 36);
			this.TreeView.Name = "TreeView";
			this.TreeView.Size = new System.Drawing.Size(442, 310);
			this.TreeView.TabIndex = 0;
			// 
			// PropertyBox
			// 
			this.PropertyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PropertyBox.FormattingEnabled = true;
			this.PropertyBox.Location = new System.Drawing.Point(23, 9);
			this.PropertyBox.Name = "PropertyBox";
			this.PropertyBox.Size = new System.Drawing.Size(160, 21);
			this.PropertyBox.TabIndex = 1;
			// 
			// OperatorBox
			// 
			this.OperatorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OperatorBox.FormattingEnabled = true;
			this.OperatorBox.Items.AddRange(new object[] {
            "containing",
            "starting with",
            "ending with",
            "not containing",
            "not starting with",
            "not ending with",
            "=",
            "<>",
            "<",
            ">",
            "<=",
            ">="});
			this.OperatorBox.Location = new System.Drawing.Point(189, 9);
			this.OperatorBox.Name = "OperatorBox";
			this.OperatorBox.Size = new System.Drawing.Size(116, 21);
			this.OperatorBox.TabIndex = 2;
			// 
			// ValueBox
			// 
			this.ValueBox.BackColor = System.Drawing.SystemColors.Window;
			this.ValueBox.Location = new System.Drawing.Point(311, 9);
			this.ValueBox.Name = "ValueBox";
			this.ValueBox.Size = new System.Drawing.Size(154, 21);
			this.ValueBox.TabIndex = 3;
			// 
			// QuantifierBox
			// 
			this.QuantifierBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.QuantifierBox.FormattingEnabled = true;
			this.QuantifierBox.Location = new System.Drawing.Point(23, 9);
			this.QuantifierBox.Name = "QuantifierBox";
			this.QuantifierBox.Size = new System.Drawing.Size(442, 21);
			this.QuantifierBox.TabIndex = 4;
			// 
			// btnMoveDown
			// 
			this.btnMoveDown.Image = global::TagScanner.Properties.Resources.arrow_Down_16xLG;
			this.btnMoveDown.Location = new System.Drawing.Point(471, 191);
			this.btnMoveDown.Name = "btnMoveDown";
			this.btnMoveDown.Size = new System.Drawing.Size(30, 23);
			this.btnMoveDown.TabIndex = 12;
			this.ToolTip.SetToolTip(this.btnMoveDown, "Move Down");
			this.btnMoveDown.UseVisualStyleBackColor = true;
			// 
			// btnMoveUp
			// 
			this.btnMoveUp.Image = global::TagScanner.Properties.Resources.arrow_Up_16xLG;
			this.btnMoveUp.Location = new System.Drawing.Point(471, 162);
			this.btnMoveUp.Name = "btnMoveUp";
			this.btnMoveUp.Size = new System.Drawing.Size(30, 23);
			this.btnMoveUp.TabIndex = 11;
			this.ToolTip.SetToolTip(this.btnMoveUp, "Move Up");
			this.btnMoveUp.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(471, 104);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(30, 23);
			this.btnDelete.TabIndex = 13;
			this.ToolTip.SetToolTip(this.btnDelete, "Delete");
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// btnAddRootFilter
			// 
			this.btnAddRootFilter.Location = new System.Drawing.Point(471, 75);
			this.btnAddRootFilter.Name = "btnAddRootFilter";
			this.btnAddRootFilter.Size = new System.Drawing.Size(30, 23);
			this.btnAddRootFilter.TabIndex = 14;
			this.ToolTip.SetToolTip(this.btnAddRootFilter, "Add Filter");
			this.btnAddRootFilter.UseVisualStyleBackColor = true;
			// 
			// btnAddRootGroup
			// 
			this.btnAddRootGroup.Location = new System.Drawing.Point(471, 46);
			this.btnAddRootGroup.Name = "btnAddRootGroup";
			this.btnAddRootGroup.Size = new System.Drawing.Size(30, 23);
			this.btnAddRootGroup.TabIndex = 15;
			this.ToolTip.SetToolTip(this.btnAddRootGroup, "Add Group");
			this.btnAddRootGroup.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(471, 133);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(30, 23);
			this.btnClear.TabIndex = 16;
			this.ToolTip.SetToolTip(this.btnClear, "Clear All");
			this.btnClear.UseVisualStyleBackColor = true;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(471, 220);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(30, 23);
			this.btnOpen.TabIndex = 17;
			this.ToolTip.SetToolTip(this.btnOpen, "Open");
			this.btnOpen.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(471, 249);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(30, 23);
			this.btnSave.TabIndex = 18;
			this.ToolTip.SetToolTip(this.btnSave, "Delete");
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Location = new System.Drawing.Point(471, 278);
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(30, 23);
			this.btnSaveAs.TabIndex = 19;
			this.ToolTip.SetToolTip(this.btnSaveAs, "Delete");
			this.btnSaveAs.UseVisualStyleBackColor = true;
			// 
			// PopupMenu
			// 
			this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupAddChildGroup,
            this.popupAddChildFilter,
            this.popupInsertSiblingGroup,
            this.popupInsertSiblingFilter,
            this.popupDelete});
			this.PopupMenu.Name = "PopupMenu";
			this.PopupMenu.Size = new System.Drawing.Size(179, 114);
			// 
			// popupAddChildFilter
			// 
			this.popupAddChildFilter.Name = "popupAddChildFilter";
			this.popupAddChildFilter.Size = new System.Drawing.Size(178, 22);
			this.popupAddChildFilter.Text = "Add Child Filter";
			// 
			// popupAddChildGroup
			// 
			this.popupAddChildGroup.Name = "popupAddChildGroup";
			this.popupAddChildGroup.Size = new System.Drawing.Size(178, 22);
			this.popupAddChildGroup.Text = "Add Child Group";
			// 
			// popupDelete
			// 
			this.popupDelete.Name = "popupDelete";
			this.popupDelete.Size = new System.Drawing.Size(178, 22);
			this.popupDelete.Text = "Delete";
			// 
			// popupInsertSiblingGroup
			// 
			this.popupInsertSiblingGroup.Name = "popupInsertSiblingGroup";
			this.popupInsertSiblingGroup.Size = new System.Drawing.Size(178, 22);
			this.popupInsertSiblingGroup.Text = "Insert Sibling Group";
			// 
			// popupInsertSiblingFilter
			// 
			this.popupInsertSiblingFilter.Name = "popupInsertSiblingFilter";
			this.popupInsertSiblingFilter.Size = new System.Drawing.Size(178, 22);
			this.popupInsertSiblingFilter.Text = "Insert Sibling Filter";
			// 
			// FilterEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnSaveAs);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAddRootGroup);
			this.Controls.Add(this.btnAddRootFilter);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnMoveDown);
			this.Controls.Add(this.btnMoveUp);
			this.Controls.Add(this.ValueBox);
			this.Controls.Add(this.OperatorBox);
			this.Controls.Add(this.PropertyBox);
			this.Controls.Add(this.TreeView);
			this.Controls.Add(this.QuantifierBox);
			this.Name = "FilterEditor";
			this.Size = new System.Drawing.Size(520, 363);
			this.PopupMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.ComboBox PropertyBox;
		public System.Windows.Forms.ComboBox OperatorBox;
		public System.Windows.Forms.Panel ValueBox;
		public System.Windows.Forms.TreeView TreeView;
		public System.Windows.Forms.ComboBox QuantifierBox;
		public System.Windows.Forms.Button btnMoveDown;
		public System.Windows.Forms.Button btnMoveUp;
		public System.Windows.Forms.Button btnDelete;
		public System.Windows.Forms.Button btnAddRootFilter;
		public System.Windows.Forms.Button btnAddRootGroup;
		private System.Windows.Forms.ToolTip ToolTip;
		public System.Windows.Forms.Button btnClear;
		public System.Windows.Forms.Button btnOpen;
		public System.Windows.Forms.Button btnSave;
		public System.Windows.Forms.Button btnSaveAs;
		private System.Windows.Forms.ContextMenuStrip PopupMenu;
		public System.Windows.Forms.ToolStripMenuItem popupAddChildFilter;
		public System.Windows.Forms.ToolStripMenuItem popupAddChildGroup;
		public System.Windows.Forms.ToolStripMenuItem popupDelete;
		public System.Windows.Forms.ToolStripMenuItem popupInsertSiblingGroup;
		public System.Windows.Forms.ToolStripMenuItem popupInsertSiblingFilter;
	}
}
