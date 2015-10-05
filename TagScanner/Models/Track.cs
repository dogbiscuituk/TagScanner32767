using System;
using System.IO;
using System.Linq;

namespace TagScanner.Models
{
	[Serializable]
	public class Track : ITrack
	{
		#region Public Interface

		#region Constructor

		public Track(string filePath)
		{
			ReadMetadata(filePath);
			using (var file = TagLib.File.Create(filePath))
				ReadFile(file);
		}

		#endregion

		#region Properties

		public bool IsModified { get; set; }

		#endregion

		#region ITrack

		private string _album;
		public string Album
		{
			get { return _album; }
			set { SetValue(p => p.Album = value); }
		}

		private string[] _albumArtists;
		public string[] AlbumArtists
		{
			get { return _albumArtists; }
			set { SetValue(p => p.AlbumArtists = value); }
		}

		private string[] _albumArtistsSort;
		public string[] AlbumArtistsSort
		{
			get { return _albumArtistsSort; }
			set { SetValue(p => p.AlbumArtistsSort = value); }
		}

		public string AlbumIndex
		{
			get { return AlbumSort.Coalesce(Album).GetIndex(); }
		}

		private string _albumSort;
		public string AlbumSort
		{
			get { return _albumSort; }
			set { SetValue(p => p.AlbumSort = value); }
		}

		private string _amazonId;
		public string AmazonId
		{
			get { return _amazonId; }
			set { SetValue(p => p.AmazonId = value); }
		}

		private string[] _artists;
		public string[] Artists
		{
			get { return _artists; }
#pragma warning disable 612,618
			set { SetValue(p => p.Artists = value); }
#pragma warning restore 612,618
		}

		private int _audioBitrate;
		public int AudioBitrate
		{
			get { return _audioBitrate; }
		}

		private int _audioChannels;
		public int AudioChannels
		{
			get { return _audioChannels; }
		}

		private int _audioSampleRate;
		public int AudioSampleRate
		{
			get { return _audioSampleRate; }
		}

		private int _beatsPerMinute;
		public int BeatsPerMinute
		{
			get { return _beatsPerMinute; }
			set { SetValue(p => p.BeatsPerMinute = (uint)value); }
		}

		private int _bitsPerSample;
		public int BitsPerSample
		{
			get { return _bitsPerSample; }
		}

		public string Century
		{
			get { return Year > 0 ? ((long)(Year + 99) / 100).AsOrdinal() : string.Empty; }
		}

		public string Codecs { get; private set; }

		private string _comment;
		public string Comment
		{
			get { return _comment; }
			set { SetValue(p => p.Comment = value); }
		}

		private string[] _composers;
		public string[] Composers
		{
			get { return _composers; }
			set { SetValue(p => p.Composers = value); }
		}

		private string[] _composersSort;
		public string[] ComposersSort
		{
			get { return _composersSort; }
			set { SetValue(p => p.ComposersSort = value); }
		}

		private string _conductor;
		public string Conductor
		{
			get { return _conductor; }
			set { SetValue(p => p.Conductor = value); }
		}

		private string _copyright;
		public string Copyright
		{
			get { return _copyright; }
			set { SetValue(p => p.Copyright = value); }
		}

		public string Decade
		{
			get { return Year > 0 ? string.Format("{0}0s", Year / 10) : string.Empty; }
		}

		private string _description;
		public string Description
		{
			get { return _description; }
		}

		private int _discCount;
		public int DiscCount
		{
			get { return _discCount; }
			set { SetValue(p => p.DiscCount = (uint)value); }
		}

		private int _discNo;
		public int DiscNumber
		{
			get { return _discNo; }
			set { SetValue(p => p.Disc = (uint)value); }
		}

		public string DiscOf
		{
			get { return IndexOfCount(_discNo, _discCount); }
		}

		public string DiscTrack
		{
			get
			{
				var discOf = DiscOf;
				if (discOf == null)
					return null;
				var trackOf = TrackOf;
				if (trackOf == null)
					return null;
				return
					discOf == "1/1"
						? TrackOf
						: string.Format("{0} - {1}", discOf, trackOf);
			}
		}

		private TimeSpan _duration;
		public TimeSpan Duration
		{
			get { return _duration; }
		}

		public FileAttributes FileAttributes { get; private set; }

		private DateTime _fileCreationTime;
		public DateTime FileCreationTime
		{
			get { return _fileCreationTime; }
		}

		private DateTime _fileCreationTimeUtc;
		public DateTime FileCreationTimeUtc
		{
			get { return _fileCreationTimeUtc; }
		}

