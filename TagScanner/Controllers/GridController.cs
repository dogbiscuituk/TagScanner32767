using System;
using System.Collections.Generic;
using System.Reflection;
using TagScanner.Models;

namespace TagScanner.Controllers
{
	public abstract class GridController
	{
		#region Lifetime Management

		public GridController(Model model)
		{
			Model = model;
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
			RefreshDataSource();
		}

		protected abstract void RefreshDataSource();

		#endregion

		#region Columns

		protected static readonly PropertyInfo[] PropertyInfos = typeof(ITrack).GetProperties();

		private IEnumerable<string> _visibleColumnNames;
		public IEnumerable<string> VisibleColumnNames
		{
			get { return _visibleColumnNames; }
			set
			{
			}
		}

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
	}
}
