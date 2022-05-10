using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{


    public int health;
    public float jumpForce;
    public bool isUp;
    public GameObject deathAnim;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){

            anim.SetTrigger("hit");
            health -= 1;

            if(isUp){
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }else{
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
            }

            if (health <= 0){
                Instantiate(deathAnim, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
    }
}
