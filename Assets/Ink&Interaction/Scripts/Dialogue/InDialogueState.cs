using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InDialogueState : DialogueState
{
    public InDialogueState(DialogueSystemManager system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        inDialogue = true;
        _system.DialoguePanel.SetActive(true);
        _system.ControlManager.SetActive(false);
        HideChoices();
        ContinueStory();
        yield break;
    }
    public override void UpdateState()
    {
        if (Input.GetKeyDown("e") || Input.GetKeyDown("space"))
        {
            //_system.CallForDisableAnimations();
            ContinueStory();
        }
    }
    public void HideChoices()
    {
        foreach (GameObject choice in _system.Choices)
        {
            choice.gameObject.SetActive(false);
        }
    }
    public void ContinueStory()
    {
        if (_system.currentStory.canContinue)
        {
            _system.DialogueText.text = _system.currentStory.Continue();
            _system.TriggerCheckForCommand();
            if (_system.currentStory.currentChoices.Count > 0)
            {
                _system.SetState(new InChoiceDialogueState(_system));
            }
            _system.DialogueInkTagParser.HandleTags(_system.currentStory.currentTags);
        }
        else
        {
            _system.SetState(new DialogueEndState(_system));
        }
            
    }
}
