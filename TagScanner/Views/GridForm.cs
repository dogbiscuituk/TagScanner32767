using System;
using System.Windows.Forms;
using TagScanner.Controllers;
using TagScanner.Models;

namespace TagScanner.Views
{
	public partial class GridForm : Form
	{
		#region Lifetime Management

		public GridForm()
		{
			InitializeComponent();
			Model = new Model();
			Model.ModifiedChanged += Model_ModifiedChanged;
			GridController = new GridController(Model, GridElementHost);
			GridController.SelectionChanged += GridViewController_SelectionChanged;
			new PictureController(PictureBox, PropertyGrid);
			var statusController = new StatusController(Model, StatusBar);
			PersistenceController = new PersistenceController(Model, this, FileReopen, FileReopenItem_Click);
			PersistenceController.FilePathChanged += PersistenceController_FilePathChanged;
			MediaController = new MediaController(Model, statusController, AddRecentFolders, AddRecentFoldersItem_Click);
			Model_ModifiedChanged(Model, EventArgs.Empty);
			GridController.ViewByArtist();
		}

		#endregion

		#region Fields

		private readonly Model Model;
		private readonly GridController GridController;
        private readonly MediaController MediaController;
		private readonly PersistenceController PersistenceController;

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
			GridController.SelectAll();
		}

		private void EditInvertSelection_Click(object sender, EventArgs e)
		{
			GridController.InvertSelection();
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

		private void ViewByArtist_Click(object sender, EventArgs e)
		{
			GridController.ViewByArtist();
		}

		private void ViewByGenre_Click(object sender, EventArgs e)
		{
			GridController.ViewByGenre();
		}

		private void ViewByYear_Click(object sender, EventArgs e)
		{
			GridController.ViewByYear();
		}

		private void ViewByAlbumTitle_Click(object sender, EventArgs e)
		{
			GridController.ViewByAlbumTitle();
		}

		private void ViewBySongTitle_Click(object sender, EventArgs e)
		{
			GridController.ViewBySongTitle();
		}

		private void ViewOptions_Click(object sender, EventArgs e)
		{
			EditQuery(5);
		}

		private void HelpAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				string.Concat("Version ", Application.ProductVersion),
				string.Concat("About ", Application.ProductName));
		}

		#endregion

		#region Popup Menu

		private void PopupColumns_Click(object sender, EventArgs e)
		{
			EditQuery(0);
		}

		private void PopupFilters_Click(object sender, EventArgs e)
		{
			EditQuery(1);
		}

		private void PopupGroups_Click(object sender, EventArgs e)
		{
			EditQuery(2);
		}

		private void PopupSorting_Click(object sender, EventArgs e)
		{
			EditQuery(4);
		}

		private void PopupOptions_Click(object sender, EventArgs e)
		{
			EditQuery(5);
		}

		#endregion

		#region Event Handlers

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !PersistenceController.SaveIfModified();
		}

		private void Model_ModifiedChanged(object sender, EventArgs e)
		{
			Text = PersistenceController.WindowCaption;
			ModifiedLabel.Visible = Model.Modified;
		}

		private void GridViewController_SelectionChanged(object sender, EventArgs e)
		{
			PropertyGrid.SelectedObject = GridController.Selection;
		}

		private void PersistenceController_FilePathChanged(object sender, EventArgs e)
		{
			Text = PersistenceController.WindowCaption;
		}

		#endregion

		private void EditQuery(int page)
		{
			OptionsDialogController.Show(this, page);
		}

		private OptionsDialogController _optionsDialogController;
		private OptionsDialogController OptionsDialogController
		{
			get
			{
				return
					_optionsDialogController
					?? (_optionsDialogController = new OptionsDialogController(GridController));
			}
		}
	}
}
