using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool opened = false;
    public bool playing = false;
    private bool finished = false;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    void Update()
    {
        if (playing)
        {
            LeftArrow.SetActive(false);
            RightArrow.SetActive(false);

            finished = true;
        }
        else if (!playing && finished)
        {
            RightArrow.SetActive(true);
            LeftArrow.SetActive(true);

            finished = false;
        }
    }
    
    public void Open(float distance)
    {
        if(!opened && distance < 0)
        {
            LeftArrow.SetActive(false);
        }
        else if(!opened && distance > 0)
        {
            RightArrow.SetActive(false);
        }
        else if(distance < 0)
        {
            RightArrow.SetActive(true);
        }
        else if(distance > 0)
        {
            LeftArrow.SetActive(true);
        }
        
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        opened = !opened;
    }

    public void Close(float distance)
    {
        if(!opened && distance < 0)
        {
            LeftArrow.SetActive(false);
        }
        else if(!opened && distance > 0)
        {
            RightArrow.SetActive(false);
        }
        else if(distance < 0)
        {
            RightArrow.SetActive(true);
        }
        else if(distance > 0)
        {
            LeftArrow.SetActive(true);
        }
        
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        opened = !opened;
        playing = true;
    }
}
