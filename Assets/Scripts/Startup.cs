using Leopotam.Ecs;
using UnityEngine;
using Common;
using Input;
using Movements;
using Spawners;
using Combat;
using Enemies;
using Traps;
using Service;

sealed class Startup : MonoBehaviour {
	[SerializeField]
	private StaticData staticData;
	[SerializeField]
	private SceneData sceneData;

	private EcsWorld world;
	private EcsSystems systems;
	private EcsSystems fixedSystems;

	void Start () {
		world = new EcsWorld ();
		systems = new EcsSystems (world);
		fixedSystems = new EcsSystems (world);

		PreferencesService preferencesService = new PreferencesService ();

#if UNITY_EDITOR
		Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (world);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (systems);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (fixedSystems);
#endif
		systems
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
			.Inject (staticData)
			.Inject (sceneData)
			.Inject (preferencesService)
			.Init ();

		fixedSystems
			.Add (new CheckGroundSystem ())
			.Add (new CheckFallingSystem())
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

	void Update () {
		systems?.Run ();
	}

	private void FixedUpdate () {
		fixedSystems?.Run ();
	}

	void OnDestroy () {
		if (systems != null) {
			systems.Destroy ();
			systems = null;
		}
		if (fixedSystems != null) {
			fixedSystems.Destroy ();
			fixedSystems = null;
		}
		world.Destroy ();
		world = null;
	}
}
