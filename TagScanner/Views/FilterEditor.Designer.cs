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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("JoinedPerformers contains John");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("PictureCount > 0");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Duration > 00:10:00");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("At least one of these is true:", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("JoinedPerformers does not start with George");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("All of these are true:", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("IsClassical = false");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("PossiblyCorrupt = true");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("All of these are false:", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("FileSize < 1234567890123");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("At least one of these is false:", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
			this.TreeView = new System.Windows.Forms.TreeView();
			this.PropertyBox = new System.Windows.Forms.ComboBox();
			this.OperatorBox = new System.Windows.Forms.ComboBox();
			this.ValueBox = new System.Windows.Forms.Panel();
			this.QuantifierBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// TreeView
			// 
			this.TreeView.HideSelection = false;
			this.TreeView.Location = new System.Drawing.Point(23, 36);
			this.TreeView.Name = "TreeView";
			treeNode1.Name = "Node1";
			treeNode1.Text = "JoinedPerformers contains John";
			treeNode2.Name = "Node3";
			treeNode2.Text = "PictureCount > 0";
			treeNode3.Name = "Node4";
			treeNode3.Text = "Duration > 00:10:00";
			treeNode4.Name = "Node2";
			treeNode4.Text = "At least one of these is true:";
			treeNode5.Name = "Node0";
			treeNode5.Text = "JoinedPerformers does not start with George";
			treeNode6.Name = "Node0";
			treeNode6.Text = "All of these are true:";
			treeNode7.Name = "Node2";
			treeNode7.Text = "IsClassical = false";
			treeNode8.Name = "Node3";
			treeNode8.Text = "PossiblyCorrupt = true";
			treeNode9.Name = "Node1";
			treeNode9.Text = "All of these are false:";
			treeNode10.Name = "Node4";
			treeNode10.Text = "FileSize < 1234567890123";
			treeNode11.Name = "Node0";
			treeNode11.Text = "At least one of these is false:";
			this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode11});
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
			// FilterEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
	}
}
