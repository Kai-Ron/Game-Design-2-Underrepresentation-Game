using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceSpawner : MonoBehaviour
{
    public GameObject grain;
    public int amount;
    public float radius = 2;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        do
        {
            Vector3 randomPos = Random.insideUnitCircle * radius;
            Instantiate(grain, randomPos, Quaternion.Euler(0,0,Random.Range(0.0f, 360.0f)));
            i++;
        } while (i<amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
