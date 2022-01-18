using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
public class InChoiceDialogueState : DialogueState
{
    public InChoiceDialogueState(DialogueSystemManager system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        inDialogue = true;
        DisplayChoices();
        yield break;
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices = _system.currentStory.currentChoices;
        ChoiceDisplayLimitCheck(currentChoices);

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            _system.Choices[index].gameObject.SetActive(true);
            _system.choicesText[index].text = choice.text;
            index++;
        }
        HideChoiceDisplay(index);
    }

    private void ChoiceDisplayLimitCheck(List<Choice> _currentChoices)
    {
        if (_currentChoices.Count > _system.Choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + _currentChoices.Count);
        }
    }
    private void HideChoiceDisplay(int _index)
    {
        for (int i = _index; i < _system.Choices.Length; i++)
        {
            _system.Choices[i].gameObject.SetActive(false);
        }
    }
}
