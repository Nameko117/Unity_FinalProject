using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ballbehaver : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;
    private float moveX, moveY;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
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
    void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Fail":
            {
                ResetPosition();
                break;
            }
            case "CheckPoint":
            {
                startPosition = other.transform.position + new Vector3(0,2,0);
                break;
            }
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(startPosition);
        transform.rotation = new Quaternion();
    }
}
