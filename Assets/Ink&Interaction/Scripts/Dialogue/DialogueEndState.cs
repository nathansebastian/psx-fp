using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueEndState : DialogueState
{
    public DialogueEndState(DialogueSystemManager system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        inDialogue = false;
        yield return new WaitForSeconds(.35f);
        _system.DialoguePanel.SetActive(false);
        _system.ControlManager.SetActive(true);
    }
    public override void UpdateState()
    {
    }
}
