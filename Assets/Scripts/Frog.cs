using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCollider;
    public Transform leftCollider;
    public Transform headPoint;
    public LayerMask layer;

    private bool colliding;

    public BoxCollider2D bc;
    public CircleCollider2D cc;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCollider.position, leftCollider.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            float height = other.contacts[0].point.y - headPoint.position.y;

            if(height > 0){
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5,ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");

                bc.enabled = false;
                cc.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.33f);
            }
        }
    }
}
