using Leopotam.Ecs;
using UnityEngine;
using Common;
using Input;
using Movements;
using Spawners;

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

#if UNITY_EDITOR
		Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (world);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (systems);
		Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (fixedSystems);
#endif
		systems
			.Add (new PlayerInputSystem ())
			.Add (new SpawnPlayer ())
			.Add (new SpawnSystem ())
			.Add (new CameraTargetsSystem ())
			.Add (new MoveAnimationSystem ())
			.Inject (staticData)
			.Inject (sceneData)
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
