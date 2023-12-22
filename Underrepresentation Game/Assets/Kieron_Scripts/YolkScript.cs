using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YolkScript : MonoBehaviour
{
    public GameObject area;
    private float mouseX, mouseY;
    private Rigidbody2D rb;
    public bool pickUp = false, safe = true;
    Vector3 mousePosition;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mousePosition.x;
        mouseY = mousePosition.y;

        if (gameObject.activeSelf == false)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);
        if (collider)
        {
            if (gameObject == collider.transform.gameObject)
            {
                rb.AddForce(new Vector2((Input.GetAxisRaw("Mouse X")) *.05f, (Input.GetAxisRaw("Mouse Y")) *.05f), ForceMode2D.Impulse);
            }
        }
        
        /*if(((area.transform.position.x - Mathf.Abs(transform.position.x)) > .5f) && ((area.transform.position.y - Mathf.Abs(transform.position.y)) > .5f))
        {
            
        }*/

        //rb.AddForce((area.transform.position - transform.position) * .5f, ForceMode2D.Force);
        rb.velocity *= .99f;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (area == collider.transform.gameObject)
        {
            rb.AddForce((area.transform.position - transform.position) * .5f, ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(area == collider.transform.gameObject)
        {
            if(gameObject.activeSelf)
            {
                SceneManager.LoadScene("KieronGameOverScene");
            }
        }
    }
}
