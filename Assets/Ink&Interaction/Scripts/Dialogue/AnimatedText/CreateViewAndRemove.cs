using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
public class CreateViewAndRemove : MonoBehaviour
{
	[SerializeField] private PrototypeBasicInkScript basicInkScript;

	[SerializeField] private TextMeshRoot meshRoot;
	[SerializeField] private TextMeshProUGUI textMPPrefab;
	[SerializeField] private Transform buttonPosition;
	[SerializeField] private Transform dialoguePosition;
	[SerializeField] private Button buttonPrefab = null;
	public void OnClickChoiceButton(Choice choice, Story story)
	{
		story.ChooseChoiceIndex(choice.index);
		basicInkScript.RefreshView();
	}

	public void CreateContentView(string text)
	{
		TextMeshProUGUI storyText = Instantiate(textMPPrefab) as TextMeshProUGUI;
		meshRoot.textMesh = storyText;
		storyText.text = text;
		storyText.transform.SetParent(dialoguePosition, false);
	}

	public Button CreateChoiceView(string text)
	{
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(buttonPosition, false);
		TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
		choiceText.text = text;
		HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		layoutGroup.childForceExpandHeight = false;
		return choice;
	}
	public void RemoveChildrens(CommandIndexes[] commandArray)
	{
		RemoveChildren(buttonPosition, commandArray);
		RemoveChildren(dialoguePosition, commandArray);
	}

	public void RemoveChildren(Transform parent, CommandIndexes[] commandArray)
	{
		for (int i = 0; i < commandArray.Length; i++)
		{
			commandArray[i].TextEffectClass.Disable();
		}
		meshRoot.enabled = false;
		int childCount = parent.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(parent.GetChild(i).gameObject);
		}
	}
}
