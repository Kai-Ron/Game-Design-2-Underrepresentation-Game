using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    //private Rigidbody2D rb;
    private float mouseX, mouseY;
    public bool pickUp = false;
    Vector3 mousePosition;

    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mousePosition.x;
        mouseY = mousePosition.y;

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);
            if (collider)
            {
                if (gameObject == collider.transform.gameObject && !pickUp)
                {
                    pickUp = true;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);
            if (collider)
            {
                if (gameObject == collider.transform.gameObject && pickUp)
                {
                    pickUp = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if(pickUp)
        {
            transform.position = new Vector3 (mouseX, mouseY, 0);
        }
    }
}
