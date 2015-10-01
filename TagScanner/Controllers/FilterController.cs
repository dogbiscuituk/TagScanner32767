using System;
using System.Linq;
using System.Windows.Forms;
using TagScanner.Models;
using TagScanner.Views;

namespace TagScanner.Controllers
{
	public class FilterController
	{
		#region Lifetime Management

		public FilterController(Control host)
		{
			View = new FilterEditor();
			host.Controls.Add(View);
			_filterEditControllerSimple = new FilterEditControllerSimple(View);
			_filterEditControllerSimple.ValueChanged += FilterController_ValueChanged;
			_filterEditControllerCompound = new FilterEditControllerCompound(View);
			_filterEditControllerCompound.ValueChanged += FilterController_ValueChanged;
        }

		private void FilterController_ValueChanged(object sender, EventArgs e)
		{
			SelectedNode.Text = ((FilterEditController)sender).Text;
		}

		private FilterEditControllerSimple _filterEditControllerSimple;
		private FilterEditControllerCompound _filterEditControllerCompound;

		#endregion

		#region View

		private FilterEditor _view;
		private FilterEditor View
		{
			get
			{
				return _view;
			}
			set
			{
				if (View != null)
				{
					View.TreeView.AfterSelect -= TreeView_AfterSelect;
				}
				_view = value;
				if (View != null)
				{
					View.TreeView.AfterSelect += TreeView_AfterSelect;
				}
			}
		}

		#region View Properties

		private TreeNode SelectedNode { get { return TreeView.SelectedNode; } }

		private TreeView TreeView { get { return View.TreeView; } }

		#endregion

		#endregion

		#region Control Events

		private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateEditControllers();
		}

		#endregion

		#region Condition

		public Predicate<object> Predicate
		{
			get
			{
				return null;
			}
		}

		private void UpdateEditControllers()
		{
			var text = SelectedNode.Text;
			var simple = !CompoundCondition.Quantifiers.Contains(text);
			_filterEditControllerSimple.Visible = simple;
			_filterEditControllerCompound.Visible = !simple;
			if (simple)
				_filterEditControllerSimple.Text = text;
			else
				_filterEditControllerCompound.Text = text;
		}

		#endregion
	}
}
