using Leopotam.Ecs;

namespace TicToe
{
    internal class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<Cell>.Exclude<Taken,Winner> _freeCells;
        private EcsFilter<Winner> _winner;
        private SceneData _sceneData;
        
        public void Run()
        {
            if (_freeCells.IsEmpty() && _winner.IsEmpty())
            {
                _sceneData.UI.LoseScreen.Show(true);
            }
        }
    }
}