using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour {

    public GameObject DialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject ContinueButton;
    public float wordSpeed;
    public bool playerIsClose;

   
    private void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            if(DialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            
        }
        if(dialogueText.text == dialogue[index])
        {
            ContinueButton.SetActive(true);
        }
    }
    public void zeroText()
    {
        dialogueText.text = " ";
        index = 0;
        DialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        ContinueButton.SetActive(false);

        if(index < dialogue.Length -1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

    

}
