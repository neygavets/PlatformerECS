namespace GameLogic.Components.Characters
{
	public struct CharacterCharacteristics
	{
		private int _stamina;
		private int _strength;
		private int _agility;
		private int _intellect;

		public int Stamina
		{
			get => _stamina;
			set => _stamina = value > 0 ? value : 1;
		}
		public int Strength
		{
			get => _strength;
			set => _strength = value >= 0 ? value : 0;
		}
		public int Agility
		{
			get => _agility;
			set => _agility = value >= 0 ? value : 0;
		}
		public int Intellect
		{
			get => _intellect;
			set => _intellect = value >= 0 ? value : 0;
		}
	}
}