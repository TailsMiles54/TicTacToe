using Leopotam.Ecs;
using UnityEngine;

namespace TicToe {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public Configuration Configuration;
        public SceneData SceneData;
        
        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            var gameState = new GameState();
            SceneData.UI.GameHUD.SetTurn(gameState.CurrentType);
            
            _systems
                .Add (new InitializeFieldSystem())
                .Add (new CreateCellViewSystem())
                .Add(new SetCameraSystem())
                .Add(new ControlSystem())
                .Add(new AnalyzeClickSystem())
                .Add(new CreateTakenViewSystem())
                .Add(new CheckWinSystem())
                .Add(new WinSystem())
                .Add(new DrawSystem())
                // .Add (new TestSystem2 ())
                
                // register one-frame components (order is important), for example:
                .OneFrame<UpdateCameraEvent> ()
                .OneFrame<Clicked> ()
                .OneFrame<CheckWinEvent> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                .Inject (Configuration)
                .Inject (SceneData)
                .Inject (gameState)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}