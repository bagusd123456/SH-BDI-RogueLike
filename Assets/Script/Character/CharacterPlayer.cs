using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : CharacterBase
{
    public GameObject projectilePrefab;
    public GameObject slashPrefab;
    public Transform projectileSpawn;
    public Transform slashSpawn;

    public float distance;

    public float radius = 5f;

    public GameObject hitbox;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            RangedAttack();
        }
        distance = Vector2.Distance(GameManager.Instance.mousePos, transform.position);

        if (Input.GetMouseButtonDown(1))
        {
            MeleeAttack();
        }
        
    }

    public void RangedAttack()
    {
        //Spawn
        var go = Instantiate(projectilePrefab, projectileSpawn.position, Quaternion.identity);
        Vector2 direction = GameManager.Instance.mousePos - new Vector2(transform.position.x, transform.position.y);
        go.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 10f, ForceMode2D.Impulse);

        //Rotation
        float angle = Mathf.Atan2(GameManager.Instance.mousePos.y - transform.position.y, GameManager.Instance.mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        go.transform.rotation = targetRotation;

        Destroy(go, 5f);
    }

    public void MeleeAttack()
    {
        float angle = Mathf.Atan2(GameManager.Instance.mousePos.y - transform.position.y, GameManager.Instance.mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        hitbox.transform.rotation = targetRotation;

        

        var go = Instantiate(slashPrefab, slashSpawn.transform.position, Quaternion.identity,hitbox.transform);
        go.transform.rotation = targetRotation;
        Destroy(go, 1f);
    }

    public void Dash()
    {

    }

    private void OnDrawGizmos()
    {
        
    }
}
