﻿using System;
using System.Windows.Forms;
using TagScanner.Models;

namespace TagScanner.Controllers
{
	public class StatusController
	{
		public StatusController(Model model, StatusStrip statusStrip)
		{
			Model = model;
			StatusBar = statusStrip.Items;
		}

		private Model Model;
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
