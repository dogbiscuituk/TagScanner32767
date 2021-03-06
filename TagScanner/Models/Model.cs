﻿using System;
using System.Collections.Generic;
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
				OnTracksChanged();
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
			OnTracksChanged();
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
			new Order("YearAlbum"),
			new Order("DiscNumber"),
			new Order("TrackNumber")
		};

		protected virtual void OnTracksChanged()
		{
			var tracksChanged = TracksChanged;
			if (tracksChanged != null)
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
			OnTracksChanged();
		}

		#endregion
	}
}