		public string FileExtension
		{
			get { return Path.GetExtension(FilePath); }
		}

		private DateTime _fileLastAccessTime;
		public DateTime FileLastAccessTime
		{
			get { return _fileLastAccessTime; }
		}

		private DateTime _fileLastAccessTimeUtc;
		public DateTime FileLastAccessTimeUtc
		{
			get { return _fileLastAccessTimeUtc; }
		}

		private DateTime _fileLastWriteTime;
		public DateTime FileLastWriteTime
		{
			get { return _fileLastWriteTime; }
		}

		private DateTime _fileLastWriteTimeUtc;
		public DateTime FileLastWriteTimeUtc
		{
			get { return _fileLastWriteTimeUtc; }
		}

		private long _fileLength;
		public long FileLength
		{
			get { return _fileLength; }
		}

		public string FileName
		{
			get { return Path.GetFileName(FilePath); }
		}

		public string FileNameWithoutExtension
		{
			get { return Path.GetFileNameWithoutExtension(FilePath); }
		}

		public string FilePath { get; private set; }

		private long _fileSize;
		public long FileSize
		{
			get { return _fileSize; }
		}

		public string FirstAlbumArtist { get; private set; }
		public string FirstAlbumArtistSort { get; private set; }
		public string FirstArtist { get; private set; }
		public string FirstComposer { get; private set; }
		public string FirstComposerSort { get; private set; }
		public string FirstGenre { get; private set; }
		public string FirstPerformer { get; private set; }
		public string FirstPerformerSort { get; private set; }

		private string[] _genres;
		public string[] Genres
		{
			get { return _genres; }
			set { SetValue(p => p.Genres = value); }
		}

		private string _grouping;
		public string Grouping
		{
			get { return _grouping; }
			set { SetValue(p => p.Grouping = value); }
		}

		private long _invariantEndPosition;
		public long InvariantEndPosition
		{
			get { return _invariantEndPosition; }
		}

		private long _invariantStartPosition;
		public long InvariantStartPosition
		{
			get { return _invariantStartPosition; }
		}

		public Logical IsClassical
		{
			get { return (FirstGenre == "Classical").AsLogical(); }
		}

		private bool _isEmpty;
		public Logical IsEmpty
		{
			get { return _isEmpty.AsLogical(); }
		}

		public string JoinedAlbumArtists { get; private set; }
		public string JoinedArtists { get; private set; }
		public string JoinedComposers { get; private set; }
		public string JoinedGenres { get; private set; }
		public string JoinedPerformers { get; private set; }

		public string JoinedPerformersIndex
		{
			get { return JoinedPerformersSort.Coalesce(JoinedPerformers).GetIndex(); }
		}

		public string JoinedPerformersSort { get; private set; }

		private long _length;
		public long Length
		{
			get { return _length; }
		}

		private string _lyrics;
		public string Lyrics
		{
			get { return _lyrics; }
			set { SetValue(p => p.Lyrics = value); }
		}

		private TagLib.MediaTypes _mediaTypes;
		public TagLib.MediaTypes MediaTypes
		{
			get { return _mediaTypes; }
		}

		public string Millennium
		{
			get { return Year > 0 ? ((long)(Year + 999) / 1000).AsOrdinal() : string.Empty; }
		}

		public string MimeType { get; private set; }

		private string _musicBrainzArtistId;
		public string MusicBrainzArtistId
		{
			get { return _musicBrainzArtistId; }
			set { SetValue(p => p.MusicBrainzArtistId = value); }
		}

		private string _musicBrainzDiscId;
		public string MusicBrainzDiscId
		{
			get { return _musicBrainzDiscId; }
			set { SetValue(p => p.MusicBrainzDiscId = value); }
		}

		private string _musicBrainzReleaseArtistId;
		public string MusicBrainzReleaseArtistId
		{
			get { return _musicBrainzReleaseArtistId; }
			set { SetValue(p => p.MusicBrainzReleaseArtistId = value); }
		}

		private string _musicBrainzReleaseCountry;
		public string MusicBrainzReleaseCountry
		{
			get { return _musicBrainzReleaseCountry; }
			set { SetValue(p => p.MusicBrainzReleaseCountry = value); }
		}

		private string _musicBrainzReleaseId;
		public string MusicBrainzReleaseId
		{
			get { return _musicBrainzReleaseId; }
			set { SetValue(p => p.MusicBrainzReleaseId = value); }
		}

