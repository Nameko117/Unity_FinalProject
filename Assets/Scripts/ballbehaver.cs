using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ballbehaver : MonoBehaviour
{   
    public Transform ball;
    public float turnspeed = 10.0f; 
    public float speed = 1.0f;  
    private Rigidbody rb;
    private float moveX, moveY,moveZ;
    public Vector3 startPosition;
    Collider selfCollider;
    public Material[] material;
    Renderer rend;
    private int mode = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        if (material.Length != 0)
        {
            rend.sharedMaterial = material[0];
        }
        
        
    }
    private void OnMove(InputValue inputValue)
    {
        Vector2 movevector = inputValue.Get<Vector2>();
        moveX = movevector.x;
        moveY = movevector.y;
    }
    // private void OnLook(InputValue inputValue)
    // {
    //     Vector2 Tmovevector = inputValue.Get<Vector2>();
    //     moveZ = Tmovevector.y;
    
    // }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        rb.AddForce(movement*speed);
    }
    // private void Update()
    // {
    //     StartCoroutine(turn());
    // }
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
        switch (other.tag)
        {
            case "Fail":
            {
                    if (material.Length != 0)
                    {
                        rend.sharedMaterial = material[0];
                    }
                    mode = 0;
                    ResetPosition();
                    break;
            }
            case "CheckPoint":
            {
                    startPosition = other.transform.position + new Vector3(0,2,0);
                    selfCollider = GetComponent<Collider>();
                    selfCollider.isTrigger = false;
                    break;
            }
            case "ChangePoint":
            {
                    if (material.Length == 0)
                    {
                        break;
                    }
                    else
                    {
                        mode += 1;
                        rend.sharedMaterial = material[mode % material.Length];
                        break;
                    }
                    
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
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision enter: " + other.transform.name);
        if (other.transform.name == "EndPoint"){
            selfCollider = GetComponent<Collider>();
            selfCollider.isTrigger = true;
        }

    }
    //  IEnumerator turn()
    //  {
        
    //      Vector3 Tmove =  Vector3.up * moveZ*100 ;
    //      ball.Rotate(Tmove * turnspeed * Time.deltaTime, Space.World);

    //      yield return null;
    //  }    
}
