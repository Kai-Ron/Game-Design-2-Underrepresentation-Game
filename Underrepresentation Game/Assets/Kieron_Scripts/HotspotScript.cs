using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotspotScript : MonoBehaviour
{
    public GameObject knife;
    public GameObject nextObject;
    public GameObject oldObject;
    public ChoppingBoardScript board;
    public int click;
    public float increase = 1.0f;
    private bool clickable = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(click))
        {
            if (clickable)
            {
                board.count++;
                knife.GetComponent<DangerScript>().speed = knife.GetComponent<DangerScript>().speed + increase;
                nextObject.SetActive(true);
                Destroy(oldObject);
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                board.Damage();
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("CLICK NOW");
        if (collider.transform.gameObject == knife)
        {
            clickable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("DONT CLICK");
        if (gameObject.activeSelf == true)
        {
            if (collider.transform.gameObject == knife)
            {
                clickable = false;
            }
        }
    }
}
