using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceShoot : BaseSkill
{
    public Transform projectileSpawn;

    public override void CastSkill()
    {
        if (canCast)
        {
            time = 0;
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
}
