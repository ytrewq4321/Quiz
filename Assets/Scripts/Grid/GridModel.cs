using UnityEngine;

namespace Grid
{
    [CreateAssetMenu(fileName = "GridModel",menuName = "Grid")]
    public class GridModel : ScriptableObject
    {
        [SerializeField] private int columns;
        [SerializeField] private Vector2 cellSize;
        [SerializeField] private Vector2 spacing;

        public int Columns => columns;
        public Vector2 CellSize => cellSize;
        public Vector2 Spacing => spacing;
    }
}
