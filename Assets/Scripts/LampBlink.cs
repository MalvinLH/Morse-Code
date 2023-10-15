using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlink : MonoBehaviour
{
    private Dictionary<char, string> morseCodeDictionary = MorseCodeData.morseCodeDictionary;
    private string[] wordVariations = MorseCodeData.wordVariations;
    
    private float dotDuration = 0.5f;   // durasi titik adalah satu satuan
    private float dashDuration = 1.5f;  // durasi tanda hubung adalah tiga satuan
    private float symbolPause = 0.5f;   // jarak antar simbol dari huruf yang sama adalah satu satuan
    private float letterPause = 1.5f;   // jarak antar huruf adalah tiga satuan
    private float wordPause = 3.5f;     // jarak antar kata adalah tujh satuan
    private string randomWord;

    public GameObject lampOn;
    public GameObject lampOff;
    public AudioSource audioSource;

    private Coroutine blinkingCoroutine;

    private void Start()
    {
        audioSource.Stop();
        randomWord = wordVariations[Random.Range(0, wordVariations.Length)];
        Debug.Log(randomWord);
        StartBlinking();
    }

    public string GetRandomWord()
    {
        return randomWord;
    }

    private void StartBlinking()
    {
        blinkingCoroutine = StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            foreach (char letter in randomWord)
            {
                if (morseCodeDictionary.TryGetValue(char.ToUpper(letter), out string morseCode))
                {
                    foreach (char morseSymbol in morseCode)
                    {
                        float duration = morseSymbol == '.' ? dotDuration : dashDuration;
                        yield return StartCoroutine(BlinkAndPlaySound(duration));
                        yield return new WaitForSeconds(symbolPause);
                    }
                }

                yield return new WaitForSeconds(letterPause);
            }

            yield return new WaitForSeconds(wordPause);
        }
    }

    private IEnumerator BlinkAndPlaySound(float duration)
    {
        lampOn.SetActive(true);
        lampOff.SetActive(false);

        audioSource.Play();

        yield return new WaitForSeconds(duration);

        lampOn.SetActive(false);
        lampOff.SetActive(true);
    }

    public void StopBlinking()
    {
        if (blinkingCoroutine != null)
            StopCoroutine(blinkingCoroutine);
    }
}