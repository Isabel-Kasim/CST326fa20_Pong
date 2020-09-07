using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public bool juicy = false;

    public void StartMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    
}
