namespace TagScanner.Views
{
	partial class GridForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.GridElementHost = new System.Windows.Forms.Integration.ElementHost();
			this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.PopupColumns = new System.Windows.Forms.ToolStripMenuItem();
			this.PopupFilters = new System.Windows.Forms.ToolStripMenuItem();
			this.PopupGroups = new System.Windows.Forms.ToolStripMenuItem();
			this.PopupSorting = new System.Windows.Forms.ToolStripMenuItem();
			this.PopupOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.DataGrid = new System.Windows.Forms.DataGridView();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.PictureBox = new System.Windows.Forms.PictureBox();
			this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.FileReopen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.EditInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
			this.AddMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.AddMedia = new System.Windows.Forms.ToolStripMenuItem();
			this.AddFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.AddRecentFolders = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewPreset = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewByArtist = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewByGenre = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewByYear = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewByAlbumTitle = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewBySongTitle = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewLevel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.technologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.winFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.AddFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.AddFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.ModifiedLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.PopupMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
			this.MainMenu.SuspendLayout();
			this.StatusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.GridElementHost);
			this.splitContainer1.Panel1.Controls.Add(this.DataGrid);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(784, 516);
			this.splitContainer1.SplitterDistance = 547;
			this.splitContainer1.TabIndex = 7;
			// 
			// GridElementHost
			// 
			this.GridElementHost.ContextMenuStrip = this.PopupMenu;
			this.GridElementHost.Location = new System.Drawing.Point(23, 261);
			this.GridElementHost.Name = "GridElementHost";
			this.GridElementHost.Size = new System.Drawing.Size(482, 188);
			this.GridElementHost.TabIndex = 2;
			this.GridElementHost.Text = "GridContainerHost";
			this.GridElementHost.Child = null;
			// 
			// PopupMenu
			// 
			this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupColumns,
            this.PopupFilters,
            this.PopupGroups,
            this.PopupSorting,
            this.toolStripMenuItem7,
            this.PopupOptions});
			this.PopupMenu.Name = "PopupMenu";
			this.PopupMenu.Size = new System.Drawing.Size(132, 120);
			// 
			// PopupColumns
			// 
			this.PopupColumns.Name = "PopupColumns";
			this.PopupColumns.Size = new System.Drawing.Size(131, 22);
			this.PopupColumns.Text = "&Columns...";
			this.PopupColumns.Click += new System.EventHandler(this.PopupColumns_Click);
			// 
			// PopupFilters
			// 
			this.PopupFilters.Name = "PopupFilters";
			this.PopupFilters.Size = new System.Drawing.Size(131, 22);
			this.PopupFilters.Text = "&Filters...";
			this.PopupFilters.Click += new System.EventHandler(this.PopupFilters_Click);
			// 
			// PopupGroups
			// 
			this.PopupGroups.Name = "PopupGroups";
			this.PopupGroups.Size = new System.Drawing.Size(131, 22);
			this.PopupGroups.Text = "&Groups...";
			this.PopupGroups.Click += new System.EventHandler(this.PopupGroups_Click);
			// 
			// PopupSorting
			// 
			this.PopupSorting.Name = "PopupSorting";
			this.PopupSorting.Size = new System.Drawing.Size(131, 22);
			this.PopupSorting.Text = "&Sorting...";
			this.PopupSorting.Click += new System.EventHandler(this.PopupSorting_Click);
			// 
			// PopupOptions
			// 
			this.PopupOptions.Name = "PopupOptions";
			this.PopupOptions.Size = new System.Drawing.Size(131, 22);
			this.PopupOptions.Text = "&Options...";
			this.PopupOptions.Click += new System.EventHandler(this.PopupOptions_Click);
			// 
			// DataGrid
			// 
			this.DataGrid.AllowUserToAddRows = false;
			this.DataGrid.AllowUserToDeleteRows = false;
			this.DataGrid.AllowUserToOrderColumns = true;
			this.DataGrid.AllowUserToResizeRows = false;
			this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.DataGrid.ContextMenuStrip = this.PopupMenu;
			this.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.DataGrid.Location = new System.Drawing.Point(23, 25);
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.ReadOnly = true;
			this.DataGrid.RowHeadersVisible = false;
			this.DataGrid.RowTemplate.Height = 18;
			this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DataGrid.ShowEditingIcon = false;
			this.DataGrid.Size = new System.Drawing.Size(482, 211);
			this.DataGrid.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.PictureBox);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.PropertyGrid);
			this.splitContainer2.Size = new System.Drawing.Size(233, 516);
			this.splitContainer2.SplitterDistance = 135;
			this.splitContainer2.TabIndex = 1;
			// 
			// PictureBox
			// 
			this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBox.Location = new System.Drawing.Point(0, 0);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new System.Drawing.Size(233, 135);
			this.PictureBox.TabIndex = 0;
			this.PictureBox.TabStop = false;
			// 
			// PropertyGrid
			// 
			this.PropertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
			this.PropertyGrid.Name = "PropertyGrid";
			this.PropertyGrid.Size = new System.Drawing.Size(233, 377);
			this.PropertyGrid.TabIndex = 0;
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.AddMenu,
            this.ViewMenu,
            this.HelpMenu});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(784, 24);
			this.MainMenu.TabIndex = 8;
			this.MainMenu.Text = "menuStrip1";
			// 
			// FileMenu
			// 
			this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.FileOpen,
            this.FileSave,
            this.FileSaveAs,
            this.toolStripMenuItem1,
            this.FileReopen,
            this.toolStripMenuItem5,
            this.FileExit});
			this.FileMenu.Name = "FileMenu";
			this.FileMenu.Size = new System.Drawing.Size(37, 20);
			this.FileMenu.Text = "&File";
			this.FileMenu.DropDownOpening += new System.EventHandler(this.FileMenu_DropDownOpening);
			// 
			// FileNew
			// 
			this.FileNew.Name = "FileNew";
			this.FileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.FileNew.Size = new System.Drawing.Size(155, 22);
			this.FileNew.Text = "&New";
			this.FileNew.Click += new System.EventHandler(this.FileNew_Click);
			// 
			// FileOpen
			// 
			this.FileOpen.Name = "FileOpen";
			this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.FileOpen.Size = new System.Drawing.Size(155, 22);
			this.FileOpen.Text = "&Open...";
			this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
			// 
			// FileSave
			// 
			this.FileSave.Name = "FileSave";
			this.FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.FileSave.Size = new System.Drawing.Size(155, 22);
			this.FileSave.Text = "&Save";
			this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
			// 
			// FileSaveAs
			// 
			this.FileSaveAs.Name = "FileSaveAs";
			this.FileSaveAs.Size = new System.Drawing.Size(155, 22);
			this.FileSaveAs.Text = "Save &As...";
			this.FileSaveAs.Click += new System.EventHandler(this.FileSaveAs_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
			// 
			// FileReopen
			// 
			this.FileReopen.Name = "FileReopen";
			this.FileReopen.Size = new System.Drawing.Size(155, 22);
			this.FileReopen.Text = "&Reopen";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 6);
			// 
			// FileExit
			// 
			this.FileExit.Name = "FileExit";
			this.FileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.FileExit.Size = new System.Drawing.Size(155, 22);
			this.FileExit.Text = "E&xit";
			this.FileExit.Click += new System.EventHandler(this.FileExit_Click);
			// 
			// EditMenu
			// 
			this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditSelectAll,
            this.EditInvertSelection});
			this.EditMenu.Name = "EditMenu";
			this.EditMenu.Size = new System.Drawing.Size(39, 20);
			this.EditMenu.Text = "&Edit";
			// 
			// EditSelectAll
			// 
			this.EditSelectAll.Name = "EditSelectAll";
			this.EditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.EditSelectAll.Size = new System.Drawing.Size(164, 22);
			this.EditSelectAll.Text = "Select &All";
			this.EditSelectAll.Click += new System.EventHandler(this.EditSelectAll_Click);
			// 
			// EditInvertSelection
			// 
			this.EditInvertSelection.Name = "EditInvertSelection";
			this.EditInvertSelection.Size = new System.Drawing.Size(164, 22);
			this.EditInvertSelection.Text = "&Invert Selection";
			this.EditInvertSelection.Click += new System.EventHandler(this.EditInvertSelection_Click);
			// 
			// AddMenu
			// 
			this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMedia,
            this.AddFolder,
            this.toolStripMenuItem3,
            this.AddRecentFolders});
			this.AddMenu.Name = "AddMenu";
			this.AddMenu.Size = new System.Drawing.Size(41, 20);
			this.AddMenu.Text = "&Add";
			// 
			// AddMedia
			// 
			this.AddMedia.Name = "AddMedia";
			this.AddMedia.Size = new System.Drawing.Size(151, 22);
			this.AddMedia.Text = "&Media...";
			this.AddMedia.Click += new System.EventHandler(this.AddMedia_Click);
			// 
			// AddFolder
			// 
			this.AddFolder.Name = "AddFolder";
			this.AddFolder.Size = new System.Drawing.Size(151, 22);
			this.AddFolder.Text = "&Folder...";
			this.AddFolder.Click += new System.EventHandler(this.AddFolder_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 6);
			// 
			// AddRecentFolders
			// 
			this.AddRecentFolders.Name = "AddRecentFolders";
			this.AddRecentFolders.Size = new System.Drawing.Size(151, 22);
			this.AddRecentFolders.Text = "&Recent Folders";
			// 
			// ViewMenu
			// 
			this.ViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewPreset,
            this.ViewLevel,
            this.toolStripMenuItem2,
            this.ViewOptions,
            this.toolStripMenuItem6,
            this.technologyToolStripMenuItem});
			this.ViewMenu.Name = "ViewMenu";
			this.ViewMenu.Size = new System.Drawing.Size(44, 20);
			this.ViewMenu.Text = "&View";
			// 
			// ViewPreset
			// 
			this.ViewPreset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewByArtist,
            this.ViewByGenre,
            this.ViewByYear,
            this.toolStripMenuItem4,
            this.ViewByAlbumTitle,
            this.ViewBySongTitle});
			this.ViewPreset.Name = "ViewPreset";
			this.ViewPreset.Size = new System.Drawing.Size(136, 22);
			this.ViewPreset.Text = "&Preset";
			// 
			// ViewByArtist
			// 
			this.ViewByArtist.Name = "ViewByArtist";
			this.ViewByArtist.Size = new System.Drawing.Size(152, 22);
			this.ViewByArtist.Text = "by &Artist";
			this.ViewByArtist.Click += new System.EventHandler(this.ViewByArtist_Click);
			// 
			// ViewByGenre
			// 
			this.ViewByGenre.Name = "ViewByGenre";
			this.ViewByGenre.Size = new System.Drawing.Size(152, 22);
			this.ViewByGenre.Text = "by &Genre";
			this.ViewByGenre.Click += new System.EventHandler(this.ViewByGenre_Click);
			// 
			// ViewByYear
			// 
			this.ViewByYear.Name = "ViewByYear";
			this.ViewByYear.Size = new System.Drawing.Size(152, 22);
			this.ViewByYear.Text = "by &Year";
			this.ViewByYear.Click += new System.EventHandler(this.ViewByYear_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
			// 
			// ViewByAlbumTitle
			// 
			this.ViewByAlbumTitle.Name = "ViewByAlbumTitle";
			this.ViewByAlbumTitle.Size = new System.Drawing.Size(152, 22);
			this.ViewByAlbumTitle.Text = "by Al&bum Title";
			this.ViewByAlbumTitle.Click += new System.EventHandler(this.ViewByAlbumTitle_Click);
			// 
			// ViewBySongTitle
			// 
			this.ViewBySongTitle.Name = "ViewBySongTitle";
			this.ViewBySongTitle.Size = new System.Drawing.Size(152, 22);
			this.ViewBySongTitle.Text = "by &Song Title";
			this.ViewBySongTitle.Click += new System.EventHandler(this.ViewBySongTitle_Click);
			// 
			// ViewLevel
			// 
			this.ViewLevel.Name = "ViewLevel";
			this.ViewLevel.Size = new System.Drawing.Size(136, 22);
			this.ViewLevel.Text = "&Level";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
			// 
			// ViewOptions
			// 
			this.ViewOptions.Name = "ViewOptions";
			this.ViewOptions.Size = new System.Drawing.Size(136, 22);
			this.ViewOptions.Text = "&Options...";
			this.ViewOptions.Click += new System.EventHandler(this.ViewOptions_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(133, 6);
			// 
			// technologyToolStripMenuItem
			// 
			this.technologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.winFormsToolStripMenuItem,
            this.wPFToolStripMenuItem});
			this.technologyToolStripMenuItem.Name = "technologyToolStripMenuItem";
			this.technologyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.technologyToolStripMenuItem.Text = "&Technology";
			// 
			// winFormsToolStripMenuItem
			// 
			this.winFormsToolStripMenuItem.Name = "winFormsToolStripMenuItem";
			this.winFormsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.winFormsToolStripMenuItem.Text = "&WinForms";
			this.winFormsToolStripMenuItem.Click += new System.EventHandler(this.winFormsToolStripMenuItem_Click);
			// 
			// wPFToolStripMenuItem
			// 
			this.wPFToolStripMenuItem.Name = "wPFToolStripMenuItem";
			this.wPFToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.wPFToolStripMenuItem.Text = "W&PF";
			this.wPFToolStripMenuItem.Click += new System.EventHandler(this.wPFToolStripMenuItem_Click);
			// 
			// HelpMenu
			// 
			this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpAbout});
			this.HelpMenu.Name = "HelpMenu";
			this.HelpMenu.Size = new System.Drawing.Size(44, 20);
			this.HelpMenu.Text = "&Help";
			// 
			// HelpAbout
			// 
			this.HelpAbout.Name = "HelpAbout";
			this.HelpAbout.Size = new System.Drawing.Size(107, 22);
			this.HelpAbout.Text = "&About";
			this.HelpAbout.Click += new System.EventHandler(this.HelpAbout_Click);
			// 
			// AddFolderDialog
			// 
			this.AddFolderDialog.Description = "Select the folder to add";
			// 
			// AddFileDialog
			// 
			this.AddFileDialog.Multiselect = true;
			this.AddFileDialog.Title = "Select the media file(s) to add";
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModifiedLabel});
			this.StatusBar.Location = new System.Drawing.Point(0, 540);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(784, 22);
			this.StatusBar.TabIndex = 9;
			this.StatusBar.Text = "Status";
			// 
			// ModifiedLabel
			// 
			this.ModifiedLabel.Name = "ModifiedLabel";
			this.ModifiedLabel.Size = new System.Drawing.Size(55, 17);
			this.ModifiedLabel.Text = "Modified";
			this.ModifiedLabel.Visible = false;
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(128, 6);
			// 
			// GridForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.MainMenu);
			this.Controls.Add(this.StatusBar);
			this.Name = "GridForm";
			this.Text = "ID3 Tag Explorer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.PopupMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.PictureBox PictureBox;
		private System.Windows.Forms.PropertyGrid PropertyGrid;
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileExit;
		private System.Windows.Forms.ToolStripMenuItem EditMenu;
		private System.Windows.Forms.ToolStripMenuItem EditSelectAll;
		private System.Windows.Forms.ToolStripMenuItem EditInvertSelection;
		private System.Windows.Forms.ToolStripMenuItem ViewMenu;
		private System.Windows.Forms.ToolStripMenuItem ViewPreset;
		private System.Windows.Forms.ToolStripMenuItem ViewByArtist;
		private System.Windows.Forms.ToolStripMenuItem ViewByGenre;
		private System.Windows.Forms.ToolStripMenuItem ViewByYear;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem ViewByAlbumTitle;
		private System.Windows.Forms.ToolStripMenuItem ViewBySongTitle;
		private System.Windows.Forms.ToolStripMenuItem ViewLevel;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ViewOptions;
		private System.Windows.Forms.ToolStripMenuItem HelpMenu;
		private System.Windows.Forms.ToolStripMenuItem HelpAbout;
		private System.Windows.Forms.FolderBrowserDialog AddFolderDialog;
		private System.Windows.Forms.OpenFileDialog AddFileDialog;
        private System.Windows.Forms.DataGridView DataGrid;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripMenuItem FileNew;
		private System.Windows.Forms.ToolStripMenuItem FileOpen;
		private System.Windows.Forms.ToolStripMenuItem FileSave;
		private System.Windows.Forms.ToolStripMenuItem FileSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem AddMenu;
		private System.Windows.Forms.ToolStripMenuItem AddMedia;
		private System.Windows.Forms.ToolStripMenuItem AddFolder;
		private System.Windows.Forms.ToolStripMenuItem AddRecentFolders;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem FileReopen;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripStatusLabel ModifiedLabel;
		private System.Windows.Forms.Integration.ElementHost GridElementHost;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem technologyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem winFormsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wPFToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip PopupMenu;
		private System.Windows.Forms.ToolStripMenuItem PopupColumns;
		private System.Windows.Forms.ToolStripMenuItem PopupGroups;
		private System.Windows.Forms.ToolStripMenuItem PopupSorting;
		private System.Windows.Forms.ToolStripMenuItem PopupOptions;
		private System.Windows.Forms.ToolStripMenuItem PopupFilters;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
	}
}

