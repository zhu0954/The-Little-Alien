using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartText : MonoBehaviour {

	public GameObject DialoguePanel;
	public Text DialogueText;
	public string[] dialogue;
	public int index;

    public GameObject contButton;

	public float wordSpeed;
	public bool playerIsClose;


	void Update () 
    {
		if(Input.GetKeyDown(KeyCode.D) && playerIsClose) 
        {
            if (DialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(DialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

	}

    public void zeroText()
    {
        DialogueText.text = " ";
        index = 0;;
        DialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false) ;
        if(index < dialogue.Length - 1) 
        { 
            index++;
            DialogueText.text = " ";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText() ;
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
