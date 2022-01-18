using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueSystemManager : DialogueStateMachine
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private DialogueInkTagParser dialogueInkTagParser;
    [SerializeField] private CheckForCustomCommand checkForCustomCommand;
    [SerializeField] private DialogueDisplayAnimatorController dialogueDisplayAnimatorController;
    [SerializeField] private ControlManager controlManager;
    public TextMeshProUGUI[] choicesText;
    [SerializeField] private GameObject[] choices;
    public Story currentStory { get; private set; }
    public GameObject DialoguePanel => dialoguePanel;
    public TextMeshProUGUI DialogueText => dialogueText;
    public TextMeshProUGUI DialogueNameText => displayNameText;
    public DialogueInkTagParser DialogueInkTagParser => dialogueInkTagParser;
    public GameObject[] Choices => choices;
    public ControlManager ControlManager => controlManager;

    private void Start()
    {
        SetState(new OutsideDialogueState(this));
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        displayNameText.text = "???";
        //dialogueDisplayAnimatorController.EnterDialogue();
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        CallForDisableAnimations();
        SetState(new InDialogueState(this));
    }
    public void TriggerCheckForCommand()
    {
        string text = dialogueText.text;
        text = text.Trim();
        //string cleanedText = checkForCustomCommand.IfTextContainsCommand(text);
        //dialogueText.text = cleanedText;
    }
    public void CallForDisableAnimations()
    {
        dialogueDisplayAnimatorController.RefreshCycle();
    }
}
