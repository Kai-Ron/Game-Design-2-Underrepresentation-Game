using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disturbances : MonoBehaviour
{
    public LunchScript player;
    public GameObject bubble;
    private SpriteRenderer sprite;
    public int mouthfuls;
    private bool used = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!used && player.mouthfuls == mouthfuls)
        {
            sprite.enabled = true;
            //player.enabled = false;
            bubble.SetActive(true);
            used = true;
        }
    }
}
