using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using TagScanner.Models;

namespace TagScanner.Controllers
{
	public abstract class GridController
	{
		#region Lifetime Management

		public GridController(Model model, Component view)
		{
			Model = model;
			View = view;
		}

		#endregion

		#region Model

		private Model _model;
		public Model Model
		{
			get
			{
				return _model;
			}
			set
			{
				if (Model != null)
				{
					Model.TracksChanged -= Model_TracksChanged;
				}
				_model = value;
				if (Model != null)
				{
					Model.TracksChanged += Model_TracksChanged;
				}
			}
		}

		private void Model_TracksChanged(object sender, EventArgs e)
		{
			InvokeRefreshDataSource();
		}

		#endregion

		#region View

		private Component _view;
		protected Component View
		{
			get
			{
				return _view;
			}
			set
			{
				if (View != null)
					DisconnectView();
				_view = value;
				if (View != null)
				{
					ReconnectView();
					InvokeRefreshDataSource();
				}
			}
		}

		protected abstract void DisconnectView();
		protected abstract void ReconnectView();

		private void InvokeRefreshDataSource()
		{
			var syncInvoke = (ISynchronizeInvoke)View;
			if (syncInvoke.InvokeRequired)
				syncInvoke.Invoke(new Action(RefreshDataSource), null);
			else
				RefreshDataSource();
        }

		protected abstract void RefreshDataSource();

		#endregion

		#region Columns

		protected object GetColumn(string propertyTypeName)
		{
			switch (propertyTypeName)
			{
				case "String":
					return GetTextBoxColumn(StringAlignment.Near);
				case "Int32":
				case "Int64":
				case "TimeSpan":
					return GetTextBoxColumn(StringAlignment.Far);
				case "Logical":
					return GetCheckBoxColumn();
			}
			return null;
		}

		protected abstract object GetCheckBoxColumn();
		protected abstract object GetTextBoxColumn(StringAlignment alignment);

		private IEnumerable<string> _visibleColumnNames = new[] { "FilePath" };
		public IEnumerable<string> VisibleColumnNames
		{
			get
			{
				return _visibleColumnNames;
			}
			set
			{
				if (VisibleColumnNames.SequenceEqual(value))
					return;
				_visibleColumnNames = value;
				InitVisibleColumns();
            }
		}

		protected abstract void InitVisibleColumns();

		#endregion

		#region Filter

		private Predicate<object> _filter = p => true;

		public Predicate<object> Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				_filter = value;
				InitFilter();
			}
		}

		protected abstract void InitFilter();

		#endregion

		#region Groups

		private IEnumerable<string> _groups = new string[0];
		public IEnumerable<string> Groups
		{
			get
			{
				return _groups;
			}
			set
			{
				if (Groups.SequenceEqual(value))
					return;
				_groups = value;
				InitGroups();
			}
		}

		protected abstract void InitGroups();

		#endregion

		#region Selection

		public abstract void SelectAll();
		public abstract void InvertSelection();

		private Selection _selection;
		public Selection Selection
		{
			get { return _selection ?? (_selection = GetSelection()); }
		}

		public event EventHandler SelectionChanged;

		private int UpdatingSelectionCount { get; set; }

		protected abstract Selection GetSelection();

		protected void InvalidateSelection()
		{
			_selection = null;
		}

		protected void BeginUpdateSelection()
		{
			UpdatingSelectionCount++;
		}

		protected void EndUpdateSelection()
		{
			UpdatingSelectionCount--;
			OnSelectionChanged();
		}

		protected virtual void OnSelectionChanged()
		{
			if (UpdatingSelectionCount == 0)
			{
				InvalidateSelection();
				var selectionChanged = SelectionChanged;
				if (selectionChanged != null)
					selectionChanged(this, EventArgs.Empty);
			}
		}

		#endregion

		#region Presets

		public void ViewByAlbumTitle()
		{
			VisibleColumnNames = new[]
			{
				"JoinedPerformers",
				"DiscTrack",
				"Title",
				"Duration",
				"FileSize"
			};
			Groups = new[]
			{
				"Album"
			};
		}

		public void ViewByArtist()
		{
			VisibleColumnNames = new[]
			{
				"DiscTrack",
				"Title",
				"Duration",
				"FileSize"
			};
			Groups = new[]
			{
				"JoinedPerformers",
				"YearAlbum"
			};
		}

		public void ViewByGenre()
		{
			VisibleColumnNames = new[]
			{
				"DiscTrack",
				"Title",
				"Duration",
				"FileSize"
			};
			Groups = new[]
			{
				"IsClassical",
				"JoinedGenres",
				"JoinedPerformers",
				"YearAlbum"
			};
		}

		public void ViewBySongTitle()
		{
			VisibleColumnNames = new[]
			{
				"Title",
				"JoinedPerformers",
				"DiscTrack",
				"Duration",
				"FileSize"
			};
			Groups = new string[0];
		}

		public void ViewByYear()
		{
			VisibleColumnNames = new[]
			{
				"DiscTrack",
				"Title",
				"Duration",
				"FileSize"
			};
			Groups = new[]
			{
				"Century",
				"Decade",
				"Year",
				"JoinedPerformers",
				"Album"
			};
		}

		#endregion
	}
}
