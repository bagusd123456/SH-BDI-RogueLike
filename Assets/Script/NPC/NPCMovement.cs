using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ai.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > 2f)
        {
            ai.destination = target.transform.position;
            ai.isStopped = false;
        }

        else
        {
            ai.isStopped = true;
        }
            

        ai.updateRotation = false;
    }
}
