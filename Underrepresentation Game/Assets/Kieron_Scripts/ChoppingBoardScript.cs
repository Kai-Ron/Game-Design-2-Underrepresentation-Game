using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoardScript : MonoBehaviour
{
    public GameObject food;
    public GameObject product;
    public CameraController camController;
    private Equipment equipment;
    public int count;
    public int maxCount;
    private bool safe = false;

    void Start()
    {
        equipment = gameObject.GetComponent<Equipment>();
    }

    void Update()
    {
        if (count == maxCount)
        {
            gameObject.GetComponent<Equipment>().enabled = true;
            Destroy(food);

            count = 0;
        }

        if (Input.GetMouseButtonDown(0) && safe)
            {
                camController.playing = false;
                product.SetActive(true);
                Destroy(gameObject);
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Safe")
        {
            safe = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Safe")
        {
            safe = false;
        }
    }
}
