using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMissile : BaseSkill
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void CastSkill()
    {
        var GO = Instantiate(projectilePrefab, transform);
    }

    public override void OnLevelUp()
    {
        throw new System.NotImplementedException();
    }
}
