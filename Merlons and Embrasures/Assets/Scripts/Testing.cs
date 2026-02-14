using UnityEngine;
using CodeMonkey.GridSystem;

namespace ME.Testing
{
    public class Testing : MonoBehaviour
    {
        private void Start() {
            CodeMonkey.GridSystem.Grid grid = new CodeMonkey.GridSystem.Grid(4, 2);
        }
    }
}
