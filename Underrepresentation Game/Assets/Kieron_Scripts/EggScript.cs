using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EggScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Ingredient egg;
    public GameObject yolk;
    private GameObject instance;
    public TMP_Text text;
    public int lives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        egg = gameObject.GetComponent<Ingredient>();
        text.text = lives.ToString() + " Lives";
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
                            Damage();
                        }
                    }
                    else
                    {
                        Debug.Log(1);
                        Damage();
                    }
                }
                else
                {
                    Debug.Log(2);
                    Damage();
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
            Damage();
        }

        if (collider.transform.gameObject.tag == "Border")
        {
            Debug.Log(5);
            Damage();
        }
    }

    public void Damage()
    {
        lives--;
        text.text = lives.ToString() + " Lives";
        if(lives == 0)
        {
            Debug.Log("OOPS! Sorry:P");
            SceneManager.LoadScene("KieronGameOverScene");
        }
    }

}