using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    public LampBlink lampBlink;
    public ArrowButtons arrowButtons;
    public Button submitButton;

    private Dictionary<string, float> correctAnswers = new Dictionary<string, float>
    {
        {"dobel", 3.505f}, {"pijit", 3.515f}, {"riset", 3.518f}, {"gatal", 3.522f},
        {"acawi", 3.532f}, {"fungi", 3.535f}, {"kadet", 3.537f}, {"dadih", 3.542f}, 
        {"kakao", 3.543f}, {"ciduk", 3.545f}, {"rubin", 3.552f}, {"bahna", 3.555f},
        {"detas", 3.565f}, {"kubul", 3.572f}, {"tepik", 3.575f}, {"kilus", 3.582f},
        {"rajin", 3.592f}, {"abaka", 3.595f}, {"istri", 3.600f}, {"pulen", 3.605f},
        {"barut", 3.615f}, {"setal", 3.619f}
    };

    private void Start()
    {
        submitButton.interactable = true;
    }

    public void SubmitButtonClick()
    {
        string currentWord = lampBlink.GetRandomWord();
        float currentFrequency = GetCurrentFrequency();

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

    private float GetCurrentFrequency()
    {
        int freqIndex = arrowButtons.GetFrequencyIndex();
        if (freqIndex >= 0 && freqIndex < arrowButtons.GetFrequencyListCount())
        {
            return arrowButtons.GetFrequencyAtIndex(freqIndex);
        }
        return 0f;
    }
}
