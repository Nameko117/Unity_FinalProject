using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lv1ButtonClick()
    {       
        SceneManager.LoadScene(2);
    }
    public void Lv2ButtonClick()
    {       
        SceneManager.LoadScene(3);
    }    
    public void Lv3ButtonClick()
    {       
        SceneManager.LoadScene(4);
    }
    public void Lv4ButtonClick()
    {       
        SceneManager.LoadScene(5);
    }
}
