using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using Ink.Runtime;
public class PrototypeBasicInkScript : MonoBehaviour
{
	public static event Action<Story> OnCreateStory;

	private Story story;

	private Dictionary<string, CommandIndexes> commandDictionary = new Dictionary<string, CommandIndexes>();
	private CommandIndexes[] commandArray = new CommandIndexes[2];
	public CommandIndexes[] CommandArray => commandArray;
	[SerializeField] private TextAsset inkJSONAsset = null;
	[SerializeField] private TextMeshProUGUI characterNameText;
	[SerializeField] private Button continueButton;
	[SerializeField] private TextMeshRoot meshRoot;

	[SerializeField] private CreateViewAndRemove createView;
	[SerializeField] private SplitDialogueText splitDialogue;
	private string newString;
	private string[] leftList;
	void Awake()
	{
		FillCommandArray();
		StartStory();
	}
	void StartStory() {
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);

		RefreshView();
	}
	public void RefreshView() {

		continueButton.interactable = true;
		createView.RemoveChildrens(commandArray);
		if (story.canContinue)
		{
			string text = story.Continue();
			text = text.Trim();
			meshRoot.enabled = true;
			for (int i = 0; i < commandArray.Length; i++)
			{
				if (text.Contains("<" + commandArray[i].Tag + ">") && text.Contains("</" + commandArray[i].Tag + ">"))
				{
					splitDialogue.CycleNextIndex(i, commandArray.Length);
					text = splitDialogue.SplitCustomCommand(text, i, commandArray);
				}
			}
			return;
		}
		DisplayChoicesOrDisplayEnd();
	}

	void FillCommandArray()
	{
		CommandIndexes commandX = new CommandIndexes("x", GetComponent<WobblyText>());
		CommandIndexes commandW = new CommandIndexes("w", GetComponent<WibblyText>());
		commandArray[0] = commandX;
		commandArray[1] = commandW;
	}
	void DisplayChoicesOrDisplayEnd()
	{
		if (story.currentChoices.Count > 0)
		{
			characterNameText.text = "<i>Me</i>";
			continueButton.interactable = false;
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = createView.CreateChoiceView(choice.text.Trim());
				button.onClick.AddListener(delegate
				{
					createView.OnClickChoiceButton(choice, story);
				});
			}
		}
		else
		{
			characterNameText.text = "";
			continueButton.interactable = false;
			Button choice = createView.CreateChoiceView("End of story.\nRestart?");
			splitDialogue.RefreshNextIndex();
			choice.onClick.AddListener(delegate
			{
				Debug.Log("Start Story");
				StartStory();
			});
		}
	}
	/*void BasicSplit(string text)
	{
		if (text.Contains(":"))
		{
			string[] _tempList = text.Split(':');
			createView.CreateContentView(_tempList[1], textMPPrefab, meshRoot, dialoguePosition);
			characterNameText.text = _tempList[0];
			nameText.text = _tempList[0];
		}
		else
		{
			characterNameText.text = "";
			createView.CreateContentView(text, textMPPrefab, meshRoot, dialoguePosition);
		}
	}
	string SplitCustomCommand(string text,int  i, int nextIndex)
	{
		if (text.Contains(":"))
		{
			string[] _tempList = text.Split(':');
			newString = _tempList[1].Replace("<i>", "").Replace("</i>", "").Replace("<b>", "").Replace("</b>", "").Replace("<" + commandArray[nextIndex].Tag + ">", "").Replace("</" + commandArray[nextIndex].Tag + ">", "");
			string[] rightList = newString.Split(new string[] { "<" + commandArray[i].Tag + ">" }, StringSplitOptions.None);
			leftList = rightList[1].Split(new string[] { "</" + commandArray[i].Tag + ">" }, StringSplitOptions.None);
			//Debug.Log(leftList[0]);
			commandArray[i].firstIndex = newString.IndexOf("<" + commandArray[i].Tag + ">");
			commandArray[i].lastIndex = (newString.IndexOf("<" + commandArray[i].Tag + ">") + leftList[0].Length);
		}
		else
		{
			newString = text.Replace("<i>", "").Replace("</i>", "").Replace("<b>", "").Replace("</b>", "");
			string[] rightList = newString.Split(new string[] { "<" + commandArray[i].Tag + ">" }, StringSplitOptions.None);
			leftList = rightList[1].Split(new string[] { "</" + commandArray[i].Tag + ">" }, StringSplitOptions.None);
			commandArray[i].firstIndex = text.IndexOf("<" + commandArray[0].Tag + ">");
			Debug.Log(leftList[0]);
			commandArray[i].lastIndex = (text.IndexOf("<" + commandArray[0].Tag + ">") + leftList[0].Length);
		}
		text = text.Replace("<" + commandArray[i].Tag + ">", "").Replace("</" + commandArray[i].Tag + ">", "");
		commandArray[i].TextEffectClass.Enable();

		return text;
	}
	int CycleNextIndex(int nextIndex, int i)
	{
		if (i + 1 == commandArray.Length)
		{
			nextIndex = 0;
		}
		else
			nextIndex++;

		return nextIndex;
	}*/

}
