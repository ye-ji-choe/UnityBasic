using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public NavMeshAgent[] agents;

    private bool clicked = false;

    // Update is called once per frame
    void Update()
    {
        if (clicked == false)
            return;
        clicked = false;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            
            foreach(NavMeshAgent agent in agents)
            {
            agent.destination =  hit.point;

            }
        }
    }

    public void OnAttack()
    {
        clicked = true;
    }
}
