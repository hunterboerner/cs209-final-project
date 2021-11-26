using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.51f;
    public LayerMask groundLayer;

    public GameObject blast;
    public float blastSpeed = 50f;

    private float fbInput;
    private float lrInput;
    
    private Rigidbody _rb;
    
    private SphereCollider _col;

    public GameBehavior gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        // Code for jumping
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBlast = Instantiate(blast, this.transform.position +
                new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();
            blastRB.velocity = this.transform.forward * blastSpeed;
        }
    }
    
    void FixedUpdate()
    {
        //Put code that moves the sprite using the RigidBody here
        Vector3 rotation = Vector3.up * lrInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * fbInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Obstacle" ||
            collision.gameObject.name == "Obstacle (1)" ||
            collision.gameObject.name == "Obstacle (2)" ||
            collision.gameObject.name == "X Mover" ||
            collision.gameObject.name == "Y Mover") {
            Debug.Log("Obstacle Hit!");
            gameManager.HP -= 1;
        }
    }

    private bool IsGrounded()
    {
        bool grounded = Physics.CheckSphere(_col.bounds.center,
            distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
    
}
