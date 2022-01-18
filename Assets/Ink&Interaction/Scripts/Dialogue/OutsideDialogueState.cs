using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OutsideDialogueState : DialogueState
{
    public OutsideDialogueState(DialogueSystemManager system) : base(system)
    {
    }


    public override IEnumerator Start()
    {
        Initialization();
        GetTMPFromChoices();
        yield break;
    }
    public override void UpdateState()
    {
    }
    private void Initialization()
    {
        inDialogue = false;
        _system.DialoguePanel.SetActive(false);
        _system.choicesText = new TextMeshProUGUI[_system.Choices.Length];
    }
    private void GetTMPFromChoices()
    {
        int index = 0;
        foreach (GameObject choice in _system.Choices)
        {
            _system.choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
}
