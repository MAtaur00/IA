using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class MoveToMouseClick : MonoBehaviour
{

    public LayerMask mask;
    public NavMeshAgent agent;
    public Animator animation;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hit, 10000.0f, mask) == true)
                transform.position = hit.point;
        }
        agent.destination = transform.position;
        if (Vector3.Distance(agent.transform.position, transform.position) > 0.0f)
        {
            animation.SetBool("movement", true);
        }
        Vector3 vec = agent.transform.position - transform.position;
        vec.Normalize();
        animation.SetFloat("vel.x", vec.x);
        animation.SetFloat("vel.y", vec.z);
    }

}
