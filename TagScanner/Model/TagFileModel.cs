using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TagScanner.Model
{
	[Serializable]
	public class TagFileModel
	{
		#region Public Interface

		public List<TagFile> Files
		{
			get
			{
				return _files;
			}
			set
			{
				_files = value;
				OnFilesChanged();
			}
		}

		private bool _modified;
		public bool Modified
		{
			get
			{
				return _modified;
			}
			set
			{
				if (Modified != value)
				{
					_modified = value;
					OnModifiedChanged();
				}
			}
		}

		public event EventHandler ModifiedChanged;

		protected virtual void OnModifiedChanged()
		{
			var modifiedChanged = ModifiedChanged;
			if (modifiedChanged != null)
				modifiedChanged(this, EventArgs.Empty);
        }

		public Order[] Orders
		{
			get { return _orders; }
			set { _orders = value; Sort(); }
		}

		public void ToggleOrder(string propertyName)
		{
			var newOrder = new Order(propertyName);
			if (Orders.Length == 1)
			{
				var oldOrder = Orders[0];
				if (oldOrder.PropertyName == propertyName)
					newOrder.Descending = !oldOrder.Descending;
			}
			Orders = new[] { newOrder };
		}

		public void Clear()
		{
			_files.Clear();
			OnFilesChanged();
		}

		public int AddFiles(string[] filePaths, IProgress<ProgressEventArgs> progress)
		{
			return ReadFiles(p => p.AddFiles(filePaths), progress);
		}

		public int AddFolder(string folderPath, string filter, IProgress<ProgressEventArgs> progress)
		{
			return ReadFiles(p => p.AddFolder(folderPath, filter.Split(';')), progress);
		}

		public event EventHandler FilesChanged;

		#endregion

		#region Private Implementation

		private List<TagFile> _files = new List<TagFile>();

		private Order[] _orders = new[]
		{
			/*new Order("JoinedPerformers"),
			new Order("Year"),
			new Order("Album"),
			new Order("Disc"),
			new Order("Track")*/

			new Order("YearAlbum"),
			new Order("Disc"),
			new Order("Track")

		};

		protected virtual void OnFilesChanged()
		{
			var filesChanged = FilesChanged;
			if (filesChanged != null)
				FilesChanged(this, EventArgs.Empty);
		}

		private int ReadFiles(Action<TagFileReader> run, IProgress<ProgressEventArgs> progress)
		{
			var reader = new TagFileReader(progress);
			run(reader);
			var newFiles = reader.Files;
			_files.AddRange(newFiles);
			Sort();
			return newFiles.Count;
		}

		private void Sort()
		{
			if (_files.Any() && Orders != null && Orders.Any())
			{
				var files = Orders[0].ApplyFirst(_files);
				for (var index = 1; index < Orders.Length; index++)
					files = Orders[index].ApplyNext(files);
				_files = files.ToList();
			}
			OnFilesChanged();
		}

		private void GroupFiles1()
		{
			string z;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int n = 0; n < 10; n++)
			{
				var groupedFiles1 =
				_files
					.GroupBy(p => new { p.Millennium, p.Century, p.Decade, p.Year, p.JoinedPerformers, p.Album })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century, p.Key.Decade, p.Key.Year, p.Key.JoinedPerformers })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century, p.Key.Decade, p.Key.Year })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century, p.Key.Decade })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century })
					.GroupBy(p => p.Key.Millennium);
				foreach (var a in groupedFiles1)
					foreach (var b in a)
						foreach (var c in b)
							foreach (var d in c)
								foreach (var e in d)
									foreach (var f in e)
										foreach (var g in f)
											z = g.ToString();
				Debug.Write("> ");
			}
			stopwatch.Stop();
			Debug.WriteLine("Method One: " + stopwatch.Elapsed);
		}

		private void GroupFiles2()
		{
			string z;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int n = 0; n < 10; n++)
			{
				var groupedFiles2 =
					_files
					.GroupBy(p => p.Millennium)
					.Select(q => q.GroupBy(p => p.Century)
						.Select(r => r.GroupBy(p => p.Decade)
						.Select(s => s.GroupBy(p => p.Year)
						.Select(t => t.GroupBy(p => p.JoinedPerformers)
						.Select(u => u.GroupBy(p => p.Album)
						)))));
				foreach (var a in groupedFiles2)
					foreach (var b in a)
						foreach (var c in b)
							foreach (var d in c)
								foreach (var e in d)
									foreach (var f in e)
										foreach (var g in f)
											z = g.ToString();
				Debug.Write("> ");
			}
			stopwatch.Stop();
			Debug.WriteLine("Method Two: " + stopwatch.Elapsed);
		}

		#endregion
	}
}
