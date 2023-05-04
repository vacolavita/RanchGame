using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    private NavMeshAgent agent;
    public float waitTime = 6;
    private float timer = 0;
    private float timer2 = 0;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 || timer2 <= 0)
        {
            NavMeshPath path = new NavMeshPath();
            do
            {
                pos = (Random.insideUnitSphere * 10 + transform.position);
                pos.y = transform.position.y;
            } while (!NavMesh.CalculatePath(transform.position, pos, NavMesh.AllAreas, path));
            timer = waitTime;
            timer2 = 10;
            agent.SetDestination(pos);
        }

        if (agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            timer -= Time.deltaTime;
        }
        timer2 -= Time.deltaTime;
    }
}
