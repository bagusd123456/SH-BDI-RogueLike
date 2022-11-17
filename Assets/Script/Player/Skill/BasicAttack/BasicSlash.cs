using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSlash : BaseSkill
{
    public GameObject hitbox;
    public Transform slashSpawn;

    [Header("Attack Parameter")]
    public float attackRadius = 2f;

    public override void CastSkill()
    {
        if (canCast)
        {
            time = 0;
            float angle = Mathf.Atan2(GameManager.Instance.mousePos.y - transform.position.y, GameManager.Instance.mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            hitbox.transform.rotation = targetRotation;

            RaycastHit2D[] hit = Physics2D.CircleCastAll(slashSpawn.position, attackRadius, transform.forward);
            foreach (var item in hit)
            {
                if (item.transform.GetComponent<CharacterBase>() != null && item.transform.CompareTag("Enemy"))
                    item.transform.GetComponent<CharacterBase>().TakeDamage(20);
            }

            var go = Instantiate(projectilePrefab, slashSpawn.transform.position, Quaternion.identity, hitbox.transform);
            go.transform.rotation = targetRotation;
            Destroy(go, 1f);
        }
        
    }

    public override void OnLevelUp()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    private void OnDrawGizmos()
    {
        if(slashSpawn != null)
            Gizmos.DrawWireSphere(slashSpawn.position, attackRadius);
    }
}
