using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStoveBehavior : MonoBehaviour
{
    // based on https://www.youtube.com/watch?v=jjBeh2xLckA
    public Camera camera;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
        {
            StoveBehavior hitItem = hitInfo.collider.GetComponent<StoveBehavior>();
            if (hitItem != null && Input.GetKey(KeyCode.E))
            {
                hitItem.TurnOnStove();
                Debug.Log("You see the stove.");
            }
        }
    }
}
