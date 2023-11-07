using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitching : MonoBehaviour
{
   public void chang_button()
    {
        SceneManager.LoadScene("Titlescene");
    }
    public void chang_button_1()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
