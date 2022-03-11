using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    Rigidbody rb;

    public float lerpValue = 4;
    public float minY = 1, maxY;
    public float minX, maxX;
    public float speed = 4;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rb.velocity = Vector3.forward * speed * Time.deltaTime;

        if(Input.GetButton("Fire1"))
        {
            ChangeScale();
        }
    }

    public void ChangeScale()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 moveVec = cam.ScreenToWorldPoint(mousePos);
        float x = transform.localScale.x;
        moveVec.z = transform.localScale.z;
        moveVec.y *= 2f;
        Debug.Log("Where is the problem?");
        moveVec.y = Mathf.Clamp(moveVec.y, minY, maxY);
        x = 10 / moveVec.y;

        Debug.Log("Where is the problem?");
        moveVec.x = Mathf.Clamp(x, minX, maxX);

        transform.localScale = moveVec;
       

    }
}
