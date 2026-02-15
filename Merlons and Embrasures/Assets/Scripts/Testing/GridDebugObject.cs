using UnityEngine;
using CodeMonkey.Grid;
using TMPro;

namespace ME.Testing
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private GridObject gridObject;

        public void SetGridObject(GridObject gridObject) {
            this.gridObject = gridObject;
        }

        private void Update() {
            text.text = gridObject.ToString();
        }
    }
}
