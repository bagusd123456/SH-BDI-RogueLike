using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBase : MonoBehaviour
{
    [Header("Character Stats")]
    public int baseHP;
    public int currentHP;
    [Space]
    public int baseAtk;
    [Space]
    public float movementSpeed;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = baseHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            TakeDamage(15);
    }

    public void TakeDamage(int damage)
    {
        if (currentHP > 0 && !isDead)
            currentHP -= damage;
        else
        {
            currentHP = 0;
            isDead = true;
        }
    }
}
