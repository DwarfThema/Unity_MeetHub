using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector2 clickPoint;
    public float dragSpeed = 30.0f;
    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x > 20)
        {
            active = false;
            transform.position = new Vector3(20f, transform.position.y, transform.position.z);
        }else if(transform.position.x < -20)
        {
            active = false;
            transform.position = new Vector3(-20f, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > -5)
        {
            active = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
        else if (transform.position.z < -50)
        {
            active = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 50);
        }
        else
        {
            active = true;
        }


            if (active)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    clickPoint = Input.mousePosition;
                }

                if (Input.GetMouseButton(0))
                {
                    Vector3 position = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);
                    position.z = position.y;
                    position.y = .0f;

                    Vector3 move = position * (Time.deltaTime * dragSpeed);

                    float y = transform.position.y;

                    transform.Translate(move);
                    transform.transform.position = new Vector3(transform.position.x, y, transform.position.z);
                }
            }
    }
}
