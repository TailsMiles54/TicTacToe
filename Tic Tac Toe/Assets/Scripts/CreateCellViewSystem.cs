using System;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TicToe
{
    public class CreateCellViewSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter;
        private Configuration _confguration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_confguration.CellView);

                cellView.transform.position = new Vector3(position.Value.x + _confguration.Offset.x * position.Value.x, position.Value.y+ _confguration.Offset.y * position.Value.y);

                cellView.Entity = _filter.GetEntity(index);
                
                _filter.GetEntity(index).Get<CellViewRef>().value = cellView;
            }
        }
    }
}