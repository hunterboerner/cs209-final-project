using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Marble")
        {
            Destroy(this.transform.gameObject);
            gameManager.Goals += 1;
        }
    }
}
