using UnityEngine;

namespace _Project.Scripts.GameFeatures.Common
{
    public class Visualizer : MonoBehaviour
    {
        [SerializeField] private float _raycastDistance;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _raycastDistance);
        }
    }
}