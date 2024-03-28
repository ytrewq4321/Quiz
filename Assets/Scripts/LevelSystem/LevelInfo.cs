using System;
using UnityEngine;

namespace LevelSystem
{
    [Serializable]
    public class LevelInfo
    {
        [SerializeField] private string levelName;
        [SerializeField,Range(0,30)] private int cardsCount;

        public string LevelName => levelName;
        public int CardsCount => cardsCount;
    }
}