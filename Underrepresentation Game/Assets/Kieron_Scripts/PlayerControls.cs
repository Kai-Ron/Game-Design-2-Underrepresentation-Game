using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    /*private bool mixing = false;
    private int cracked = 0;
    int goal = 250;
    int total = 0;*/
    

    /*public void CheckAction()
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
    }*/

    /*public void Cracking()
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
    }*/

    public void Chopping()
    {
        
    }

    /*public void Mixing()
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
    }*/

    /*public void Pouring()
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
    }*/

    public void Serving()
    {
        
    }

    public void Spreading()
    {
        
    }
}
