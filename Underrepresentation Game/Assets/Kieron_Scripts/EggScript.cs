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
                            gameObject.SetActive(false);
                        }
                        else if (collider.transform.gameObject.tag == "Product")
                        {
                            instance = Instantiate(yolk, transform.position, Quaternion.Euler(0,0,0));
                            instance.GetComponent<YolkScript>().area = egg.prepArea;
                            egg.pickUp = false;
                            gameObject.SetActive(false);
                        }
                        else
                        {
                            Debug.Log(collider.transform.gameObject.name);
                            SceneManager.LoadScene("KieronGameOverScene");
                        }
                    }
                    else
                    {
                        Debug.Log(1);
                        SceneManager.LoadScene("KieronGameOverScene");
                    }
                }
                else
                {
                    Debug.Log(2);
                    SceneManager.LoadScene("KieronGameOverScene");
                }
            }
        }
        
        egg.Controls();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Danger")
        {
            Debug.Log(3);
            SceneManager.LoadScene("KieronGameOverScene");
        }
    }

}