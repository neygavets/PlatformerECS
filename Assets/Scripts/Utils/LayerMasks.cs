using UnityEngine;
using Leopotam.Ecs;
using GameLogic.Components.Characters;

namespace Utils
{
	/// <summary>
	/// Дополнительные игровые слои
	/// </summary>
	public static class LayerMasks
	{
		public static LayerMask Wall = LayerMask.GetMask ("Wall");
		public static LayerMask Ground = LayerMask.GetMask ("Ground", "Wall");
		public static LayerMask Stair = LayerMask.GetMask ("Stair");
		public static LayerMask Player = LayerMask.GetMask ("Hero");
		public static LayerMask Enemy = LayerMask.GetMask ("Enemy");

		public static LayerMask GetOwnerMask ( EcsEntity owner )
		{
			if (owner.Has<PlayerFlag> ())
				return LayerMask.NameToLayer ("PlayerProjectile");
			if (owner.Has<EnemyFlag> ())
				return LayerMask.NameToLayer ("EnemyProjectile");
			return 0;
		}
	}
}