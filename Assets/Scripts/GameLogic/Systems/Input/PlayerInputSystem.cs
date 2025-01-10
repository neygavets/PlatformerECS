using Leopotam.Ecs;
using UnityEngine;
using GameLogic.Components.Spawners;
using GameLogic.Components.Movements;
using GameLogic.Components.Combat;
using GameLogic.Components.Characters;
using GameLogic.Components.Input;
using GameLogic.Models;

namespace GameLogic.Systems.Input
{
	sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
	{
		// auto-injected fields.
		private EcsWorld _world = null;
		private GameData _staticData;
		private EcsFilter<PlayerFlag> _playerFilter = null;
		private EcsFilter<InputFlag> _inputFilter = null;

		public void Init ()
		{
			EcsEntity input = _world.NewEntity ();
			input.Get<InputFlag> ();
			input.Get<SpawnPrefab> () = new SpawnPrefab
			{
				Prefab = _staticData.InputPrefab,
				Position = Vector3.zero,
				Rotation = Quaternion.identity,
				Parent = null
			};
		}

		public void Run ()
		{
			if (_inputFilter.GetEntity (0).IsNull ())
				return;

			ref EcsEntity inputEntity = ref _inputFilter.GetEntity (0);

			foreach (int i in _playerFilter)
			{
				ref EcsEntity playerEntity = ref _playerFilter.GetEntity (i);

				if (inputEntity.Has<MovePerformedInputEvent> ())
					playerEntity.Get<Velocity> ().Value = inputEntity.Get<MovePerformedInputEvent> ().Value;

				if (inputEntity.Has<MoveCanceledInputEvent> ())
					playerEntity.Get<Velocity> ().Value = inputEntity.Get<MoveCanceledInputEvent> ().Value;

				if (inputEntity.Has<MoveStartedInputEvent> ())
				{
					playerEntity.Get<Velocity> ().Value = inputEntity.Get<MoveStartedInputEvent> ().Value;
					if (playerEntity.Has<GrabLedgeStateFlag> ())
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