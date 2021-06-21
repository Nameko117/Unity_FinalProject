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
        if(PlayerPrefs.HasKey("Save")) {
            string t = PlayerPrefs.GetString("Save");
            for(int i=0;i<4;i++) LvOpen[i] = t[i]=='1';
        }
        else {
            string t = "";
            for(int i=0;i<4;i++) t += LvOpen[i]?'1':'0';
            PlayerPrefs.SetString("Save", t);
        }
        GameObject[] LvButton = GameObject.FindGameObjectsWithTag("LvButton");
        for(int i=0;i<4;i++) LvButton[i].GetComponent<Button>().interactable = LvOpen[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void ResetSave()
    {
        string t = "";
        for(int i=0;i<4;i++) t += LvOpen[i]?'1':'0';
        PlayerPrefs.SetString("Save", t);
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
