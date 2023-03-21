using Leopotam.Ecs;
using UnityEngine;
using Common;
using Spawners;
using Movements;
using Combat;

namespace Input {
	sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem {
		// auto-injected fields.
		private EcsWorld world = null;
		private StaticData staticData;
		private EcsFilter<PlayerFlag> playerFilter = null;
		private EcsFilter<InputFlag> inputFilter = null;

		public void Init () {
			EcsEntity input = world.NewEntity ();
			input.Get<InputFlag> ();
			input.Get<SpawnPrefab> () = new SpawnPrefab {
				Prefab = staticData.InputPrefab,
				Position = Vector3.zero,
				Rotation = Quaternion.identity,
				Parent = null
			};
		}

		public void Run () {
			if (inputFilter.GetEntity (0).IsNull ())
				return;

			ref EcsEntity inputEntity = ref inputFilter.GetEntity (0);

			foreach (int i in playerFilter) {
				ref EcsEntity playerEntity = ref playerFilter.GetEntity (i);

				if (inputEntity.Has<MovePerformedInputEvent>())
					playerEntity.Get<Velocity> ().Value = inputEntity.Get<MovePerformedInputEvent> ().Value;

				if (inputEntity.Has<MoveCanceledInputEvent> ())
					playerEntity.Get<Velocity> ().Value = inputEntity.Get<MoveCanceledInputEvent> ().Value;

				if (inputEntity.Has<MoveStartedInputEvent> ()) {
					playerEntity.Get<Velocity> ().Value = inputEntity.Get<MoveStartedInputEvent> ().Value;
					if(playerEntity.Has<GrabLedgeStateFlag>())
						playerEntity.Get<PullUpAction> ();
				}

				if (inputEntity.Has<JumpInputEvent> ())
					playerEntity.Get<JumpAction> ();

				if (inputEntity.Has<DashInputEvent> ())
					playerEntity.Get<DashAction> ();

				if (inputEntity.Has<DuckInputEvent> ())
					playerEntity.Get<DuckAction> ();

				if (inputEntity.Has<AttackInputEvent> ())
					playerEntity.Get<AttackAction> ();
			}

			inputEntity.Del<MovePerformedInputEvent> ();
			inputEntity.Del<MoveStartedInputEvent> ();
			inputEntity.Del<MoveCanceledInputEvent> ();
			inputEntity.Del<JumpInputEvent> ();
			inputEntity.Del<DashInputEvent> ();
			inputEntity.Del<DuckInputEvent> ();
			inputEntity.Del<AttackInputEvent> ();
		}
	}
}