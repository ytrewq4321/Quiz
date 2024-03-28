using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    [CreateAssetMenu(fileName = "LevelsData",menuName = "LevelsData")]
    public class LevelsData : ScriptableObject
    {
        [SerializeField] private List<LevelInfo> levelInfos;

        public List<LevelInfo> LevelInfos => levelInfos;
    }
}