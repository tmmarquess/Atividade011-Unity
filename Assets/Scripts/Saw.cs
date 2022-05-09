using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float speed;
    public float moveTime;

    private bool dirRight;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if(timer >= moveTime){
            if(dirRight){
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }else{
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
