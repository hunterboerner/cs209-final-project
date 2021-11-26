
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateX : MonoBehaviour
{

    public float moveSpeed = 0.1f;
    public float delta = 45f;
    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = startPos;
        newPos.x += delta * Mathf.Sin(Time.time * moveSpeed);
        transform.position = newPos;
    }
}
