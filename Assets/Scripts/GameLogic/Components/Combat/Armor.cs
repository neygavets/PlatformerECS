namespace GameLogic.Components.Combat
{
	public struct Armor
	{
		int _armor;

		public int Value
		{
			get => _armor;
			set => _armor = value >= 0 ? value : 0;
		}
	}
}