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
    public float timeAnim;
    // Start is called before the first frame update
    public void Start()
    {
        currentHP = baseHP;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            TakeDamage(15);

        if (timeAnim < 2f)
            timeAnim += Time.deltaTime;

        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, timeAnim);
    }

    public void TakeDamage(int damage)
    {
        
        if (currentHP > 0 && !isDead)
        {
            AnimateDamage();
            currentHP -= damage;

            if(currentHP < 0)
            {
                currentHP = 0;
                isDead = true;
            }
        }
    }

    public void AnimateDamage()
    {
        timeAnim = 0f;
        
    }
}
