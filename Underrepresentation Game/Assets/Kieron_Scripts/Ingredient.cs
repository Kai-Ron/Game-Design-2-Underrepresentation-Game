using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingredient : MonoBehaviour
{
    //private Rigidbody2D rb;
    public GameObject startArea, prepArea;
    private float mouseX, mouseY;
    public bool pickUp = false, safe = true;
    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Controls()
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
        if(!safe && !pickUp)
        {
            Debug.Log(4);
            if(gameObject.activeSelf)
            {
                SceneManager.LoadScene("KieronGameOverScene");
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject == startArea || other.transform.gameObject == prepArea)
        {
            safe = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.gameObject == startArea || other.transform.gameObject == prepArea)
        {
            if(gameObject.activeSelf)
            {
                safe = false;
            }
        }
    }
}
