using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
   
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject player;
    public Animator playerAnimator;
    public float delay;
    private string fullText = "";
    

    private Queue<string> dialogueQueue;

    IEnumerator ShowText(string currentText)
    {
        for (int i = 0; i < currentText.Length; i++)
        {
            fullText = currentText.Substring(0, i);
            dialogueText.text = fullText;
            yield return new WaitForSeconds(delay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueQueue = new Queue<string>();
      
    }

    public void startDialogue(string[] sentences)
    {
        dialogueQueue.Clear();
        dialogueUI.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;
        playerAnimator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (string currentLine in sentences)
        {
            dialogueQueue.Enqueue(currentLine);
        }
        displayNextSentence();
    }

    public void displayNextSentence()
    {

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            Debug.Log("There is nothing left in queue.....");
            return;
        }

        string currentLine = dialogueQueue.Dequeue();

        //dialogueText.text = currentLine;
        StartCoroutine(ShowText(currentLine));
    }
   
    void EndDialogue() 
    {
        dialogueUI.SetActive(false);
        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
