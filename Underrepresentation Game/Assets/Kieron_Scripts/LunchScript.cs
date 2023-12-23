using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LunchScript : MonoBehaviour
{
    public GameObject lid;
    public GameObject winScreen;
    public GameObject loseScreen;
    public bool safe = true;
    public int mouthfuls = 0;
    public float decrease = .1f;
    public int distracted = 0;
    public float maxDistracts;
    private int recharge = 0;
    public bool distrubed;

    private float mouseX, mouseY;
    Vector3 mousePosition;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (distracted == maxDistracts)
        {
            //SceneManager.LoadScene(2)
            Destroy(lid);
            loseScreen.SetActive(true);
            Destroy(gameObject);
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mousePosition.x;
        mouseY = mousePosition.y;

        if (!safe & recharge == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D collider = Physics2D.OverlapPoint(mousePosition);
                if (collider)
                {
                    if (gameObject == collider.transform.gameObject)
                    {
                        transform.localScale = new Vector3(scale.x - decrease, scale.y - decrease, scale.z);
                        scale = transform.localScale;

                        mouthfuls++;
                        if (distrubed)
                        {
                            recharge = mouthfuls;
                        }
                        Debug.Log("click");
                        //safe = true;
                    }
                    /*if (lid = collider.transform.gameObject)
                    {
                        Destroy(lid);
                    }*/
                }
            }
        }

        if (scale.x < decrease || scale.y < decrease)
        {
            Destroy(lid);
            winScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.gameObject.tag == "Safe")
        {
            safe = false;
        }
    }

    public void Distract()
    {
        distracted++;
        Debug.Log(distracted);
        recharge--;
        //button.SetActive(false);
        //safe = false;
    }
}
