using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{
    public bool direction;
    public float speed;
    public Rigidbody2D rb;
    public Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(direction)
        {
            rb.AddForce(-transform.right * speed, ForceMode2D.Force);
            tf.localScale = new Vector3(1, 1, 1);
        }
        else if(!direction)
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
            tf.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.transform.tag == "Border")
        {
            direction = !direction;
            rb.velocity = new Vector3 (0, 0, 0);
            Debug.Log(speed);
        }
    }
}
