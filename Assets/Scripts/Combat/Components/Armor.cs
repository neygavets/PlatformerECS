namespace Combat {
    public struct Armor {
        int armor;
		public int Value {
			get => armor;
			set => armor = value >= 0 ? value : 0;
		}
	}
}