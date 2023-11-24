using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public PlayerControls player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (gameObject.tag == "Food")
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.CheckAction();
                Debug.Log("Working");
            }
        }
    }
}