		private string _musicBrainzReleaseStatus;
		public string MusicBrainzReleaseStatus
		{
			get { return _musicBrainzReleaseStatus; }
			set { SetValue(p => p.MusicBrainzReleaseStatus = value); }
		}

		private string _musicBrainzReleaseType;
		public string MusicBrainzReleaseType
		{
			get { return _musicBrainzReleaseType; }
			set { SetValue(p => p.MusicBrainzReleaseType = value); }
		}

		private string _musicBrainzTrackId;
		public string MusicBrainzTrackId
		{
			get { return _musicBrainzTrackId; }
			set { SetValue(p => p.MusicBrainzTrackId = value); }
		}

		private string _musicIpId;
		public string MusicIpId
		{
			get { return _musicIpId; }
			set { SetValue(p => p.MusicIpId = value); }
		}

		public string Name { get; private set; }

		private string[] _performers;
		public string[] Performers
		{
			get { return _performers; }
			set { SetValue(p => p.Performers = value); }
		}

		private string[] _performersSort;
		public string[] PerformersSort
		{
			get { return _performersSort; }
			set { SetValue(p => p.PerformersSort = value); }
		}

		private int _photoHeight;
		public int PhotoHeight
		{
			get { return _photoHeight; }
		}

		private int _photoQuality;
		public int PhotoQuality
		{
			get { return _photoQuality; }
		}

		private int _photoWidth;
		public int PhotoWidth
		{
			get { return _photoWidth; }
		}

		private int _pictureCount;
		public int PictureCount
		{
			get
			{
				return _pictureCount;
			}
		}

		private Picture[] _pictures;
		public Picture[] Pictures
		{
			get { return _pictures; }
		}

		private bool _possiblyCorrupt;
		public Logical PossiblyCorrupt
		{
			get { return _possiblyCorrupt.AsLogical(); }
		}

		private TagLib.TagTypes _tagTypes;
		public TagLib.TagTypes TagTypes
		{
			get { return _tagTypes; }
		}

		private TagLib.TagTypes _tagTypesOnDisk;
		public TagLib.TagTypes TagTypesOnDisk
		{
			get { return _tagTypesOnDisk; }
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetValue(p => p.Title = value); }
		}

		public string TitleIndex
		{
			get { return TitleSort.Coalesce(Title).GetIndex(); }
		}

		private string _titleSort;
		public string TitleSort
		{
			get { return _titleSort; }
			set { SetValue(p => p.TitleSort = value); }
		}

		private int _trackCount;
		public int TrackCount
		{
			get { return _trackCount; }
			set { SetValue(p => p.TrackCount = (uint)value); }
		}

		private int _trackNo;
		public int TrackNumber
		{
			get { return _trackNo; }
			set { SetValue(p => p.Track = (uint)value); }
		}

		public string TrackOf
		{
			get { return IndexOfCount(_trackNo, _trackCount); }
		}

		private int _videoHeight;
		public int VideoHeight
		{
			get { return _videoHeight; }
		}

		private int _videoWidth;
		public int VideoWidth
		{
			get { return _videoWidth; }
		}

		private int _year;
		public int Year
		{
			get { return _year; }
			set { SetValue(p => p.Year = (uint)value); }
		}

		public string YearAlbum
		{
			get { return string.Format("{0} - {1}", Year, Album); }
		}

		#endregion

		#region Methods

		public void Save()
		{
			//_file.Save();
			IsModified = false;
		}

		public override string ToString()
		{
			return string.Format(
				"{0} | {1} | {2} {3} ({4}) {5}",
				JoinedPerformers,
				YearAlbum,
				TrackOf,
				Title,
				((TimeSpan)Duration).AsString(false),
				((long)FileSize).AsString(true));
		}

		#endregion

		#endregion

		#region Private Implementation

		private static string IndexOfCount(int index, int count)
		{
			index = Math.Max(index, 1);
			return string.Format("{0}/{1}", index, Math.Max(count, index));
		}

		private void ReadFile(TagLib.File file)
		{
			if (file == null)
				return;
			_fileLength = file.Length;
			_invariantEndPosition = file.InvariantEndPosition;
			_invariantStartPosition = file.InvariantStartPosition;
			_length = file.Length;
			MimeType = file.MimeType;
			Name = file.Name;
			_possiblyCorrupt = file.PossiblyCorrupt;
			_tagTypes = file.TagTypes;
			_tagTypesOnDisk = file.TagTypesOnDisk;
			ReadProperties(file.Properties);
			ReadTag(file.Tag);
		}

