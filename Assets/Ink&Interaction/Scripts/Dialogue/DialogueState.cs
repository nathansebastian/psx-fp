using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public abstract class DialogueState : MonoBehaviour
{
    protected readonly DialogueSystemManager _system;
    protected TextMeshProUGUI[] choicesText;
    public bool inDialogue {get; protected set;}
    public DialogueState(DialogueSystemManager system)
    {
        _system = system;
    }
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual void UpdateState()
    {
        
    }
    /*public virtual IEnumerator InDialogue()
    {
        yield break;
    }
    public virtual IEnumerator InChoice()
    {
        yield break;
    }
    public virtual IEnumerator OutOfDialogue()
    {
        yield break;
    }*/
}
