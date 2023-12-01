using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool opened = false;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    
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
}