		private void ReadMetadata(string filePath)
		{
			FilePath = filePath;
			_fileSize = new FileInfo(filePath).Length;
			FileAttributes = File.GetAttributes(filePath);
			_fileCreationTime = File.GetCreationTimeUtc(filePath);
			_fileLastWriteTime = File.GetLastWriteTimeUtc(filePath);
			_fileLastAccessTime = File.GetLastAccessTimeUtc(filePath);
			_fileCreationTimeUtc = File.GetCreationTimeUtc(filePath);
			_fileLastWriteTimeUtc = File.GetLastWriteTimeUtc(filePath);
			_fileLastAccessTimeUtc = File.GetLastAccessTimeUtc(filePath);
		}

		private void ReadProperties(TagLib.Properties properties)
		{
			if (properties == null)
				return;
			_audioBitrate = properties.AudioBitrate;
			_audioChannels = properties.AudioChannels;
			_audioSampleRate = properties.AudioSampleRate;
			_bitsPerSample = properties.BitsPerSample;
			Codecs = properties.Codecs.ToString();
			_description = properties.Description;
			_duration = properties.Duration;
			_mediaTypes = properties.MediaTypes;
			_photoHeight = properties.PhotoHeight;
			_photoQuality = properties.PhotoQuality;
			_photoWidth = properties.PhotoWidth;
			_videoHeight = properties.VideoHeight;
			_videoWidth = properties.VideoWidth;
		}

		private void ReadTag(TagLib.Tag tag)
		{
			if (tag == null)
				return;
			_album = tag.Album;
			_albumArtists = tag.AlbumArtists;
			_albumArtistsSort = tag.AlbumArtistsSort;
			_albumSort = tag.AlbumSort;
			_amazonId = tag.AmazonId;
#pragma warning disable 612,618
			_artists = tag.Artists;
#pragma warning restore 612, 618
			_beatsPerMinute = (int)tag.BeatsPerMinute;
			_comment = tag.Comment;
			_composers = tag.Composers;
			_composersSort = tag.ComposersSort;
			_conductor = tag.Conductor;
			_copyright = tag.Copyright;
			_discNo = (int)tag.Disc;
			_discCount = (int)tag.DiscCount;
			FirstAlbumArtist = tag.FirstAlbumArtist;
			FirstAlbumArtistSort = tag.FirstAlbumArtistSort;
#pragma warning disable 612,618
			FirstArtist = tag.FirstArtist;
#pragma warning restore 612,618
			FirstComposer = tag.FirstComposer;
			FirstComposerSort = tag.FirstComposerSort;
			FirstGenre = tag.FirstGenre;
			FirstPerformer = tag.FirstPerformer;
			FirstPerformerSort = tag.FirstPerformerSort;
			_genres = tag.Genres;
			_grouping = tag.Grouping;
			_isEmpty = tag.IsEmpty;
			JoinedAlbumArtists = tag.JoinedAlbumArtists;
#pragma warning disable 612,618
			JoinedArtists = tag.JoinedArtists;
#pragma warning restore 612,618
			JoinedComposers = tag.JoinedComposers;
			JoinedGenres = tag.JoinedGenres;
			JoinedPerformers = tag.JoinedPerformers;
			JoinedPerformersSort = tag.JoinedPerformersSort;
			_lyrics = tag.Lyrics;
			_musicBrainzArtistId = tag.MusicBrainzArtistId;
			_musicBrainzDiscId = tag.MusicBrainzDiscId;
			_musicBrainzReleaseArtistId = tag.MusicBrainzReleaseArtistId;
			_musicBrainzReleaseCountry = tag.MusicBrainzReleaseCountry;
			_musicBrainzReleaseId = tag.MusicBrainzReleaseId;
			_musicBrainzReleaseStatus = tag.MusicBrainzReleaseStatus;
			_musicBrainzReleaseType = tag.MusicBrainzReleaseType;
			_musicBrainzTrackId = tag.MusicBrainzTrackId;
			_musicIpId = tag.MusicIpId;
			_performers = tag.Performers;
			_performersSort = tag.PerformersSort;
			_pictureCount = tag.Pictures.Length;
			var pictureIndex = 0;
			_pictures = tag.Pictures.Select(q => new Picture(FilePath, pictureIndex++, q)).ToArray();
			_title = tag.Title;
			_titleSort = tag.TitleSort;
			_trackNo = (int)tag.Track;
			_trackCount = (int)tag.TrackCount;
			_year = (int)tag.Year;
		}

		private void SetValue(Action<TagLib.Tag> setValue)
		{
			//setValue(Tag);
			IsModified = true;
		}

		#endregion
	}
}
