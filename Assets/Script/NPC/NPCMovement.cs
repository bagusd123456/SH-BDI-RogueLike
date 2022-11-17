using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent ai;

    public NPCMovement movement;
    public Animator anim;
    public bool isMoving;
    // Start is called before the first frame update
    void Awake()
    {
        ai.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
        if (target == null)
            target = FindObjectOfType<CharacterPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > 2f)
        {
            isMoving = true;
            ai.destination = target.transform.position;
            ai.isStopped = false;
        }

        else
        {
            isMoving = false;
            ai.isStopped = true;
        }
        anim.SetBool("isMoving", movement.isMoving);
        ai.updateRotation = false;
        FaceToPlayer();
    }

    public void FaceToPlayer()
    {
        float angle = target.transform.position.x - transform.position.x;
        if(angle > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}
