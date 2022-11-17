using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerCharacter;

public abstract class BaseCharacter : MonoBehaviour
{
    [HideInInspector] public CharacterController charController;
    [HideInInspector] public Animator animator;

    protected float movementSpeed = 10f;
    protected float rotationSpeed = 180f;
    public int maxHP;
    public int currentHP;
    public bool isDead = false;
    public float time;

    public abstract void Move();

    public abstract void OnDead();

    public virtual void TakeDamage(int damage)
    {
        if(currentHP <= 0)
        {
            currentHP = 0;
            if (!isDead)
            {
                OnDead();
                isDead = true;
            }
        }
        else
        {
            time = 0;
            currentHP -= damage;
        }
    }

    public void ColorOnDamage()
    {
        Material mat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        mat.SetColor("_BaseColor", Color.Lerp(Color.red, Color.white, Mathf.Lerp(0, 1, time)));
       
        Material mat2 = gameObject.GetComponentInChildren<MeshRenderer>().material;
        mat2.SetColor("_BaseColor", Color.Lerp(Color.red, Color.white, Mathf.Lerp(0, 1, time)));
    }
    public virtual void Heal(int healAmount)
    {
        currentHP += healAmount;
        if (currentHP > maxHP) currentHP = maxHP;
    }
    // Start is called before the first frame update
    void Awake()
    {
        time = 1;
        charController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
}

    // Update is called once per frame
    public virtual void Update()
    {
        time += Time.deltaTime;
        ColorOnDamage();
    }
}
