using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TagScanner.Model;

namespace TagScanner.Controllers
{
	public class PersistenceController
	{
		#region Lifetime Management

		public PersistenceController(TagFileModel model, ToolStripDropDownItem recentMenu, EventHandler onItemClick)
		{
			Model = model;
			var filter = Properties.Settings.Default.LibraryFilter;
			OpenFileDialog = new OpenFileDialog
			{
				Filter = filter,
				Title = "Select the library file to open"
			};
			SaveFileDialog = new SaveFileDialog
			{
				Filter = filter,
				Title = "Save library file"
			};
			MruController = new MruController(Application.ProductName + @"\LibraryMRU", recentMenu, onItemClick);
		}

		#endregion

		#region Public Interface

		public bool Clear()
		{
			var result = SaveIfModified();
			if (result)
			{
				Model.Files = new List<TagFile>();
				Model.Modified = false;
				FilePath = string.Empty;
			}
			return result;
		}

		public bool Open()
		{
			return SaveIfModified() && OpenFileDialog.ShowDialog() == DialogResult.OK && LoadFromFile(OpenFileDialog.FileName);
		}

		public bool Save()
		{
			return string.IsNullOrEmpty(FilePath) ? SaveAs() : SaveToFile(FilePath);
		}

		public bool Reopen(ToolStripItem menuItem)
		{
			var filePath = menuItem.Text.AmpersandUnescape();
			if (!File.Exists(filePath))
			{
				if (MessageBox.Show(
					string.Format("The library file \"{0}\" no longer exists. Remove from menu?", filePath),
					"Reopen Library File",
					MessageBoxButtons.YesNo) == DialogResult.Yes)
					MruController.RemoveItem(filePath);
				return false;
			}
			return SaveIfModified() && LoadFromFile(filePath);
		}

		public bool SaveAs()
		{
			return SaveFileDialog.ShowDialog() == DialogResult.OK && SaveToFile(SaveFileDialog.FileName);
		}

		public bool SaveIfModified()
		{
			if (Model.Modified)
				switch (MessageBox.Show(
					"The contents of this library have changed. Do you want to save the changes?",
					"Library modified",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning))
				{
					case DialogResult.Yes:
						return Save();
					case DialogResult.No:
						return true;
					case DialogResult.Cancel:
						return false;
				}
			return true;
		}

		#endregion

		#region Private Implementation

		#region State

		private string FilePath { get; set; }
		private readonly TagFileModel Model;
		private readonly MruController MruController;
		private readonly OpenFileDialog OpenFileDialog;
		private readonly SaveFileDialog SaveFileDialog;

		#endregion

		#region File & Stream I/O

		private bool LoadFromFile(string filePath)
		{
			var result = false;
			try
			{
				var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				result = LoadFromStream(stream);
				if (result)
				{
					FilePath = filePath;
					MruController.AddItem(filePath);
				}
				stream.Close();
			}
			catch { }
			return result;
		}

		private bool LoadFromStream(Stream stream)
		{
			var result = false;
			try
			{
				Model.Files = (List<TagFile>) new BinaryFormatter().Deserialize(stream);
				Model.Modified = false;
				result = true;
			}
			catch { }
			return result;
		}

		private bool SaveToFile(string filePath)
		{
			var result = false;
			try
			{
				var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
				result = SaveToStream(stream);
				if (result)
				{
					stream.Flush();
					FilePath = filePath;
					MruController.AddItem(filePath);
				}
				stream.Close();
			}
			catch { }
			return result;
		}

		private bool SaveToStream(Stream stream)
		{
			var result = false;
			try
			{
				new BinaryFormatter().Serialize(stream, Model.Files);
				Model.Modified = false;
				result = true;
			}
			catch { }
			return result;
		}

		#endregion

		#endregion
	}
}
