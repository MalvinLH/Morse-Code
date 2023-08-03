using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    public LampBlink lampBlink;
    public ArrowButtons arrowButtons;
    public Button submitButton;

    private Dictionary<string, float> correctAnswers = MorseCodeData.correctAnswers;

    private void Start()
    {
        submitButton.interactable = true;
    }

    public void SubmitButtonClick()
    {
        string currentWord = lampBlink.GetRandomWord();
        float currentFrequency = arrowButtons.GetCurrentFrequency();

        if (correctAnswers.ContainsKey(currentWord))
        {
            float correctFrequency = correctAnswers[currentWord];
            if (Mathf.Approximately(currentFrequency, correctFrequency))
            {
                Debug.Log("Correct!");
                lampBlink.StopBlinking();
                arrowButtons.DisableButtons();
                submitButton.interactable = false;
            }
            else
            {
                Debug.Log("Wrong Answer!");
            }
        }
    }
}