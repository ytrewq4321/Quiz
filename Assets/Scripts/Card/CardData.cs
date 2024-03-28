using System;
using UnityEngine;

namespace Card
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Vector3 rotation;

        public string Name => name;
        public Sprite Sprite => sprite;
        public Vector3 Rotation => rotation;
    }
}