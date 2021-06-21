using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour
{
    public static bool[]  LvOpen = {true, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] LvButton = GameObject.FindGameObjectsWithTag("LvButton");
        for(int i=0;i<4;i++) LvButton[i].GetComponent<Button>().interactable = LvOpen[i];
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
    public void BackTitle()
    {       
        SceneManager.LoadScene(0);
    }
}
