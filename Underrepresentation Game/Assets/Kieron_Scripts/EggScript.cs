using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Ingredient egg;
    public GameObject yolk;
    private GameObject instance;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        egg = gameObject.GetComponent<Ingredient>();
    }

    // Update is called once per frame
    void Update()
    {
        if (egg.pickUp)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(egg.safe)
                {
                    Destroy(GetComponent<CircleCollider2D>());
                    Collider2D collider = Physics2D.OverlapPoint(transform.position);
                    if(collider)
                    {
                        if(egg.prepArea == collider.transform.gameObject)
                        {
                            instance = Instantiate(yolk, transform.position, Quaternion.Euler(0,0,0));
                            instance.GetComponent<YolkScript>().area = egg.prepArea;
                            egg.pickUp = false;
                            Destroy(gameObject);
                        }
                        else if (collider.transform.gameObject.tag == "Product")
                        {
                            instance = Instantiate(yolk, transform.position, Quaternion.Euler(0,0,0));
                            instance.GetComponent<YolkScript>().area = egg.prepArea;
                            egg.pickUp = false;
                            Destroy(gameObject);
                        }
                        else
                        {
                            SceneManager.LoadScene("KieronGameOverScene");
                        }
                    }
                    else
                    {
                        SceneManager.LoadScene("KieronGameOverScene");
                    }
                }
                else
                {
                    SceneManager.LoadScene("KieronGameOverScene");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Danger")
        {
            SceneManager.LoadScene("KieronGameOverScene");
        }
    }
}