using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{

    public float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D bc;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Fall", fallingTime);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }

    void Fall()
    {
        target.enabled = false;
        bc.isTrigger = true;
    }
}
