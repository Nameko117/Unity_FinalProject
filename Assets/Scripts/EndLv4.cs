using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLv4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionExit(Collision other)
    {
        StartCoroutine(Countdown());

    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("START");
    }

}
