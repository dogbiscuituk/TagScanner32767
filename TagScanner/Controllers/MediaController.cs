using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagScanner.Models;

namespace TagScanner.Controllers
{
	public class MediaController
	{
		#region Lifetime Management

		public MediaController(Model model, StatusController statusController, ToolStripDropDownItem recentMenu, EventHandler onItemClick)
		{
			Model = model;
			StatusController = statusController;
            var filter = Properties.Settings.Default.MediaFilter;
			OpenFileDialog = new OpenFileDialog
			{
				Filter = filter,
				Multiselect = true,
				Title = "Select the media file(s) to add"
			};
			FolderBrowserDialog = new FolderBrowserDialog
			{
				Description = "Select the media folder to add"
			};
			MruController = new MruController(Application.ProductName + @"\MediaMRU", recentMenu, onItemClick);
		}

		#endregion

		#region Public Interface

		public void AddFiles()
		{
			if (OpenFileDialog.ShowDialog() == DialogResult.OK)
				AddFiles(OpenFileDialog.FileNames);
		}

		public void AddFolder()
		{
			if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				var filter = OpenFileDialog.Filter;
				var filterIndex = OpenFileDialog.FilterIndex;
				var filters = filter.Split('|');
				AddFolder(FolderBrowserDialog.SelectedPath, filters[2 * filterIndex - 1]);
			}
		}

		public void Reopen(ToolStripItem menuItem)
		{
			var folderPath = menuItem.Text.AmpersandUnescape();
			if (Directory.Exists(folderPath))
				AddFolderAsync(folderPath, menuItem.ToolTipText);
			else if (MessageBox.Show(
				string.Format("The folder \"{0}\" no longer exists. Remove from menu?", folderPath),
				"Add Recent Folder",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
				MruController.RemoveItem(folderPath);
		}

		#endregion

		#region Private Implementation

		#region State

		private readonly Model Model;
		private readonly MruController MruController;
		private readonly StatusController StatusController;
		private readonly OpenFileDialog OpenFileDialog;
		private readonly FolderBrowserDialog FolderBrowserDialog;

		#endregion

		#region Adding Media (sync & async)

		private void AddFiles(string[] filePaths)
		{
			AddFilesAsync(filePaths);
		}

		private async Task<int> AddFilesAsync(string[] filePaths)
		{
			var progress = StatusController.NewProgress();
			return await Task.Run(() => Model.AddFiles(filePaths, progress));
		}

		private void AddFolder(string folderPath, string filter)
		{
			MruController.AddItem(string.Concat(folderPath, '|', filter));
			AddFolderAsync(folderPath, filter);
		}

		private async Task<int> AddFolderAsync(string folderPath, string filter)
		{
			var progress = StatusController.NewProgress();
			return await Task.Run(() => Model.AddFolder(folderPath, filter, progress));
		}

		#endregion

		#endregion
	}
}
