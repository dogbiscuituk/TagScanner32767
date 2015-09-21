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

		public PersistenceController(TagFileModel model, Control view, ToolStripDropDownItem recentMenu, EventHandler onItemClick)
		{
			Model = model;
			View = view;
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

		public string WindowCaption
		{
			get
			{
				var text = Path.GetFileNameWithoutExtension(FilePath);
				if (string.IsNullOrWhiteSpace(text))
					text = "(untitled)";
				var modified = Model.Modified;
				if (modified)
					text = string.Concat("* ", text);
				text = string.Concat(text, " - ", Application.ProductName);
				return text;
			}
		}

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

		private readonly TagFileModel Model;
		private readonly Control View;
		private readonly MruController MruController;
		private readonly OpenFileDialog OpenFileDialog;
		private readonly SaveFileDialog SaveFileDialog;

		private string _filePath = string.Empty;
		public string FilePath
		{
			get
			{
				return _filePath;
			}
			private set
			{
				if (FilePath != value)
				{
					_filePath = value;
					OnFilePathChanged();
				}
			}
		}

		public event EventHandler FilePathChanged;

		protected virtual void OnFilePathChanged()
		{
			var filePathChanged = FilePathChanged;
			if (filePathChanged != null)
				filePathChanged(this, EventArgs.Empty);
        }

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
			return UseStream(() => Model.Files = (List<TagFile>)new BinaryFormatter().Deserialize(stream));
		}

		private bool SaveToFile(string filePath)
		{
			var result = false;
			try
			{
				using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
				{
					result = SaveToStream(stream);
					if (result)
					{
						stream.Flush();
						FilePath = filePath;
						MruController.AddItem(filePath);
					}
				}
			}
			catch { }
			return result;
		}

		private bool SaveToStream(Stream stream)
		{
			return UseStream(() => new BinaryFormatter().Serialize(stream, Model.Files));
		}

		private bool UseStream(Action action)
		{
			var result = true;
			var cursorController = new CursorController(View);
			cursorController.BeginWait();
			try
			{
				action();
				Model.Modified = false;
			}
			catch
			{
				result = false;
			}
			finally
			{
				cursorController.EndWait();
			}
			return result;
		}

		#endregion

		#endregion
	}
}
