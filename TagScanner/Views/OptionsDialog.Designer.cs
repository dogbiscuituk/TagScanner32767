namespace TagScanner.Views
{
	partial class OptionsDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TabControl = new System.Windows.Forms.TabControl();
			this.SelectColumnsPage = new System.Windows.Forms.TabPage();
			this.WhereFilterPage = new System.Windows.Forms.TabPage();
			this.GroupByColumnsPage = new System.Windows.Forms.TabPage();
			this.HavingFilterPage = new System.Windows.Forms.TabPage();
			this.OrderByColumnsPage = new System.Windows.Forms.TabPage();
			this.OptionsPage = new System.Windows.Forms.TabPage();
			this.cbGridLinesVertical = new System.Windows.Forms.CheckBox();
			this.cbGridLinesHorizontal = new System.Windows.Forms.CheckBox();
			this.cbAutoFitColumns = new System.Windows.Forms.CheckBox();
			this.cbHeaderSummaries = new System.Windows.Forms.CheckBox();
			this.cbGroupFooters = new System.Windows.Forms.CheckBox();
			this.cbMergeCells = new System.Windows.Forms.CheckBox();
			this.cbShowExact = new System.Windows.Forms.CheckBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.TabControl.SuspendLayout();
			this.OptionsPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Controls.Add(this.SelectColumnsPage);
			this.TabControl.Controls.Add(this.WhereFilterPage);
			this.TabControl.Controls.Add(this.GroupByColumnsPage);
			this.TabControl.Controls.Add(this.HavingFilterPage);
			this.TabControl.Controls.Add(this.OrderByColumnsPage);
			this.TabControl.Controls.Add(this.OptionsPage);
			this.TabControl.Location = new System.Drawing.Point(12, 12);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(528, 389);
			this.TabControl.TabIndex = 13;
			// 
			// SelectColumnsPage
			// 
			this.SelectColumnsPage.Location = new System.Drawing.Point(4, 22);
			this.SelectColumnsPage.Name = "SelectColumnsPage";
			this.SelectColumnsPage.Padding = new System.Windows.Forms.Padding(3);
			this.SelectColumnsPage.Size = new System.Drawing.Size(520, 363);
			this.SelectColumnsPage.TabIndex = 0;
			this.SelectColumnsPage.Text = "Visible Columns";
			this.SelectColumnsPage.UseVisualStyleBackColor = true;
			// 
			// WhereFilterPage
			// 
			this.WhereFilterPage.Location = new System.Drawing.Point(4, 22);
			this.WhereFilterPage.Name = "WhereFilterPage";
			this.WhereFilterPage.Size = new System.Drawing.Size(520, 363);
			this.WhereFilterPage.TabIndex = 3;
			this.WhereFilterPage.Text = "Where";
			this.WhereFilterPage.UseVisualStyleBackColor = true;
			// 
			// GroupByColumnsPage
			// 
			this.GroupByColumnsPage.Location = new System.Drawing.Point(4, 22);
			this.GroupByColumnsPage.Name = "GroupByColumnsPage";
			this.GroupByColumnsPage.Padding = new System.Windows.Forms.Padding(3);
			this.GroupByColumnsPage.Size = new System.Drawing.Size(520, 363);
			this.GroupByColumnsPage.TabIndex = 1;
			this.GroupByColumnsPage.Text = "Grouping";
			this.GroupByColumnsPage.UseVisualStyleBackColor = true;
			// 
			// HavingFilterPage
			// 
			this.HavingFilterPage.Location = new System.Drawing.Point(4, 22);
			this.HavingFilterPage.Name = "HavingFilterPage";
			this.HavingFilterPage.Size = new System.Drawing.Size(520, 363);
			this.HavingFilterPage.TabIndex = 4;
			this.HavingFilterPage.Text = "Having";
			this.HavingFilterPage.UseVisualStyleBackColor = true;
			// 
			// OrderByColumnsPage
			// 
			this.OrderByColumnsPage.Location = new System.Drawing.Point(4, 22);
			this.OrderByColumnsPage.Name = "OrderByColumnsPage";
			this.OrderByColumnsPage.Padding = new System.Windows.Forms.Padding(3);
			this.OrderByColumnsPage.Size = new System.Drawing.Size(520, 363);
			this.OrderByColumnsPage.TabIndex = 2;
			this.OrderByColumnsPage.Text = "Sort";
			this.OrderByColumnsPage.UseVisualStyleBackColor = true;
			// 
			// OptionsPage
			// 
			this.OptionsPage.Controls.Add(this.cbGridLinesVertical);
			this.OptionsPage.Controls.Add(this.cbGridLinesHorizontal);
			this.OptionsPage.Controls.Add(this.cbAutoFitColumns);
			this.OptionsPage.Controls.Add(this.cbHeaderSummaries);
			this.OptionsPage.Controls.Add(this.cbGroupFooters);
			this.OptionsPage.Controls.Add(this.cbMergeCells);
			this.OptionsPage.Controls.Add(this.cbShowExact);
			this.OptionsPage.Location = new System.Drawing.Point(4, 22);
			this.OptionsPage.Name = "OptionsPage";
			this.OptionsPage.Padding = new System.Windows.Forms.Padding(3);
			this.OptionsPage.Size = new System.Drawing.Size(520, 363);
			this.OptionsPage.TabIndex = 5;
			this.OptionsPage.Text = "Options";
			this.OptionsPage.UseVisualStyleBackColor = true;
			// 
			// cbGridLinesVertical
			// 
			this.cbGridLinesVertical.AutoSize = true;
			this.cbGridLinesVertical.Location = new System.Drawing.Point(166, 239);
			this.cbGridLinesVertical.Name = "cbGridLinesVertical";
			this.cbGridLinesVertical.Size = new System.Drawing.Size(111, 17);
			this.cbGridLinesVertical.TabIndex = 23;
			this.cbGridLinesVertical.Text = "&Vertical Grid Lines";
			this.cbGridLinesVertical.UseVisualStyleBackColor = true;
			// 
			// cbGridLinesHorizontal
			// 
			this.cbGridLinesHorizontal.AutoSize = true;
			this.cbGridLinesHorizontal.Location = new System.Drawing.Point(166, 216);
			this.cbGridLinesHorizontal.Name = "cbGridLinesHorizontal";
			this.cbGridLinesHorizontal.Size = new System.Drawing.Size(123, 17);
			this.cbGridLinesHorizontal.TabIndex = 22;
			this.cbGridLinesHorizontal.Text = "&Horizontal Grid Lines";
			this.cbGridLinesHorizontal.UseVisualStyleBackColor = true;
			// 
			// cbAutoFitColumns
			// 
			this.cbAutoFitColumns.AutoSize = true;
			this.cbAutoFitColumns.Location = new System.Drawing.Point(167, 101);
			this.cbAutoFitColumns.Name = "cbAutoFitColumns";
			this.cbAutoFitColumns.Size = new System.Drawing.Size(105, 17);
			this.cbAutoFitColumns.TabIndex = 21;
			this.cbAutoFitColumns.Text = "&Auto Fit Columns";
			this.cbAutoFitColumns.UseVisualStyleBackColor = true;
			// 
			// cbHeaderSummaries
			// 
			this.cbHeaderSummaries.AutoSize = true;
			this.cbHeaderSummaries.Location = new System.Drawing.Point(166, 170);
			this.cbHeaderSummaries.Name = "cbHeaderSummaries";
			this.cbHeaderSummaries.Size = new System.Drawing.Size(208, 17);
			this.cbHeaderSummaries.TabIndex = 20;
			this.cbHeaderSummaries.Text = "Show &Summary Information in Headers";
			this.cbHeaderSummaries.UseVisualStyleBackColor = true;
			// 
			// cbGroupFooters
			// 
			this.cbGroupFooters.AutoSize = true;
			this.cbGroupFooters.Location = new System.Drawing.Point(167, 193);
			this.cbGroupFooters.Name = "cbGroupFooters";
			this.cbGroupFooters.Size = new System.Drawing.Size(123, 17);
			this.cbGroupFooters.TabIndex = 19;
			this.cbGroupFooters.Text = "Show Group &Footers";
			this.cbGroupFooters.UseVisualStyleBackColor = true;
			// 
			// cbMergeCells
			// 
			this.cbMergeCells.AutoSize = true;
			this.cbMergeCells.Location = new System.Drawing.Point(167, 147);
			this.cbMergeCells.Name = "cbMergeCells";
			this.cbMergeCells.Size = new System.Drawing.Size(81, 17);
			this.cbMergeCells.TabIndex = 18;
			this.cbMergeCells.Text = "&Merge Cells";
			this.cbMergeCells.UseVisualStyleBackColor = true;
			// 
			// cbShowExact
			// 
			this.cbShowExact.AutoSize = true;
			this.cbShowExact.Location = new System.Drawing.Point(167, 124);
			this.cbShowExact.Name = "cbShowExact";
			this.cbShowExact.Size = new System.Drawing.Size(157, 17);
			this.cbShowExact.TabIndex = 17;
			this.cbShowExact.Text = "&Exact Durations && File Sizes";
			this.cbShowExact.UseVisualStyleBackColor = true;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(462, 407);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 19;
			this.btnApply.Text = "&Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(381, 407);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 18;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(300, 407);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 17;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// OptionsDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(552, 442);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.TabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.TabControl.ResumeLayout(false);
			this.OptionsPage.ResumeLayout(false);
			this.OptionsPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.TabControl TabControl;
		public System.Windows.Forms.TabPage SelectColumnsPage;
		private System.Windows.Forms.TabPage WhereFilterPage;
		public System.Windows.Forms.TabPage GroupByColumnsPage;
		private System.Windows.Forms.TabPage HavingFilterPage;
		public System.Windows.Forms.TabPage OrderByColumnsPage;
		private System.Windows.Forms.TabPage OptionsPage;
		public System.Windows.Forms.CheckBox cbGridLinesVertical;
		public System.Windows.Forms.CheckBox cbGridLinesHorizontal;
		public System.Windows.Forms.CheckBox cbAutoFitColumns;
		public System.Windows.Forms.CheckBox cbHeaderSummaries;
		public System.Windows.Forms.CheckBox cbGroupFooters;
		public System.Windows.Forms.CheckBox cbMergeCells;
		public System.Windows.Forms.CheckBox cbShowExact;
		public System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}