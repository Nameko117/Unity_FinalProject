using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class ballbehaver : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMove(InputValue inputValue)
    {
        Vector2 movevector = inputValue.Get<Vector2>();
        moveX = movevector.x;
        moveY = movevector.y;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        rb.AddForce(movement*speed);
    }
    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("down");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("right");
        }
    }*/
}
