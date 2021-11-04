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
    private bool startDialog = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startDialog)
            {
                dialogAnimator.SetTrigger("Enter");
                startDialog = false;
            }
            else
            {
                NextSentence();
            }
        }
    }

    void NextSentence()
    {
        if (index <= sentences.Length - 1)
        {
            textDisplay.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            dialogAnimator.SetTrigger("Sip");
            textDisplay.text = "";
            dialogAnimator.SetTrigger("Exit");
            index = 0;
            startDialog = true;
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