using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : CharacterBase
{
    public GameObject slashPrefab;
    

    public float distance;

    public float radius = 5f;
    public float dashTime;
    
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            var go = SkillManager.instance.availableSkills.Find(x => x.skillName == "IceShoot");
            go.CastSkill();
        }
        distance = Vector2.Distance(GameManager.Instance.mousePos, transform.position);

        if (Input.GetMouseButtonDown(1))
        {
            var go = SkillManager.instance.availableSkills.Find(x => x.skillName == "BasicSlash");
            go.CastSkill();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            dashTime = .15f;


        CheckDash();

        if (isDead)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Animator>().enabled = false;
            this.enabled = false;
        }
    }

    public void CheckDash()
    {
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            Dash();
        }

        else
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void Dash()
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        Vector2 direction = player.movement;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 3f, ForceMode2D.Impulse);
    }

    
}
