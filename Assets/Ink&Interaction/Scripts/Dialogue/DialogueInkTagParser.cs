using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInkTagParser : MonoBehaviour
{
    [SerializeField] private DialogueSystemManager dialogueSystemManager;
    [SerializeField] private Dialogue_ColourSelection dialogue_ColourSelection;
    [SerializeField] private CheckCurrentStoryForVariableChange checkCurrentStoryForVariableChange;
    [SerializeField] private DialogueDisplayAnimatorController dialogueDisplayAnimatorController;
    private const string SPEAKERS_TAG = "speaker";
    private const string COLOUR_TAG = "colour";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string VARIABLE_CHANGE_TAG = "variable_change";

    public void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: "+ tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKERS_TAG:
                    dialogueSystemManager.DialogueNameText.text = tagValue;
                    Debug.Log("speaker = " + tagValue);
                    break;
                case PORTRAIT_TAG:
                    dialogueDisplayAnimatorController.PortraitAnimator.Play(tagValue);
                    Debug.Log("portrait = " + tagValue);
                    break;
                case LAYOUT_TAG:
                    dialogueDisplayAnimatorController.LayoutAnimator.Play(tagValue);
                    Debug.Log("layout = " + tagValue);
                    break;
                case COLOUR_TAG:
                    dialogue_ColourSelection.ColourSelection(tagValue);
                    break;
                case VARIABLE_CHANGE_TAG:
                    checkCurrentStoryForVariableChange.CheckForVariableChange(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but not currently handled: " + tag);
                    break;
            }
        }
    }
}
