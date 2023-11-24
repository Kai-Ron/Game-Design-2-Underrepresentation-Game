using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingredient : MonoBehaviour
{
    //private Rigidbody2D rb;
    public GameObject /*tool,*/ product, productFin, area;
    public string name;
    public int amount;
    public PlayerControls player;
    public bool safe = false;
    //public bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.equipped && !safe)
        {
            //SceneManager.LoadScene("KieronGameOverScreen");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject == area)
        {
            safe = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.gameObject == area)
        {
            safe = false;
        }
    }
}
