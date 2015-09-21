using System;
using TagScanner.Model;

namespace TagScanner.Controllers
{
	public abstract class GridViewController : IGridViewController
	{
		public GridViewController(TagFileModel model)
		{
			Model = model;
		}

		private TagFileModel _model;
		public TagFileModel Model
		{
			get
			{
				return _model;
			}
			set
			{
				if (Model != null)
				{
					Model.FilesChanged -= Model_FilesChanged;
				}
				_model = value;
				if (Model != null)
				{
					Model.FilesChanged += Model_FilesChanged;
				}
			}
		}

		private void Model_FilesChanged(object sender, EventArgs e)
		{
			RefreshDataSource();
		}

		protected abstract void RefreshDataSource();

		#region Selection

		public abstract void SelectAll();
		public abstract void InvertSelection();

		private TagFileSelection _selection;
		public TagFileSelection Selection
		{
			get { return _selection ?? (_selection = GetSelection()); }
		}

		public event EventHandler SelectionChanged;

		private int UpdatingSelectionCount { get; set; }

		protected abstract TagFileSelection GetSelection();

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
