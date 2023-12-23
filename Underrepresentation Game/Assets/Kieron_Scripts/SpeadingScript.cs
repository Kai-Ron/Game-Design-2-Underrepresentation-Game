using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeadingScript : MonoBehaviour
{
    public GameObject area;
    public GameObject product;
    public GameObject subProduct;
    public CameraController camController;
    private bool safe, spread;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && safe)
        {
            if(subProduct.activeSelf)
            {
                camController.playing = false;
                product.SetActive(true);
                Destroy(gameObject);
            }
        }

        if (Input.GetMouseButtonDown(0) && spread)
        {
            subProduct.SetActive(true);
            Destroy(area);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Safe")
        {
            safe = true;
            Debug.Log(safe);
        }
        //Debug.Log(safe);
        if (collider.transform.gameObject == area)
        {
            spread = true;
            Debug.Log(spread);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Safe")
        {
            safe = false;
        }

        if (collider.transform.gameObject == area)
        {
            spread = false;
        }
    }
}
