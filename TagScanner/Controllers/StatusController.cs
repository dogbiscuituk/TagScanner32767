using System;
using System.Windows.Forms;
using TagScanner.Model;

namespace TagScanner.Controllers
{
	public class StatusController
	{
		public StatusController(TagFileModel model, StatusStrip statusStrip)
		{
			Model = model;
			StatusBar = statusStrip.Items;
		}

		private TagFileModel Model;
        private ToolStripItemCollection StatusBar;

		public IProgress<ProgressEventArgs> NewProgress()
		{
			var progressBar = new ToolStripProgressBar();
			var cancelButton = new ToolStripSplitButton { DropDownButtonWidth = 0, Text = "Cancel" };
			cancelButton.ButtonClick += (sender, e) => ((ToolStripItem)sender).Enabled = false;
			StatusBar.AddRange(new ToolStripItem[] { progressBar, cancelButton });
			var progress = new Progress<ProgressEventArgs>((e) =>
			{
				if (e.Continue)
				{
					e.Continue = e.Index < e.Count && cancelButton.Enabled;
					if (e.Continue)
					{
						progressBar.Maximum = e.Count;
						progressBar.Value = e.Index;
						if (e.Success)
							Model.Modified = true;
						System.Diagnostics.Debug.WriteLine("{0}/{1} {2}", e.Index, e.Count, e.Path);
					}
					else
					{
						StatusBar.Remove(cancelButton);
						StatusBar.Remove(progressBar);
					}
				}
			});
			return progress;
		}
	}
}
