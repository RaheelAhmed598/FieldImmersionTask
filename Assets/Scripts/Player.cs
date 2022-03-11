using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
	//player physics components
    Rigidbody rb;

	//Linearly interpolates between player shape in x and y.
    public float lerpValue = 4;

	//max and min shape shift value 
    public float minY = 1, maxY;
    public float minX, maxX;

	// player speed 
    public float speed = 4;

    void Start()
    {
        cam = Camera.main;

	//getting the physics components
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
	//player movement direction with speed 
        rb.velocity = Vector3.forward * speed * Time.deltaTime;

	//user Input (Mouse left click)
        if(Input.GetButton("Fire1"))
        {
		//changing the scale of the player method
            ChangeScale();
        }
    }

	//method to change the scale in x and y
    public void ChangeScale()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

	//Transforms a point from screen space into world space
        Vector3 moveVec = cam.ScreenToWorldPoint(mousePos);

	//The scale of the transform relative to the GameObject.
        float x = transform.localScale.x;
        moveVec.z = transform.localScale.z;
        moveVec.y *= 2f;
        Debug.Log("Where is the problem?");

	//Use Clamp to restrict a value to a range that is defined by the min and max values.
        moveVec.y = Mathf.Clamp(moveVec.y, minY, maxY);
        x = 10 / moveVec.y;

        Debug.Log("Where is the problem?");
        moveVec.x = Mathf.Clamp(x, minX, maxX);

        transform.localScale = moveVec;
       

    }
}
