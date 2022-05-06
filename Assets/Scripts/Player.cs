using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rig;
    private bool onTheGround;
    private bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        onTheGround = true;
        doubleJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();   
        jump();
    }

    void move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    void jump(){
        if(Input.GetButtonDown("Jump")){

            if(onTheGround == true){
                rig.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
                doubleJump = true;
            }else{
                if(doubleJump){
                    rig.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
             

        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            onTheGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            onTheGround = false;
        }
    }
}
