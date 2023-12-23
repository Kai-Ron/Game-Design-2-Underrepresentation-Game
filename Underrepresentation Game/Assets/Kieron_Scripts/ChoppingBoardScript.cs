using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChoppingBoardScript : MonoBehaviour
{
    public GameObject food;
    public GameObject product;
    public CameraController camController;
    private Equipment equipment;
    public TMP_Text text;
    public int count;
    public int maxCount;
    public int lives = 3;
    private bool safe = false;

    void Start()
    {
        equipment = gameObject.GetComponent<Equipment>();
        text.text = lives.ToString() + " Lives";
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

    public void Damage()
    {
        lives--;
        text.text = lives.ToString() + " Lives";
        if(lives == 0)
        {
            Debug.Log("OOPS! Sorry:P");
            SceneManager.LoadScene("KieronGameOverScene");
        }
    }
}
