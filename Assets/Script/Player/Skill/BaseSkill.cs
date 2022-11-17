using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSkill : MonoBehaviour
{
    [Header("Skill Description")]
    public string skillName;
    public string skillDescription;

    [Header("Skill Parameter")]
    public GameObject projectilePrefab;

    public float time;
    public float cooldownTime;
    public bool canCast;
    public int level = 1;
    public int baseDamage;
    public float projectileSpeed = 25f;

    [Header("UI Properties")]
    public Image imgSkill;
    
    public abstract void CastSkill();
    public abstract void OnLevelUp();

    public void Update()
    {
        CheckSkill();
    }

    public void CheckSkill()
    {
        if (time > cooldownTime)
            canCast = true;
        else
        {
            time += Time.deltaTime;
            if(imgSkill != null)
                imgSkill.fillAmount = time / cooldownTime;
            canCast = false;
        }
    }
}
