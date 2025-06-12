using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load or switch scenes

public class LoadMenu : MonoBehaviour
{
    // This public method can be connected to a UI button's OnClick event
    // It loads a scene named "MainMenu"
    public void getMainMenu()
    {
        // Tells Unity to switch to the scene called "MainMenu"
        // Make sure "MainMenu" is added to the Build Settings (File → Build Settings)
        SceneManager.LoadScene("MainMenu");
    }
}