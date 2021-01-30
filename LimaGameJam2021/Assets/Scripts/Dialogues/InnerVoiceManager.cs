using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnerVoiceManager : MonoBehaviour
{
    public GameObject InnerDialogue;
    public Text InnerText;
    public Image InnerVoice;
    public Staticproblem statics;

    private string sentence;

    public void StartInnerDialogue(string dialogue)
    {
        InnerDialogue.SetActive(true);

        statics.gameObject.SetActive(true);

        InnerText.text = "";

        sentence = dialogue;

        StartCoroutine(StaticTime(3f));

    }

    private void continueStarting()
    {
        StartCoroutine(FillInnerDialogue(sentence));
    }

   IEnumerator StaticTime(float timeit)
    {
        statics.PlayIt();

        yield return new WaitForSeconds(timeit);

        statics.StopIt();

        statics.gameObject.SetActive(false);

        continueStarting();
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
