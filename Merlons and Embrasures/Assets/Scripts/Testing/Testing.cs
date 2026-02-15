using UnityEngine;
using CodeMonkey.Grid;
using ME.Input;

namespace ME.Testing
{
    public class Testing : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] private Transform gridObjectPrefab;

        [Header("Mouse Interaction")]
        [SerializeField] private LayerMask pointerPlaneLayerMask;
        [SerializeField] private Camera cam;

        private GridSystem gridSystem;

        private void Start() {
            gridSystem = new GridSystem(10, 10, 2f);
            gridSystem.CreateDebugObjects(gridObjectPrefab);
        }

        private void Update() {
            if (PointerWorld.TryGetPointerWorldPointOnLayer(cam, pointerPlaneLayerMask, out var pos)) {
                Debug.Log(gridSystem.GetGridPosition(pos));
            }
        }
    }
}
