using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float mouseX, mouseY;
    public GameObject food, tool;
    public bool equipped = false;
    private Ingredient ingredient;
    private Equipment equipment;
    private Vector3 mousePosition;
    private bool mixing = false;
    private int cracked = 0;
    private bool safe = false;
    int goal = 250;
    int total = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        //mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mousePosition.x;
        mouseY = mousePosition.y;

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);
            //Debug.Log(collider.transform.gameObject.tag);
            if (equipped)
            {
                if (tool&food)
                {
                    Pouring();
                }
                else if (ingredient.safe)
                {
                    CheckAction();
                }
            }
            else if (collider)
            {
                if (!equipped && (collider.transform.gameObject.tag == "Food"))
                {
                    food = collider.transform.gameObject;
                    ingredient = food.GetComponent<Ingredient>();
                    //ingredient.tool.SetActive(true);
                    equipped = true;
                }
                else if (!equipped && (collider.transform.gameObject.tag == "Tool"))
                {
                    tool = collider.transform.gameObject;
                    equipped = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (equipped && food)
            {
                food = null;
                equipped = false;
            }
            if (equipped && tool)
            {
                tool = null;
                equipped = false;
            }
        }

        if (equipped && tool)
        {
            tool.transform.position = new Vector3(mouseX, mouseY, 0);
        }
        
        if (equipped && food)
        {
            food.transform.position = new Vector3(mouseX, mouseY, 0);
        }
        
        if (mixing)
        {
            Mixing();
        }
    }

    public void CheckAction()
    {
        Debug.Log("Working");
        switch (ingredient.name)
        {
            case "Rice":
            {
                Pouring();
                break;
            }
            case "Egg":
            {
                Cracking();
                break;
            }
            case "Chicken":
            {
                Chopping();
                break;
            }
            case "Carrots":
            {
                Chopping();
                break;
            }
            case "Onion":
            {
                Chopping();
                break;
            }
            case "Peas":
            {
                Pouring();
                break;
            }
        }
    }

    public void Cracking()
    {
        Instantiate(ingredient.product, new Vector3(mouseX, mouseY, 0), Quaternion.Euler(0,0,0));
        food.SetActive(false);
        food = null;
        equipped = false;
        //Debug.Log("You Win!");
        cracked++;
        if(cracked >= 4)
        {
            mixing = true;
        }
        else
        {
            ingredient = null;
        }
    }

    public void Chopping()
    {
        
    }

    public void Mixing()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);
        if(collider)
        {
            if (collider.transform.gameObject.tag == "Product")
            {
                if ((Mathf.Abs(Input.GetAxisRaw("Mouse X") * 10)) >= 1 || (Mathf.Abs(Input.GetAxisRaw("Mouse Y") * 10)) >= 1)
                {
                    total++;
                }
                Debug.Log(total);
            }
        }

        if (total > goal)
        {
            food = Instantiate(ingredient.productFin, ingredient.area.transform.position, Quaternion.Euler(0,0,0));
            tool = ingredient.area;
            equipped = true;
            mixing = false;
            Debug.Log("You Win!");
        }
    }

    public void Pouring()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);
        if (collider)
        {
            if(collider.transform.gameObject.tag == "Safe")
            {
                Debug.Log("Safe");
            }
        }
    }

    public void Serving()
    {
        
    }

    public void Spreading()
    {
        
    }
}
