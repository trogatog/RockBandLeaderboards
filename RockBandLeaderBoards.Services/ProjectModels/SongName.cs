namespace RockBandLeaderBoards.Services
{
	public class SongName
	{
		private short _rating;
		private short _difficultyVocals;
		private short _difficultyGuitar;
		private short _difficultyProGuitar;
		private short _difficultyDrums;
		private short _difficultyProDrums;
		private short _difficultyBass;
		private short _difficultyProBass;
		private short _difficultyKeys;
		private short _difficultyProKeys;
		private short _difficultyBand;
		private short _vocalParts;
		private int _yearReleased;
		
		public int? Id { get; set; }

		public string ShortName { get; set; }

		public string Artist { get; set; }

		public string Artist_Tr { get; set; }

		public string Name { get; set; }

		public string Name_Tr { get; set; }

		public string Genre_Symbol { get; set; }

		public string Source { get; set; }

		public short Rating 
		{
			get { return _rating; }
			set {_rating = (short) (value < 0 ? 0 : value);}
		}

		public short Difficulty_Vocals
		{
			get { return _difficultyVocals; }
			set { _difficultyVocals = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Guitar
		{
			get { return _difficultyGuitar; }
			set { _difficultyGuitar = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Pro_Guitar
		{
			get { return _difficultyProGuitar; }
			set { _difficultyProGuitar = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Drums
		{
			get { return _difficultyDrums; }
			set { _difficultyDrums = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Pro_Drums
		{
			get { return _difficultyProDrums; }
			set { _difficultyProDrums = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Keys
		{
			get { return _difficultyKeys; }
			set { _difficultyKeys = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Pro_Keys
		{
			get { return _difficultyProKeys; }
			set { _difficultyProKeys = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Bass
		{
			get { return _difficultyBass; }
			set { _difficultyBass = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Pro_Bass
		{
			get { return _difficultyProBass; }
			set { _difficultyProBass = (short)(value < 0 ? 0 : value); }
		}

		public short Difficulty_Band
		{
			get { return _difficultyBand; }
			set { _difficultyBand = (short)(value < 0 ? 0 : value); }
		}

		public short Vocal_Parts
		{
			get { return _vocalParts; }
			set { _vocalParts = (short)(value < 0 ? 0 : value); }
		}

		public int? Year_Released
		{
			get { return _yearReleased; }
			set { _yearReleased = value ?? 1900; }
		}

		public string Decade { get; set; }

		public char Starts_With { get; set; }

		public string Cover { get; set; }

		public string DisplayName { get; set; }
	}
}
