using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{   
    public Transform cam;
    public float turnspeed = 10.0f; 
    private float moveZ;
    public GameObject ball;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.transform.position;
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    private void OnLook(InputValue inputValue)
    {
        Vector2 movevector1 = inputValue.Get<Vector2>();
        moveZ = movevector1.y; 
        // Debug.Log("movevector1.x"); 
    }
    void LateUpdate()
    {
        transform.position = ball.transform.position + offset;
    }
    private void Update()
    {
        StartCoroutine(turn());
    }
    IEnumerator turn()
     {
        
         Vector3 move =  Vector3.up * moveZ*10 ;
         cam.Rotate(move * turnspeed * Time.deltaTime, Space.World);
         yield return null;
     }     
}
