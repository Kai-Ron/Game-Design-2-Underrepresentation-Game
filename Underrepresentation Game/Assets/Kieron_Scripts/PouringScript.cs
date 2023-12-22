using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringScript : MonoBehaviour
{
    public GameObject area;
    public GameObject product;
    public GameObject container;
    private bool safe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && safe)
        {
            product.SetActive(true);
            Destroy(container);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*if (collider.transform.gameObject.tag == "Safe")
        {
            safe = true;
            Debug.Log(safe);
        }*/
        //Debug.Log(safe);
        if (collider.transform.gameObject == area)
        {
            safe = true;
            Debug.Log(safe);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Safe")
        {
            safe = false;
        }
    }
}
