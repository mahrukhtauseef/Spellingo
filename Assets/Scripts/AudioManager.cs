using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Serialized AudioClips can be assigned directly in the Unity Inspector
    [SerializeField] AudioClip Intro;             // Introductory sound when the scene starts
    [SerializeField] AudioClip Welcome;           // Welcome message or greeting after intro
    [SerializeField] AudioClip ButtonPressed;     // Sound when any button is pressed
    [SerializeField] AudioClip Tada;              // Celebration sound for correct answer
    [SerializeField] AudioClip CongratSpeech;     // Voice-over congratulating the child
    [SerializeField] AudioClip Encourage;         // Encouragement sound for incorrect answers

    // Will be dynamically loaded based on the word the child is spelling
    AudioClip WordClip;

    // Called once at the start of the scene
    void Start()
    {
        // Begin playing intro and welcome sounds in sequence
        StartCoroutine(PlayClipsInSequence());
    }

    // Coroutine to play the intro and welcome sounds one after the other
    private IEnumerator PlayClipsInSequence()
    {
        // Play the intro clip
        this.GetComponent<AudioSource>().clip = Intro;
        this.GetComponent<AudioSource>().Play();
        // Wait for one-third of the intro clip to finish before continuing
        yield return new WaitForSeconds(Intro.length / 3);

        // Play the welcome clip next
        this.GetComponent<AudioSource>().clip = Welcome;
        this.GetComponent<AudioSource>().Play();
    }

    // Sets the WordClip based on the given word string (e.g., "cat" → "Sound/cat.wav")
    public void setClip(string word)
    {
        WordClip = Resources.Load<AudioClip>("Sound/" + word);
    }

    // Plays the button press sound
    public void playbuttonsound()
    {
        this.GetComponent<AudioSource>().clip = ButtonPressed;
        this.GetComponent<AudioSource>().Play();
    }

    // Plays the audio clip for the current word
    public void playWord()
    {
        Debug.Log("Playing the word");
        if (WordClip == null)
        {
            Debug.LogWarning("Could not load AudioClip");
        }

        this.GetComponent<AudioSource>().clip = WordClip;
        this.GetComponent<AudioSource>().Play();
    }

    // Plays the sound associated with tapping the picture to hear the word
    public void touchthepicture()
    {
        // Attempt to load the clip dynamically
        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/TouchPicture");

        // If clip is missing, log a warning
        if (this.GetComponent<AudioSource>().clip == null)
        {
            Debug.LogWarning("Could not load AudioClip");
        }

        // Play the clip
        this.GetComponent<AudioSource>().Play();
    }

    // Plays a preloaded encouragement clip
    public void playEncourage()
    {
        this.GetComponent<AudioSource>().clip = Encourage;

        if (this.GetComponent<AudioSource>().clip == null)
        {
            Debug.LogWarning("Could not load AudioClip");
        }

        this.GetComponent<AudioSource>().Play();
    }

    // Coroutine to play a two-part success sequence: Tada → Congratulations
    public IEnumerator playtada()
    {
        this.GetComponent<AudioSource>().clip = Tada;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(Tada.length);

        this.GetComponent<AudioSource>().clip = CongratSpeech;
        this.GetComponent<AudioSource>().Play();
    }

    // Coroutine to play a two-part end sequence: Tada → End message
    public IEnumerator playEnd()
    {
        this.GetComponent<AudioSource>().clip = Tada;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(Tada.length);

        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/End");
        this.GetComponent<AudioSource>().Play();
    }

    // Coroutine to play: spelling of the word → "Now you know" message
    public IEnumerator playShowAnswer(string word)
    {
        // Attempt to play the spelling version of the word (e.g., Sound/spellcat)
        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/spell" + word);
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);

        // Then play the follow-up message
        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/NowYouKnow");
        this.GetComponent<AudioSource>().Play();
    }
}