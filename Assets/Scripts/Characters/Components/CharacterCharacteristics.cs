namespace Characters {
    public struct CharacterCharacteristics {
		int stamina;
		int strength;
		int agility;
		int intellect;

		public int Stamina {
			get => stamina;
			set => stamina = value > 0 ? value : 1;
		}
		public int Strength {
			get => strength;
			set => strength = value >= 0 ? value : 0;
		}
		public int Agility {
			get => agility;
			set => agility = value >= 0 ? value : 0;
		}
		public int Intellect {
			get => intellect;
			set => intellect = value >= 0 ? value : 0;
		}
	}
}