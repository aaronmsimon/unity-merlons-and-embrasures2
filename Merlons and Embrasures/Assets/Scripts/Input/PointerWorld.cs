using UnityEngine;
using UnityEngine.InputSystem;

namespace ME.Input
{
    public static class PointerWorld
    {
        /// <summary>
        /// Gets the current pointer (mouse/touch/pen) screen position using the new Input System.
        /// Returns false if no pointer device exists.
        /// </summary>
        public static bool TryGetPointerScreenPos(out Vector2 screenPos)
        {
            if (Pointer.current == null)
            {
                screenPos = default;
                return false;
            }

            screenPos = Pointer.current.position.ReadValue();
            return true;
        }

        /// <summary>
        /// Projects a screen position onto the world by raycasting against a layer mask.
        /// </summary>
        public static bool TryGetWorldPointOnLayer(Camera cam, Vector2 screenPos, LayerMask layerMask, out Vector3 worldPos)
        {
            var ray = cam.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out var hit, float.MaxValue, layerMask))
            {
                worldPos = hit.point;
                return true;
            }

            worldPos = default;
            return false;
        }

        /// <summary>
        /// Convenience: uses current pointer screen pos + raycast.
        /// </summary>
        public static bool TryGetPointerWorldPointOnLayer(Camera cam, LayerMask layerMask, out Vector3 worldPos)
        {
            if (!TryGetPointerScreenPos(out var screenPos))
            {
                worldPos = default;
                return false;
            }

            return TryGetWorldPointOnLayer(cam, screenPos, layerMask, out worldPos);
        }
    }
}
