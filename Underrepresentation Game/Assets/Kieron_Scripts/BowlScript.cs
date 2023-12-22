using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlScript : MonoBehaviour
{
    public GameObject mixture;
    public GameObject area;
    public GameObject eggs;
    public GameObject knives;
    private Equipment equipment;
    public int total;
    private int amount = 0;
    private GameObject[] products;
    private Rigidbody2D[] rb;
    private float mixed = 0;
    public float mixedTotal;
    private bool safe;
    
    // Start is called before the first frame update
    void Start()
    {
        products = new GameObject[total];
        rb = new Rigidbody2D[total];
        equipment = gameObject.GetComponent<Equipment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (total == amount)
        {
            if(mixed < mixedTotal)
            {
                foreach(Rigidbody2D i in rb)
                {
                    mixed += Mathf.Abs(i.velocity.x);
                    mixed += Mathf.Abs(i.velocity.y);
                    Debug.Log(mixed);
                }
                //Debug.Log(mixed);
            }
            else
            {
                foreach(GameObject i in products)
                {
                    i.SetActive(false);
                }
                //equipment.pickUp = true;
                mixture.SetActive(true);
                knives.SetActive(false);
                amount = 0;
            }
        }

        if (mixture.activeSelf)
        {
            gameObject.GetComponent<Equipment>().enabled = true;

            if (Input.GetMouseButtonDown(0) && safe)
            {
                eggs.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Product")
        {
            products[amount] = collider.transform.gameObject;
            rb[amount] = products[amount].GetComponent<Rigidbody2D>();
            Debug.Log(rb[amount].velocity);
            amount++;
        }

        if (collider.transform.gameObject == area)
        {
            safe = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.gameObject == area)
        {
            safe = false;
        }
    }
}
