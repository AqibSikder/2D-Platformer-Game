using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialAI : MonoBehaviour
{
    public TMP_Text tutorialText; 

    public string[] instructions; // Array to hold multiple instructions for each NPC
    private int currentIndex = 0; // Index to track the current instruction

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowNextInstruction();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentIndex = 0; // Reset the instruction index when the player leaves
            tutorialText.gameObject.SetActive(false); // Hide tutorial text when player leaves object
        }
    }

    void ShowNextInstruction()
    {
        if (currentIndex < instructions.Length)
        {
            tutorialText.gameObject.SetActive(true); // Show tutorial text
            tutorialText.text = instructions[currentIndex]; // Show current instruction

            currentIndex++; // Move to next instruction
        }
        else
        {
            currentIndex = 0; // Reset the index to loop through the instructions again
            tutorialText.gameObject.SetActive(false); // Hide tutorial text if all instructions are shown
        }
    }
}


