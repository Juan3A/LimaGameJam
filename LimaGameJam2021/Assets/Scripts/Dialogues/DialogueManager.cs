using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private Queue<string> names;


    private bool StartedTalking = false;

    public GameObject dialogueBox;
    public Text dialogueText;
    public Text dialogueName;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && StartedTalking)
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        StartedTalking = true;

        dialogueBox.SetActive(true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        StopAllCoroutines();
        StartCoroutine(FillDialogue(sentence,name));

    }

    IEnumerator FillDialogue(string sentence,string name)
    {
        dialogueText.text = "";
        dialogueName.text = name;

        string aux = "";

        foreach (char letter in sentence.ToCharArray())
        {
            aux += letter;

            dialogueText.text = aux;


            yield return new WaitForEndOfFrame();

        }


    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        StartedTalking = false;

        dialogueName.text = "";
        dialogueText.text = "";
    }


}
