using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerVoiceManager : MonoBehaviour
{
    public GameObject InnerDialogue;
    public Text InnerText;
    public Image InnerVoice;

    private string sentence;

    public void StartInnerDialogue(string dialogue)
    {
        InnerDialogue.SetActive(true);

        InnerText.text = "";

        sentence = dialogue;

        StartCoroutine(FillInnerDialogue(sentence));

    }

    public void ForcedExit()
    {
        StopCoroutine(FillInnerDialogue(sentence));
        InnerDialogue.SetActive(false);
    }

    IEnumerator FillInnerDialogue(string dialogue)
    {

        string aux = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            aux += letter;
            InnerText.text = aux;

            yield return new WaitForEndOfFrame();

        }

    }

}
