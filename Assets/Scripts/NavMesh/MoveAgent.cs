using UnityEngine;
using UnityEngine.AI;

namespace NavMesh
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveAgent : MonoBehaviour
    {
        
        
        private NavMeshAgent agent;
        private Camera mainCam;
      [SerializeField]   private LayerMask targetLayer;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        private RaycastHit hit;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 50, targetLayer))
                    agent.destination = hit.point;
        }
    }
}