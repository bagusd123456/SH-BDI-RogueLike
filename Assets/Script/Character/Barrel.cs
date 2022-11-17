using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : CharacterBase
{
    public float attackRadius;
    public Vector3 offset;

    public float time;
    public float attackInterval;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        base.Update();
        if(!gameObject.GetComponent<NPCMovement>().isMoving && time <= 0)
        {
            time = attackInterval;
            Attack();
        }
            
    }

    public void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position + offset, attackRadius);
        foreach (var item in hit)
        {
            if (item.transform.GetComponent<CharacterBase>() != null && item.transform.CompareTag("Player"))
                item.transform.GetComponent<CharacterBase>().TakeDamage(baseAtk);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, attackRadius);
    }
}
