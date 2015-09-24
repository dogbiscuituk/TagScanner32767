using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using TagScanner.Model;
using TagScanner.Views;

namespace TagScanner.Controllers
{
	public class GridViewControllerWPF : GridViewController
	{
		private ElementHost GridContainerHost;

		public GridViewControllerWPF(TagFileModel model, ElementHost gridContainerHost) : base(model)
		{
			GridContainerHost = gridContainerHost;
			GridContainerHost.Child = new GridContainer();
		}

		#region File processing

		protected override void RefreshDataSource()
		{
			if (GridContainerHost.InvokeRequired)
				GridContainerHost.Invoke(new MethodInvoker(RefreshDataSource));
			else
			{
				var files = Model.Files;
				((GridContainer)GridContainerHost.Child).DataGrid.ItemsSource = new ObservableCollection<ITagFile>(files);
			}
		}

		#endregion

		#region Selection

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}

		public override void InvertSelection()
		{
			throw new NotImplementedException();
		}

		protected override TagFileSelection GetSelection()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
