using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TagScanner.Controllers
{
	public class MruController
	{
		#region Public Interface

		public MruController(string subKeyName, ToolStripDropDownItem recentMenu, EventHandler onItemClick)
		{
			if (string.IsNullOrWhiteSpace(subKeyName))
				throw new ArgumentNullException("subKeyName");
			if (recentMenu == null)
				throw new ArgumentNullException("parentMenuItem");
			if (onItemClick == null)
				throw new ArgumentNullException("onItemClick");
			SubKeyName = string.Concat(@"Software\", subKeyName);
			RecentMenu = recentMenu;
			OnItemClick = onItemClick;
			RefreshRecentMenu();
		}

		public void AddItem(string item)
		{
			try
			{
				var key = CreateSubKey();
				if (key == null)
					return;
				try
				{
					for (int index = 0; ; index++)
					{
						var name = index.ToString();
						var value = key.GetValue(name, null) as string;
						if (value == null)
						{
							key.SetValue(name, item);
							break;
						}
						if (value == item)
							break;
					}
				}
				finally
				{
					key.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			RefreshRecentMenu();
		}

		public void RemoveItem(string item)
		{
			try
			{
				var key = OpenSubKey(true);
				if (key == null)
					return;
				try
				{
					foreach (var name in key.GetValueNames())
						if ((key.GetValue(name, null) as string) == item)
						{
							key.DeleteValue(name, true);
							break;
						}
				}
				finally
				{
					key.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			RefreshRecentMenu();
		}

		#endregion

		#region Private Implementation

		private string SubKeyName;
		private ToolStripDropDownItem RecentMenu;
		private EventHandler OnItemClick;

		private void OnRecentClear_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey key = OpenSubKey(true);
				if (key == null)
					return;
				foreach (string name in key.GetValueNames())
					key.DeleteValue(name, true);
				key.Close();
				RecentMenu.DropDownItems.Clear();
				RecentMenu.Enabled = false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		
		private void RefreshRecentMenu()
		{
			bool ok = false;
			try
			{
				var key = OpenSubKey(false);
				ok = key != null;
				if (ok)
				{
					var items = RecentMenu.DropDownItems;
					items.Clear();
					foreach (var name in key.GetValueNames())
					{
						var value = key.GetValue(name, null) as string;
						if (value == null)
							continue;
						var parts = value.Split('|');
						var item = items.Add(parts[0].AmpersandEscape());
						item.ToolTipText = parts[parts.Length - 1];
						item.Click += OnItemClick;
					}
					ok = items.Count > 0;
					if (ok)
					{
						items.Add("-");
						items.Add("Clear this list").Click += OnRecentClear_Click;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to open registry key.\n" + ex.ToString());
			}
			RecentMenu.Enabled = ok;
		}

		private RegistryKey CreateSubKey()
		{
			return Registry.CurrentUser.CreateSubKey(SubKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
		}

		private RegistryKey OpenSubKey(bool writable)
		{
			return Registry.CurrentUser.OpenSubKey(SubKeyName, writable);
		}

		#endregion
	}
}
