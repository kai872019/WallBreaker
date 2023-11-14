using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitching : MonoBehaviour
{
   public void chang_button()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Titlescene");
    }
    public void chang_button_1()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Game Scene");
    }
   public  void chang_button_2()
    {
        
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Game Scene_2");
    }
    
    public void chang_button_3()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Game Scene_3");
    }
    
   
}
