using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagScanner.Model
{
	public class TagFileReader
	{
		public TagFileReader(IProgress<ProgressEventArgs> progress)
		{
			Progress = progress;
		}

		#region State

		public readonly List<TagFile> Files = new List<TagFile>();

		private int FileIndex, FileCount;
		private IProgress<ProgressEventArgs> Progress;

		#endregion

		public void AddFiles(IEnumerable<string> filePathList)
		{
			FileCount += filePathList.Count();
			DoAddFiles(filePathList);
		}

		public void AddFolder(string folderPath, IEnumerable<string> searchPatterns)
		{
			if (!Directory.Exists(folderPath))
				return;
			var filePathLists = new List<IEnumerable<string>>();
			foreach (var searchPattern in searchPatterns)
			{
				var filePathList = Directory.EnumerateFiles(path: folderPath, searchPattern: searchPattern, searchOption: SearchOption.AllDirectories);
				FileCount += filePathList.Count();
				filePathLists.Add(filePathList);
			}
			foreach (var filePathList in filePathLists)
				if (!DoAddFiles(filePathList))
					break;
		}

		private bool AddFile(string filePath)
		{
			var success = false;
			try
			{
				var tagFile = new TagFile(filePath);
				Files.Add(tagFile);
				FileIndex++;
				success = true;
			}
			catch (TagLib.CorruptFileException)
			{
				FileCount--;
			}
			catch (TagLib.UnsupportedFormatException)
			{
				FileCount--;
			}
			var e = new ProgressEventArgs(index: FileIndex, count: FileCount, path: filePath, success: success);
			Progress.Report(e);
			return e.Continue;
		}

		private bool DoAddFiles(IEnumerable<string> filePathList)
		{
			foreach (var filePath in filePathList)
				if (!AddFile(filePath))
					return false;
			return true;
		}
	}
}
