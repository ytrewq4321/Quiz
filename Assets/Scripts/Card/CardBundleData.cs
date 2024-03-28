using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "CardBundleData",menuName = "CardBundleData",order = 10)]
    public class CardBundleData : ScriptableObject
    {
        [SerializeField] private string bundleName; 
        [SerializeField] private List<CardData> cardData;

        public List<CardData> CardData => cardData;
        public string BundleName => bundleName;
    }
}
