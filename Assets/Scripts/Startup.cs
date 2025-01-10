using Leopotam.Ecs;
using UnityEngine;
using Service;
using GameLogic.Systems.Spawners;
using GameLogic.Systems.Traps;
using GameLogic.Systems.Movements;
using GameLogic.Systems.Input;
using GameLogic.Systems.Common;
using GameLogic.Systems.Combat;
using GameLogic.Systems.Characters;
using GameLogic.Models;

/// <summary>
/// Точка входа в игру
/// </summary>
sealed class Startup : MonoBehaviour
{
	[SerializeField]
	private GameData _staticData;
	[SerializeField]
	private SceneData _sceneData;

	private EcsWorld _world;
	private EcsSystems _systems;
	private EcsSystems _fixedSystems;

	void Start ()
	{
		_world = new EcsWorld ();
		_systems = new EcsSystems (_world);
		_fixedSystems = new EcsSystems (_world);

		PreferencesService preferencesService = new (_staticData.Player);
		preferencesService.LoadPlayerData ();

#if UNITY_EDITOR
		Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_fixedSystems);
#endif
		_systems
			.Add (new PlayerInputSystem ())
			.Add (new SpawnPlayerSystem ())
			.Add (new SpawnEnemiesSystem ())
			.Add (new SpawnTrapsSystem ())
			.Add (new SpawnPrefabSystem ())
			.Add (new SpawnWeaponSystem ())
			.Add (new CameraTargetsSystem ())
			.Add (new MoveAnimationSystem ())
			.Add (new ShootSystem ())
			.Add (new MeleeAttackSystem ())
			.Add (new ProjectileHitSystem ())
			.Add (new TrapHitSystem ())
			.Add (new CombatAnimationSystem ())
			.Add (new CooldownSystem ())
			.Add (new DamageSystem ())
			.Add (new DeadEnemySystem ())
			.Add (new DeadPlayerSystem ())
			.Inject (_staticData)
			.Inject (_sceneData)
			.Inject (preferencesService)
			.Init ();

		_fixedSystems
			.Add (new CheckGroundSystem ())
			.Add (new CheckFallingSystem ())
			.Add (new ChangeAxisSystem ())
			.Add (new HorizontalMoveSystem ())
			.Add (new VerticalMoveSystem ())
			.Add (new DirectionSystem ())
			.Add (new JumpSystem ())
			.Add (new DuckSystem ())
			.Add (new DashSystem ())
			.Add (new GrabLedgeSystem ())
			.Add (new GrabStairSystem ())
			.Add (new SpawnProjectileSystem ())
			.Init ();
	}

	void Update ()
	{
		_systems?.Run ();
	}

	private void FixedUpdate ()
	{
		_fixedSystems?.Run ();
	}

	void OnDestroy ()
	{
		if (_systems != null)
		{
			_systems.Destroy ();
			_systems = null;
		}
		if (_fixedSystems != null)
		{
			_fixedSystems.Destroy ();
			_fixedSystems = null;
		}
		_world.Destroy ();
		_world = null;
	}
}
