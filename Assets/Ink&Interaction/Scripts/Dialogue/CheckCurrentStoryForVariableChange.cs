using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentStoryForVariableChange : MonoBehaviour
{
    [SerializeField] private InkVariableState inkVariableState;
    [SerializeField] DialogueSystemManager dialogueSystemManager;
    public void CheckForVariableChange(string tagval)
    {
        switch (tagval)
        {
            case "isGreen":
                dialogueSystemManager.currentStory.variablesState[tagval] = inkVariableState.IsGreenVal;
                break;
        }

    }
}
