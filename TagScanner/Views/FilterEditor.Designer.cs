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
			this.btnAddFilter = new System.Windows.Forms.Button();
			this.btnAddGroup = new System.Windows.Forms.Button();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnClear = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TreeView
			// 
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
			// btnAddFilter
			// 
			this.btnAddFilter.Location = new System.Drawing.Point(471, 46);
			this.btnAddFilter.Name = "btnAddFilter";
			this.btnAddFilter.Size = new System.Drawing.Size(30, 23);
			this.btnAddFilter.TabIndex = 14;
			this.ToolTip.SetToolTip(this.btnAddFilter, "Add Filter");
			this.btnAddFilter.UseVisualStyleBackColor = true;
			// 
			// btnAddGroup
			// 
			this.btnAddGroup.Location = new System.Drawing.Point(471, 75);
			this.btnAddGroup.Name = "btnAddGroup";
			this.btnAddGroup.Size = new System.Drawing.Size(30, 23);
			this.btnAddGroup.TabIndex = 15;
			this.ToolTip.SetToolTip(this.btnAddGroup, "Add Group");
			this.btnAddGroup.UseVisualStyleBackColor = true;
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
			// FilterEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnSaveAs);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAddGroup);
			this.Controls.Add(this.btnAddFilter);
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
		public System.Windows.Forms.Button btnAddFilter;
		public System.Windows.Forms.Button btnAddGroup;
		private System.Windows.Forms.ToolTip ToolTip;
		public System.Windows.Forms.Button btnClear;
		public System.Windows.Forms.Button btnOpen;
		public System.Windows.Forms.Button btnSave;
		public System.Windows.Forms.Button btnSaveAs;
	}
}
