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
			Model = new Models.Model();
			Model.ModifiedChanged += Model_ModifiedChanged;
			ViewTechnology = GridType.WPF;
			new PictureController(PictureBox, PropertyGrid);
			var statusController = new StatusController(Model, StatusBar);
			PersistenceController = new PersistenceController(Model, this, FileReopen, FileReopenItem_Click);
			PersistenceController.FilePathChanged += PersistenceController_FilePathChanged;
			MediaController = new MediaController(Model, statusController, AddRecentFolders, AddRecentFoldersItem_Click);
			Model_ModifiedChanged(Model, EventArgs.Empty);
			GridViewController.ViewByArtist();
		}

		#endregion

		#region View Technology

		private GridType _viewTechnology;
        private GridType ViewTechnology
		{
			get
			{
				return _viewTechnology;
			}
			set
			{
				if (ViewTechnology != value)
				{
					_viewTechnology = value;
                    DataGrid.Visible = false;
					GridElementHost.Visible = false;
					GridViewController = null;
					Control control = null;
					switch (ViewTechnology)
					{
						case GridType.WinForms:
							GridViewController = new GridControllerWF(Model, DataGrid);
							control = DataGrid;
							break;
						case GridType.WPF:
							GridViewController = new GridControllerWPF(Model, GridElementHost);
							control = GridElementHost;
							break;
					}
					if (control != null)
					{
						control.Dock = DockStyle.Fill;
						control.Visible = true;
					}
				}
			}
		}

		private GridController _gridViewController;
		private GridController GridViewController
		{
			get
			{
				return _gridViewController;
			}
			set
			{
				if (GridViewController != null)
				{
					GridViewController.SelectionChanged -= GridViewController_SelectionChanged;
				}
				_gridViewController = value;
				if (GridViewController != null)
				{
					GridViewController.SelectionChanged += GridViewController_SelectionChanged;
				}
			}
		}

		#endregion

		#region Fields

		private readonly Model Model;
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

		private void winFormsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewTechnology = GridType.WinForms;
		}

		private void wPFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewTechnology = GridType.WPF;
		}

		private void ViewByArtist_Click(object sender, EventArgs e)
		{
			GridViewController.ViewByArtist();
		}

		private void ViewByGenre_Click(object sender, EventArgs e)
		{
			GridViewController.ViewByGenre();
		}

		private void ViewByYear_Click(object sender, EventArgs e)
		{
			GridViewController.ViewByYear();
		}

		private void ViewByAlbumTitle_Click(object sender, EventArgs e)
		{
			GridViewController.ViewByAlbumTitle();
		}

		private void ViewBySongTitle_Click(object sender, EventArgs e)
		{
			GridViewController.ViewBySongTitle();
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

		private void PopupVisibleColumns_Click(object sender, EventArgs e)
		{
			EditQuery(0);
		}

		private void PopupGroups_Click(object sender, EventArgs e)
		{
			EditQuery(2);
		}

		private void PopupSort_Click(object sender, EventArgs e)
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
			PropertyGrid.SelectedObject = GridViewController.Selection;
		}

		private void PersistenceController_FilePathChanged(object sender, EventArgs e)
		{
			Text = PersistenceController.WindowCaption;
		}

		#endregion

		private void EditQuery(int page)
		{
			OptionsDialogController.Execute(this, page);
		}

		private OptionsDialogController _optionsDialogController;
		private OptionsDialogController OptionsDialogController
		{
			get
			{
				return
					_optionsDialogController
					?? (_optionsDialogController = new OptionsDialogController(GridViewController));
			}
		}
	}
}
