using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for switching scenes

public class MenuScript : MonoBehaviour
{
    // Reference to an AudioSource component that plays the button click sound
    [SerializeField] AudioSource buttonpress;

    // Unity lifecycle method called once when the scene loads
    void Start()
    {
        // Nothing needed here for now, but it's available if needed in the future
    }

    // Called every frame — currently unused
    void Update()
    {
    }

    // Called when the Grade 1 button is pressed
    public void G1ButtonPressed()
    {
        // Use a coroutine to play the sound fully before loading the scene
        StartCoroutine(PlaySoundAndLoadScene("Grade1"));
    }

    // Coroutine that waits for the button sound to finish before loading a new scene
    private IEnumerator PlaySoundAndLoadScene(string sceneName)
    {
        buttonpress.Play(); // Play the button press sound
        yield return new WaitForSeconds(buttonpress.clip.length); // Wait for the full clip to finish
        SceneManager.LoadScene(sceneName); // Load the selected scene after the sound
    }

    // Called when the Grade 2 button is pressed
    public void G2ButtonPressed()
    {
        // Plays the sound and immediately loads the scene (may cut off sound early)
        buttonpress.Play();
        SceneManager.LoadScene("Grade2");
    }

    // Called when the Grade 3 button is pressed
    public void G3ButtonPressed()
    {
        // Plays the sound and immediately loads the scene (may cut off sound early)
        buttonpress.Play();
        SceneManager.LoadScene("Grade3");
    }
}