using UnityEngine;

namespace CodeMonkey.GridSystem
{
    public class GridObject
    {
        private Grid grid;
        private GridPosition gridPosition;
        private Transform building;

        public GridObject(Grid gridSystem, GridPosition gridPosition) {
            this.grid = gridSystem;
            this.gridPosition = gridPosition;
        }

        public void SetBuilding(Transform building) {
            this.building = building;
        }

        public Transform GetBuilding() {
            return building;
        }

        public override string ToString() {
            return $"{gridPosition.ToString()}\n{building}";
        }
    }
}
