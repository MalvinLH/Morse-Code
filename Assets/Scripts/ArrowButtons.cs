using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButtons : MonoBehaviour
{
    public List<GameObject> freqList;
    public Button leftArrow;
    public Button rightArrow;
    private int freqIndex = 0;

    private void Start()
    {
        leftArrow.onClick.AddListener(() => ChangeFrequencyIndex(-1));
        rightArrow.onClick.AddListener(() => ChangeFrequencyIndex(1));
        UpdateFrequencyVisibility();
    }

    private void ChangeFrequencyIndex(int offset)
    {
        freqList[freqIndex].SetActive(false);
        freqIndex = (freqIndex + offset + freqList.Count) % freqList.Count;
        freqList[freqIndex].SetActive(true);
    }

    private void UpdateFrequencyVisibility()
    {
        if (freqIndex >= 0 && freqIndex < freqList.Count)
            freqList[freqIndex].SetActive(true);
    }

    public int GetFrequencyIndex()
    {
        return freqIndex;
    }

    public int GetFrequencyListCount()
    {
        return freqList.Count;
    }

    public float GetFrequencyAtIndex(int index)
    {
        if (index >= 0 && index < freqList.Count)
            return float.Parse(freqList[index].name);
            
        return 0f;
    }

    public void DisableButtons()
    {
        leftArrow.interactable = false;
        rightArrow.interactable = false;
    }
}