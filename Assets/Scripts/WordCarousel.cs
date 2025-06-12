using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WordCarousel : MonoBehaviour
{
    // UI Button to display the image representing the current word
    [SerializeField] Button Image;

    // Reference to the AudioManager GameObject that handles all sound playback
    [SerializeField] GameObject AudioManager;

    // Text input field where the child spells the word
    [SerializeField] GameObject SpellingText;

    // Panel shown when the child is prompted to spell the word
    [SerializeField] GameObject ShowWord;

    // Panel shown when the spelling is incorrect
    [SerializeField] GameObject TryAgainPanel;

    // Panel shown when the spelling is correct (celebration)
    [SerializeField] GameObject Congratulations;

    // Panel shown when the last word is completed
    [SerializeField] GameObject End;

    // Panel shown when the user asks to see the correct spelling
    [SerializeField] GameObject ShowAnswer;

    // Button used to display the correct image when showing the correct spelling
    [SerializeField] Button AnswerImage;

    // The actual TMP text field where the child's input is tracked
    [SerializeField] TextMeshProUGUI Text;

    // The TMP text field that displays the correct spelling (in uppercase)
    [SerializeField] TextMeshProUGUI AnswerSpelling;

    // Keeps track of which word the user is currently working on
    int currentkey;

    // Dictionary mapping word index to word string
    Dictionary<int, string> wordDict;

    // Called automatically when the scene starts
    void Start()
    {
        // Hide all optional panels at the beginning
        ShowWord.SetActive(false);
        TryAgainPanel.SetActive(false);
        Congratulations.SetActive(false);
        End.SetActive(false);
        ShowAnswer.SetActive(false);

        // Initialize the word dictionary with example words
        wordDict = new Dictionary<int, string>
        {
            { 1, "ball" },
            { 2, "bed" },
            { 3, "book" },
            { 4, "boy" },
            { 5, "car" },
            { 6, "cat" },
            { 7, "dog" },
            { 8, "girl" },
            { 9, "man" }
        };

        // Set the starting word
        currentkey = 1;
        setword(wordDict[currentkey]);
    }

    // Unused but available if needed in future
    void Update()
    {
    }

    // Sets the current word's image and audio clip based on the given word string
    void setword(string word)
    {
        // Set the audio clip for the word
        AudioManager.GetComponent<AudioManager>().setClip(word);

        // Load and display the corresponding image from the Resources folder
        Image.image.sprite = Resources.Load<Sprite>("WordSprites/Grade1/" + word);
    }

    // Enables the panel where the child is supposed to spell the word
    public void enablewordpanel()
    {
        Text.text = ""; // Clear previous input
        ShowWord.SetActive(true); // Show the spelling prompt panel
        AudioManager.GetComponent<AudioManager>().touchthepicture(); // Play audio cue
    }

    // Called when the child chooses to try again (resets input)
    public void tryagain()
    {
        Text.text = "";
    }

    // Called when the child submits their answer
    public void check()
    {
        // Compare typed input (in lowercase) with correct word
        if (Text.text.ToLower() == wordDict[currentkey])
        {
            // Hide the spelling panel
            ShowWord.SetActive(false);

            // If this was the last word, show the end screen
            if (currentkey == 9)
            {
                End.SetActive(true);
                StartCoroutine(AudioManager.GetComponent<AudioManager>().playEnd());
            }
            else
            {
                // Otherwise, show the congratulations panel
                Congratulations.SetActive(true);
                StartCoroutine(AudioManager.GetComponent<AudioManager>().playtada());
            }
        }
        else
        {
            // If incorrect, show the Try Again panel and play encouragement audio
            ShowWord.SetActive(false);
            TryAgainPanel.SetActive(true);
            AudioManager.GetComponent<AudioManager>().playEncourage();
        }
    }

    // Moves to the next word after a correct spelling
    public void setNext()
    {
        if (currentkey < 9) // Only proceed if more words are available
        {
            currentkey += 1;
            setword(wordDict[currentkey]); // Load new word and image
            Congratulations.SetActive(false); // Hide celebration panel
            enablewordpanel(); // Re-show spelling prompt
        }
    }

    // Moves to the next word after showing the answer
    public void setNextAfterShow()
    {
        if (currentkey < 9)
        {
            currentkey += 1;
            setword(wordDict[currentkey]); // Load next word
            ShowAnswer.SetActive(false); // Hide answer screen
            enablewordpanel(); // Re-show spelling prompt
        }
    }

    // Called when the child wants to try the word again after an incorrect attempt
    public void TryWordAgain()
    {
        TryAgainPanel.SetActive(false); // Hide Try Again panel
        enablewordpanel(); // Show the word again for a retry
    }

    // Called when the child chooses to reveal the correct word
    public void SeeTheWord()
    {
        TryAgainPanel.SetActive(false); // Hide Try Again panel

        // Load the correct image and show it
        AnswerImage.image.sprite = Resources.Load<Sprite>("WordSprites/Grade1/" + wordDict[currentkey]);

        // Show the correct spelling in uppercase
        AnswerSpelling.text = wordDict[currentkey].ToUpper();

        // Show the answer panel
        ShowAnswer.SetActive(true);

        // Play audio for the correct spelling
        StartCoroutine(AudioManager.GetComponent<AudioManager>().playShowAnswer(wordDict[currentkey]));
    }

    // Called when the child finishes all words and taps a button to return to the main menu
    public void end2menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}