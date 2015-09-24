using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TagScanner.Models
{
	[Serializable]
	public class Model
	{
		#region Public Interface

		public List<Track> Tracks
		{
			get
			{
				return _tracks;
			}
			set
			{
				_tracks = value;
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
			_tracks.Clear();
			OnFilesChanged();
		}

		public int AddFiles(string[] filePaths, IProgress<ProgressEventArgs> progress)
		{
			return ReadTracks(p => p.AddFiles(filePaths), progress);
		}

		public int AddFolder(string folderPath, string filter, IProgress<ProgressEventArgs> progress)
		{
			return ReadTracks(p => p.AddFolder(folderPath, filter.Split(';')), progress);
		}

		public event EventHandler TracksChanged;

		#endregion

		#region Private Implementation

		private List<Track> _tracks = new List<Track>();

		private Order[] _orders = new[]
		{
			/*new Order("JoinedPerformers"),
			new Order("Year"),
			new Order("Album"),
			new Order("DiscNumber"),
			new Order("TrackNumber")*/

			new Order("YearAlbum"),
			new Order("DiscNumber"),
			new Order("TrackNumber")

		};

		protected virtual void OnFilesChanged()
		{
			var filesChanged = TracksChanged;
			if (filesChanged != null)
				TracksChanged(this, EventArgs.Empty);
		}

		private int ReadTracks(Action<Reader> run, IProgress<ProgressEventArgs> progress)
		{
			var reader = new Reader(progress);
			run(reader);
			var newTracks = reader.Files;
			_tracks.AddRange(newTracks);
			Sort();
			return newTracks.Count;
		}

		private void Sort()
		{
			if (_tracks.Any() && Orders != null && Orders.Any())
			{
				var tracks = Orders[0].ApplyFirst(_tracks);
				for (var index = 1; index < Orders.Length; index++)
					tracks = Orders[index].ApplyNext(tracks);
				_tracks = tracks.ToList();
			}
			OnFilesChanged();
		}

		private void GroupTracks1()
		{
			string z;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int n = 0; n < 10; n++)
			{
				var groupedTracks1 =
				_tracks
					.GroupBy(p => new { p.Millennium, p.Century, p.Decade, p.Year, p.JoinedPerformers, p.Album })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century, p.Key.Decade, p.Key.Year, p.Key.JoinedPerformers })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century, p.Key.Decade, p.Key.Year })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century, p.Key.Decade })
					.GroupBy(p => new { p.Key.Millennium, p.Key.Century })
					.GroupBy(p => p.Key.Millennium);
				foreach (var a in groupedTracks1)
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

		private void GroupTracks2()
		{
			string z;
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int n = 0; n < 10; n++)
			{
				var groupedTracks2 =
					_tracks
					.GroupBy(p => p.Millennium)
					.Select(q => q.GroupBy(p => p.Century)
						.Select(r => r.GroupBy(p => p.Decade)
						.Select(s => s.GroupBy(p => p.Year)
						.Select(t => t.GroupBy(p => p.JoinedPerformers)
						.Select(u => u.GroupBy(p => p.Album)
						)))));
				foreach (var a in groupedTracks2)
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
