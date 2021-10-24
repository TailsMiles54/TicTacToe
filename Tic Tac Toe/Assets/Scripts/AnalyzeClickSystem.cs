using Leopotam.Ecs;
using Object = System.Object;

namespace TicToe
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter;
        private GameState _gameState;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                _filter.GetEntity(index).Get<Taken>().value = _gameState.CurrentType;
                _filter.GetEntity(index).Get<CheckWinEvent>();

                _gameState.CurrentType = _gameState.CurrentType == SignType.Cross ? SignType.Ring : SignType.Cross;

                _sceneData.UI.GameHUD.SetTurn(_gameState.CurrentType);
            }
        }
    }
}