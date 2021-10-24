using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;

namespace TicToe
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        private Configuration _confguration;
        private EcsWorld _world;
        private GameState _gameState;
        
        public void Init()
        {
            for (int i = 0; i < _confguration.LevelHeight; i++)
            {
                for (int j = 0; j < _confguration.LevelHeight; j++)
                {
                    var cellEntity = _world.NewEntity();
                    cellEntity.Get<Cell>();
                    var position = new Vector2Int(i, j);
                    cellEntity.Get<Position>().Value = position;

                    _gameState.Cells[position] = cellEntity;
                }
            }

            _world.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}