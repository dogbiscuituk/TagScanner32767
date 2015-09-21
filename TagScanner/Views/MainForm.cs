using System;
using System.IO;
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
			Model.ModifiedChanged += Model_ModifiedChanged;
			ViewTechnology = ViewTechnology.WinForms;
			PictureController = new PictureController(PictureBox, PropertyGrid);
			StatusController = new StatusController(Model, StatusBar);
			PersistenceController = new PersistenceController(Model, this, FileReopen, FileReopenItem_Click);
			PersistenceController.FilePathChanged += PersistenceController_FilePathChanged;
			MediaController = new MediaController(Model, StatusController, AddRecentFolders, AddRecentFoldersItem_Click);
			Model_ModifiedChanged(Model, EventArgs.Empty);
        }

		#endregion

		#region View Technology

		private ViewTechnology _viewTechnology;
        private ViewTechnology ViewTechnology
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
					GridContainerHost.Visible = false;
					Control control = null;
					switch (ViewTechnology)
					{
						case ViewTechnology.WinForms:
							GridViewController = new GridViewControllerWF(Model, DataGrid);
							control = DataGrid;
							break;
						case ViewTechnology.WPF:
							GridViewController = new GridViewControllerWPF(Model, GridContainerHost);
							control = GridContainerHost;
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

		private IGridViewController _gridViewController;
		private IGridViewController GridViewController
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

		private readonly TagFileModel Model;
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

		private void HelpAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				string.Concat("Version ", Application.ProductVersion),
				string.Concat("About ", Application.ProductName));
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

		private void winFormsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewTechnology = ViewTechnology.WinForms;
		}

		private void wPFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewTechnology = ViewTechnology.WPF;
		}
	}
}
