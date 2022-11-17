using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    public enum playerPower { NORMAL, WIDE};
    public playerPower _playerPower = playerPower.NORMAL;
    public Transform hitCheck;
    public float attackRadius;
    public int attackDamage;

    public Collider[] enemy;

    public List<BaseSkill> _skillList;
    public override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontal, 0, vertical);
        charController.Move(moveDir * movementSpeed * Time.deltaTime);

        if (moveDir != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (!isDead)
        {
            if (_playerPower == playerPower.WIDE)
                gameObject.transform.localScale = Vector3.right * 10 + Vector3.one;
            else
                gameObject.transform.localScale = Vector3.one;

            Move();

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("isAttack");
            }
        }
        
    }

    public void Attack()
    {
        enemy = Physics.OverlapSphere(hitCheck.position, attackRadius);
        foreach (var item in enemy)
        {
            if(item.gameObject.GetComponent<BaseCharacter>() != null && item.gameObject.GetComponent<BaseCharacter>() != this)
            {
                time = 0;
                item.gameObject.GetComponent<BaseCharacter>().TakeDamage(attackDamage);
                
            }
                
        }
        
    }

    public override void OnDead()
    {
        isDead = true;
        animator.SetTrigger("isDead");
    }

    private void OnDrawGizmos()
    {
        if (hitCheck != null)
            Gizmos.DrawWireSphere(hitCheck.position, attackRadius);
    }
}
