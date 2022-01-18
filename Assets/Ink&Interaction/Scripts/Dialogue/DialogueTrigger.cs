using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private DialogueSystemManager dialogueSystemManager;
    [SerializeField] private GameObject dialoguePanel;
    //[SerializeField] private QuestionColour questionColour;
    private bool playerInRange;



    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        
        if (playerInRange && !dialoguePanel.activeInHierarchy)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                dialogueSystemManager.EnterDialogueMode(inkJSON);
                dialogueSystemManager.SetState(new InDialogueState(dialogueSystemManager));
                //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                
            }
        }
        
        /*if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                Debug.Log(inkJSON);
            }
        }*/
        else
            visualCue.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
