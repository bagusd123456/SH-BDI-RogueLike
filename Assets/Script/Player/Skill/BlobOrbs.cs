//#define DEFAULTCODING
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobOrbs : BaseSkill
{
#if DEFAULTCODING
    public RotatingProjectile projectile;
    public List<RotatingProjectile> projectiles = new List<RotatingProjectile>();
    public int maxOrb = 1;

    public override void Action()
    {
        base.Action();
        if(spawnedProjectile.Count < maxOrb)
        {
            var prj = Instantiate(projectile);
            prj.rotateAround = transform;
            prj.transform.position = transform.position + Vector3.forward;
            spawnedProjectile.Add(prj);

            if(spawnedProjectile.Count > 0)
            {
                int i = 0;
                foreach (var item in spawnedProjectile)
                {
                    rt.angle = 6.29f / spawnedProjectile.Count * i;
                    i++;
                }
            }
        }
    }
#else

    public RotatingProjectile projectile;
    public List<RotatingProjectile> projectiles = new List<RotatingProjectile>();
    public int maxOrb = 1;
    public float targetDistance = 3;
    public Vector3 offset;

    public override void CastSkill()
    {
        throw new System.NotImplementedException();
    }

    public override void OnLevelUp()
    {
        maxOrb++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in projectiles)
        {
            item.projectileSpeed = projectileSpeed;
            item.targetDistance = targetDistance;
            //item.targetDistance = Mathf.Lerp(1f, targetDistance, Mathf.PingPong(Time.time, 1));
        }

        if (projectiles.Count < maxOrb)
        {
            var prj = Instantiate(projectile,GameObject.FindGameObjectWithTag("Player").transform);
            prj.rotateAround = transform;
            prj.transform.position = transform.position + Vector3.forward;
            projectiles.Add(prj);

            if (projectiles.Count > 0)
            {
                int i = 0;
                foreach (var item in projectiles)
                {
                    
                    item.angle = 6.29f / projectiles.Count * i;
                    i++;
                }
            }
        }
        else if( projectiles.Count > maxOrb)
        {
            var prj = projectiles[projectiles.Count - 1];
            projectiles.Remove(prj);
            Destroy(prj.gameObject);

            if (projectiles.Count > 0)
            {
                int i = 0;
                foreach (var item in projectiles)
                {

                    item.angle = 6.29f / projectiles.Count * i;
                    i++;
                }
            }
        }
    }
#endif
}
