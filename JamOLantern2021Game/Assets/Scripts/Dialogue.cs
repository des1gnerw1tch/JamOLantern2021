using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Animator dialogAnimator;
    public GameObject continueButton;

    void Start()
    {
        StartCoroutine(WriteSentence());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void NextSentence()
    {
        dialogAnimator.SetTrigger("Sip");
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}