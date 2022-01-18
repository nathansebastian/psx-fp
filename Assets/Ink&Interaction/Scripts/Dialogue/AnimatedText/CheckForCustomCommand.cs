using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCustomCommand : MonoBehaviour
{

	[SerializeField] CommandsArray commandsArray;
	[SerializeField] private TextMeshRoot meshRoot;
	[SerializeField] private SplitDialogueText splitDialogue;

	private CommandIndexes[] commandArray;

    private void Start()
    {
		commandArray = commandsArray.CommandArray;
    }

    public string IfTextContainsCommand(string text)
	{
		meshRoot.enabled = true;
		for (int i = 0; i < commandArray.Length; i++)
		{
			if (text.Contains("<" + commandArray[i].Tag + ">") && text.Contains("</" + commandArray[i].Tag + ">"))
			{
				Debug.Log(i);
				splitDialogue.CycleNextIndex(i, commandArray.Length);
				text = splitDialogue.SplitCustomCommand(text, i, commandArray);
			}
			
		}
		return text;
	}
	public void RefreshTextAnim()
	{
		splitDialogue.RefreshNextIndex();
		WobblyText wobbly = GetComponent<WobblyText>();
		WibblyText wibbly = GetComponent<WibblyText>();

		wobbly.Disable();
		wibbly.Disable();
	}
}