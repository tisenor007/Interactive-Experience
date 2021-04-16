using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public bool isStartingNPC;
    public bool isEndNPC;
    [Header ("Used for objects that give simple info about themselves")]
    public bool info;
    public string message;
    private Text infoText;

    [Header ("This object can be picked up")]
    [Space]
    public bool pickup;

    [Header("Used for NPC dialogue, with multiple custscenes")]
    [Space]
    public bool talks;
    [TextArea]
    [Header("Cannot be bigger than 231 characters!")]
    public string[] sentences;

    public void PickUp()
    {
        //Debug.Log("Item picked up " + this.gameObject.name);
        this.gameObject.SetActive(false);
    }

    public void Info()
    {
        //Debug.Log(message);
        StartCoroutine(ShowInfo(message, 2f));
    }
    public void Dialogue()
    {
        //Debug.Log("This person works");
        FindObjectOfType<DialogueManager>().startDialogue(sentences);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        infoText.text = message;
        yield return new WaitForSeconds(delay);
        infoText.text = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
