using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueStateMachine : MonoBehaviour
{
    public DialogueState _state { get; protected set; }
    public void SetState(DialogueState state)
    {
        _state = state;
        StartCoroutine(_state.Start());
    }
    public virtual void Update()
    {
        _state.UpdateState();
    }
}
