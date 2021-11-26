using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private int obstacleHealth = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleHealth <= 0)
        {
            Destroy(this.transform.gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Blast(Clone)")
        {
            obstacleHealth -= 1;
            Debug.Log("Blast hit obstacle!");
        }
    }
}