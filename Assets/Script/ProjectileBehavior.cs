using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public GameObject projectileDestroy;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
    }

    public void RotateToTarget(Transform target)
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<CharacterBase>().TakeDamage(15);
            var go = Instantiate(projectileDestroy, transform.position, Quaternion.identity);
            Destroy(go, .35f);
            Destroy(gameObject);
        }

        else if (!collision.CompareTag("Enemy") && !collision.CompareTag("Player"))
        {
            var go = Instantiate(projectileDestroy, transform.position, Quaternion.identity);
            Destroy(go, .35f);
            Destroy(gameObject);
        }

        else if(startTime > 2f)
        {
            var go = Instantiate(projectileDestroy, transform.position, Quaternion.identity);
            Destroy(go, .35f);
            Destroy(gameObject);
        }
    }
}
