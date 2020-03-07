using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject gunObj;

    Gun gun;
    
    Camera viewCamera;

    private void Start()
    {
        gun = gunObj.GetComponent<Gun>();
        viewCamera = Camera.main;
    }
    
    private void Update()
    {
        // Shoot Manual
        if (Input.GetButton("Fire1"))
        {
            gun.Fire();
        }

        // Rotate shooting device        
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector2 shootDir = mousePos - transform.position;

        float ang = Vector2.Angle(Vector2.right, shootDir);
        if (mousePos.y < transform.position.y) ang = ang + (2 * (180 - ang));
        transform.rotation = Quaternion.Euler(0, 0, ang);
    }
}
