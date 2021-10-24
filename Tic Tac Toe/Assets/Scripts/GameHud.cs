using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicToe
{
    public class GameHud : MonoBehaviour
    {
        public Text TurnLabel;
        public void SetTurn(SignType gameStateCurrentType)
        {
            switch (gameStateCurrentType)
            {
                case SignType.Cross:
                    TurnLabel.text = "Крест ходит";
                    break;
                case SignType.Ring:
                    TurnLabel.text = "Круг ходит";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateCurrentType), gameStateCurrentType, null);
            }
        }
    }
}