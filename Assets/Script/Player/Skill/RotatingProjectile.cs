//#define DEFAULTCODING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingProjectile : MonoBehaviour
{
#if DEFAULTCODING
    //rotating projectile
    public Transform rotateAround;
    public float targetDistance = 3;
    Vector3 offset;
    public float angle;
    float sqrRange;
    public Vector3 axis = new Vector3(0, 1, 0);
    public override void Shoot()
    {

        /*transform.Rotate(rotateAround.position, Vector3.up, projectilePrefab);
        Vector3 delta = transform.position - rotateAround.position;
        delta.y = 0;
        transform.position - rotateAround.position + delta.normalized * targetDistance;*/

        angle += projectilSpeed * Time.deltaTime;
        if (offset != null)
        {
            offset = new Vector3(Mathf.Sin(angle) + targetDistance, 1, Mathf.Cos(angle) * targetDistance) * targetDistance;
        }
        transform.position = rotateAround.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log();
        EnemyCharacter en = other.gameObject.GetComponent<EnemyCharacter>();
        if (en != null && !en.isDead) en.TakeDamage(projectileDamage);
    }
#else
    public Transform rotateAround;
    public float projectileSpeed = 5f;
    public float targetDistance = 3;
    public float offsetPositionY = 1f;
    public float angle;
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        angle += projectileSpeed * Time.deltaTime;
        if (offset != null)
        {
            offset = new Vector3(Mathf.Sin(angle) * targetDistance, Mathf.Cos(angle) * targetDistance, 0) * targetDistance;
        }
        transform.position = rotateAround.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyCharacter en = other.gameObject.GetComponent<EnemyCharacter>();
        BlobOrbs orb = FindObjectOfType<BlobOrbs>();
        if (en != null && !en.isDead) en.TakeDamage(orb.baseDamage);
    }
#endif
}
