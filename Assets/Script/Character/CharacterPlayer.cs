using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : CharacterBase
{
    public GameObject projectilePrefab;
    public Transform projectileSpawn;

    public float radius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RangedAttack();
        }

    }

    public void RangedAttack()
    {
        var go = Instantiate(projectilePrefab, projectileSpawn.position, Quaternion.identity);
        Vector2 direction = GameManager.Instance.mousePos - new Vector2(transform.position.x,transform.position.y);
        
        go.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 10f, ForceMode2D.Impulse);

        Destroy(go, 5f);
    }

    public void MeleeAttack()
    {

    }

    private void OnDrawGizmos()
    {

        Vector2 direction = GameManager.Instance.mousePos - new Vector2(transform.position.x, transform.position.y);
        Gizmos.DrawWireSphere(GameManager.Instance.mousePos, radius);
    }
}
