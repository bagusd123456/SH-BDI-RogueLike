using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    public Vector2 movement;
    Vector2 mousePos;

    CharacterBase characterData;
    private void Awake()
    {
        characterData = gameObject.GetComponent<CharacterBase>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = GameManager.Instance.mousePos;

        gameObject.GetComponent<Animator>().SetInteger("velocityX", Mathf.RoundToInt(movement.x));
        gameObject.GetComponent<Animator>().SetInteger("velocityY", Mathf.RoundToInt(movement.y));
    }

    private void FixedUpdate()
    {
        if (characterData.GetComponent<CharacterPlayer>().dashTime <= 0)
            Move();
    }

    public void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

        float rotation = angle * -1 + 90;
        gameObject.GetComponent<Animator>().SetFloat("angle", rotation);
    }
}
