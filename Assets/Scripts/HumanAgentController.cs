using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class HumanAgentController : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;

    public float walkSpeed;
    public float runSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    public float multiplier = 1f;
    // Update is called once per frame
    void Update()
    {
        float currentSpeed = agent.velocity.magnitude;
        anim.SetBool("IsMove", currentSpeed > 0.1f);

        //에이전트의 현재 이동 속도를 구해서 현재 이동중인지 아닌지 판별하고 애니메이션에 적용
        //if (currentSpeed > 0.1f)
        //    anim.SetBool("IsMove", true);
        //else
        //    anim.SetBool("IsMove", false);

        if(currentSpeed > runSpeed)
        {
            multiplier = currentSpeed / runSpeed;
        }
        
        anim.SetFloat("Speed", currentSpeed - walkSpeed / runSpeed - walkSpeed);
        anim.SetFloat("PlaySpeed", multiplier);
    }
}
