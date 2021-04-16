using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public ObjectInteraction currentObjectInteractionScript;
    public GameObject exclamationMark;
    public GameObject enemy;
    public Text itemText;
    public Text objectiveText = null;
    public GameObject stolenItemsTextBox;
    private int recoveredItems = 0;
    private string objective;
    
    // Update is called once per frame
    private void Start()
    {
        objective = "Talk to the lady.";
    }
    void Update()
    {
        objectiveText.text = objective;
        itemText.text = recoveredItems.ToString();
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            if (currentObjectInteractionScript.pickup == true)
            {
                currentObjectInteractionScript.PickUp();
                recoveredItems = recoveredItems + 1;
            }
            if (currentObjectInteractionScript.info == true)
            {
                currentObjectInteractionScript.Info();
            }
            if (currentObjectInteractionScript.talks == true)
            {

                if ((currentObjectInteractionScript.isStartingNPC == true) && (recoveredItems == 5))
                {
                    SceneManager.LoadScene("GameOver");
                    Debug.Log("E");
                }

                else { currentObjectInteractionScript.Dialogue(); }
            }
        }
        if (recoveredItems >= 5)
        {
            recoveredItems = 5;
            objective = "Return the lost items to the lady.";
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = other.gameObject;
            currentObjectInteractionScript = currentInterObj.GetComponent<ObjectInteraction>();
            exclamationMark.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("InterObject") == true)
        {
            currentInterObj = null;
            exclamationMark.SetActive(false);
            if (currentObjectInteractionScript.isStartingNPC == true)
            {
                objective = "Find and recover the lady's lost items.";
                stolenItemsTextBox.SetActive(true);
            }
            if (currentObjectInteractionScript.isEndNPC == true)
            {
                enemy.SetActive(false);
            }
        }
    }
}
