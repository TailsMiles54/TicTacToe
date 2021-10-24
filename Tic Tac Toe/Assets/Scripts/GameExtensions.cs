using System.Collections.Generic;
using Leopotam.Ecs;
using TicToe;
using UnityEngine;

public static class GameExtensions
{
    public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
    {
        var startEntity = cells[position];
        if (!startEntity.Has<Taken>())
        {
            return 0;
        }
        
        //horizontal
        var startType = startEntity.Ref<Taken>().Unref().value;
        var horizontalLength = 1;
        
        {
            var direction = new Vector2Int(-1, 0);
            var currentPosition = position + direction;
            
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    horizontalLength++;
                    currentPosition += direction;
                }

            }
        }
        
        {
            var direction = new Vector2Int(1, 0);
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    horizontalLength++;
                    currentPosition += direction;
                }

            }
        }
        
        //vertical
        
        var verticalLength = 1;
        
        {
            var direction = new Vector2Int(0,-1);
            var currentPosition = position + direction;
            
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    verticalLength++;
                    currentPosition += direction;
                }

            }
        }
        
        {
            var direction = new Vector2Int(0,1);
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    verticalLength++;
                    currentPosition += direction;
                }

            }
        }
        
        //diagonal
        var diagonalOneLength = 1;
        {
            var direction = new Vector2Int(-1,-1);
            var currentPosition = position + direction;
            
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    diagonalOneLength++;
                    currentPosition += direction;
                }

            }
        }
        
        {
            var direction = new Vector2Int(1,1);
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    diagonalOneLength++;
                    currentPosition += direction;
                }

            }
        }
        //diagonal other
        var diagonalOneLength2 = 1;
        {
            var direction = new Vector2Int(1,-1);
            var currentPosition = position + direction;
            
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    diagonalOneLength2++;
                    currentPosition += direction;
                }

            }
        }
        
        {
            var direction = new Vector2Int(-1,1);
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }
                else
                {
                    var type = entity.Ref<Taken>().Unref().value;
                    if (type != startType)
                    {
                        break;
                    }

                    diagonalOneLength2++;
                    currentPosition += direction;
                }

            }
        }
        
        return Mathf.Max(verticalLength,horizontalLength,diagonalOneLength,diagonalOneLength2);
    }
}