using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public bool dialogueIsPlaying { get; private set;}
    private bool lockInteractButton = false;

    private DialogueState _currentState;
    public static DialogueManager instance { get; private set; }



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager in the scene");
        }
        instance = this;
    }

    public void SetState(DialogueState state)
    {
        _currentState = state;
        StartCoroutine(_currentState.Start());
    }

    public static DialogueManager GetInstance()
    {

        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        lockInteractButton = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        //StartCoroutine(_currentState.InDialogue());
    }
    private void Update()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            dialogueIsPlaying = true;
        }
        else 
        {
            dialogueIsPlaying = false;
        }
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        // handle continuing to the next line in the dialogue when submit is pressed
        // NOTE: The 'currentStory.currentChoiecs.Count == 0' part was to fix a bug after the Youtube video was made
        InteractButton();
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Debug.Log("EnterDialogueMode");
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();

    }
    IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        //dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
            StartCoroutine(ExitDialogueMode());
    }
    private void DisplayChoices()
    {
        if (currentStory.currentChoices.Count > 0)
            LockInteractButton();
        else
            UnlockInteractButton();
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //StartCoroutine(SelectFirstChoice());
    }



    private void InteractButton()
    {
        if (Input.GetKeyDown("e")&& lockInteractButton == false)
        {
            ContinueStory();
        }
    }
    private void LockInteractButton()
    {
        lockInteractButton = true;
    }
    private void UnlockInteractButton()
    {
        lockInteractButton = false ;
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }
}
