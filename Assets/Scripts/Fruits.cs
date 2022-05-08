using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{

    public GameObject collected;

    private SpriteRenderer sr;
    private CircleCollider2D CircleCollider;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        CircleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.enabled = false;
            CircleCollider.enabled = false;

            collected.SetActive(true);

            Destroy(gameObject, 0.25f);
        }
    }
}
