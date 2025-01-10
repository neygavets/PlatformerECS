using UnityEngine;

namespace GameLogic.Components.Combat
{
	struct Attack
	{
		public readonly int Damage { get => Random.Range (Min, Max); }
		public int Max;
		public int Min;
	}
}