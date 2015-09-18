using System;
using System.Windows.Forms;
using TagScanner.Controllers;
using TagScanner.Model;

namespace TagScanner.Views
{
	public partial class MainForm : Form
	{
		#region Lifetime Management

		public MainForm()
		{
			InitializeComponent();
			Model = new TagFileModel();
			GridViewController = new GridViewController(Model, DataGrid);
			GridViewController.SelectionChanged += GridViewController_SelectionChanged;
			PictureController = new PictureController(PictureBox, PropertyGrid);
			StatusController = new StatusController(Model, StatusBar);
			PersistenceController = new PersistenceController(Model, FileReopen, FileReopenItem_Click);
			MediaController = new MediaController(Model, StatusController, AddRecentFolders, AddRecentFoldersItem_Click);
		}

		#endregion

		#region Fields

		private readonly TagFileModel Model;
		private readonly GridViewController GridViewController;
        private readonly PictureController PictureController;
		private readonly StatusController StatusController;
		private readonly PersistenceController PersistenceController;
		private readonly MediaController MediaController;

		#endregion

		#region Main Menu

		private void FileMenu_DropDownOpening(object sender, EventArgs e)
		{
			FileSave.Enabled = Model.Modified;
		}

		private void FileNew_Click(object sender, EventArgs e)
		{
			PersistenceController.Clear();
		}

		private void FileOpen_Click(object sender, EventArgs e)
		{
			PersistenceController.Open();
		}

		private void FileSave_Click(object sender, EventArgs e)
		{
			PersistenceController.Save();
		}

		private void FileSaveAs_Click(object sender, EventArgs e)
		{
			PersistenceController.SaveAs();
		}

		private void FileReopenItem_Click(object sender, EventArgs e)
		{
			PersistenceController.Reopen((ToolStripItem)sender);
		}

		private void FileExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void EditSelectAll_Click(object sender, EventArgs e)
		{
			GridViewController.SelectAll();
		}

		private void EditInvertSelection_Click(object sender, EventArgs e)
		{
			GridViewController.InvertSelection();
		}

		private void AddMedia_Click(object sender, EventArgs e)
		{
			MediaController.AddFiles();
		}

		private void AddFolder_Click(object sender, EventArgs e)
		{
			MediaController.AddFolder();
		}

		private void AddRecentFoldersItem_Click(object sender, EventArgs e)
		{
			MediaController.Reopen((ToolStripItem)sender);
		}

		#endregion

		#region Event Handlers

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !PersistenceController.SaveIfModified();
		}

		private void GridViewController_SelectionChanged(object sender, EventArgs e)
		{
			PropertyGrid.SelectedObject = GridViewController.Selection;
		}

		#endregion
	}
}
