using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private Animator anim;

    private bool onTheGround;
    private bool doubleJump;

    private bool isBlowing;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        onTheGround = true;
        doubleJump = false;
        isBlowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move()
    {
        // a função 'Input.GetAxis("Horizontal")' varia entre os valores -1, 0 e 1
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * speed;

        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed,rig.velocity.y);

        if (movement != 0)
        {
            anim.SetBool("walk", true);

            if (movement < 0)
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {

            if (onTheGround == true)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }


        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            onTheGround = true;
            anim.SetBool("jump", false);
        }

        if (other.gameObject.layer == 9)
        {
            GameController.instance.showGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            onTheGround = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 7)
        {
            isBlowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 7)
        {
            isBlowing = false;
        }
    }
}
