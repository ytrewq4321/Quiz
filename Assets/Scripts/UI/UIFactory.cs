using Grid;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIFactory
    {
        private readonly GridModel gridModel;
        private readonly UIRoot uiRoot;
        private GridView gridView;
        private GridLayoutGroup gridLayoutGroup;
        private GameObject grid;
    

        public UIFactory(GridModel gridModel, UIRoot uiRoot, GridView gridView)
        {
            this.gridModel = gridModel;
            this.uiRoot = uiRoot;
            this.gridView = gridView;

            gridLayoutGroup = gridView.GetComponentInChildren<GridLayoutGroup>();
        }

        public GameObject CreateGrid()
        {
            grid = new GameObject("Grid");
            grid.transform.SetParent(gridView.transform);
            /*grid.AddComponent<Canvas>();
            grid.AddComponent<CanvasScaler>();*/
            gridLayoutGroup = grid.gameObject.AddComponent<GridLayoutGroup>();

            var rectTranform = grid.GetComponent<RectTransform>();
            rectTranform.anchoredPosition =Vector2.zero;
   

            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
        
            return grid;
        }

        public Transform SetupGrid()
        {
            gridLayoutGroup.cellSize = gridModel.CellSize;
            gridLayoutGroup.spacing = gridModel.Spacing;

            gridLayoutGroup.constraintCount = gridModel.Columns;
            return grid.transform;
        }
    }
}
