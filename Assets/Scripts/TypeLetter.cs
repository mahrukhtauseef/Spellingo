using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeLetter : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component where the letters are being typed
    [SerializeField] TextMeshProUGUI Text;

    // This method is called when a letter button is pressed
    public void AddLetter()
    {
        // Check that the current length of the text is less than 5 characters
        // This prevents the user from typing more than 5 letters
        if (Text.text.Length < 5)
        {
            // Append the name of this GameObject to the Text field
            // Assumes that each letter button is named with the letter it represents (e.g., "A", "B", "C")
            Text.text += this.name;
        }
    }
}