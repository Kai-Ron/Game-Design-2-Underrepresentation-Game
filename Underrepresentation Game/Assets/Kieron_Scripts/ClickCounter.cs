using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    private bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked && gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
            //Debug.Log(clicked);
        }
    }

    public void Click()
    {
        if (!clicked)
        {
            clicked = true;
        }
    }
}
