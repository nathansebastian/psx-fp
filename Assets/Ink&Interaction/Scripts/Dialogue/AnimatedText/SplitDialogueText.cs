using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using Ink.Runtime;

public class SplitDialogueText : MonoBehaviour
{
	private int nextIndex;
	private string newString;
	private string[] leftList;

	public void CycleNextIndex(int i, int arrayLength)
	{
		Debug.Log(i);
		Debug.Log(arrayLength);
		if (i + 1 == arrayLength)
		{
			nextIndex = 0;
		}
		else
			nextIndex++;

		Debug.Log(nextIndex);
	}
	public void RefreshNextIndex() => nextIndex = 0;

	public string SplitCustomCommand(string text, int i,CommandIndexes[] commandArray)
	{
		//Debug.Log(nextIndex);
		newString = text.Replace("<i>", "").Replace("</i>", "").Replace("<b>", "").Replace("</b>", "").Replace("<" + commandArray[nextIndex].Tag + ">", "").Replace("</" + commandArray[nextIndex].Tag + ">", "");
		//commandArray[nextIndex].Tag
		Debug.Log(commandArray[1].Tag);
		string[] rightList = newString.Split(new string[] { "<" + commandArray[i].Tag + ">" }, StringSplitOptions.None);
		leftList = rightList[1].Split(new string[] { "</" + commandArray[i].Tag + ">" }, StringSplitOptions.None);
		commandArray[i].firstIndex = text.IndexOf("<" + commandArray[i].Tag + ">");
		commandArray[i].lastIndex = (text.IndexOf("<" + commandArray[i].Tag + ">") + leftList[0].Length);

		text = text.Replace("<" + commandArray[i].Tag + ">", "").Replace("</" + commandArray[i].Tag + ">", "");
		Debug.Log(commandArray[1].firstIndex);
		commandArray[i].TextEffectClass.Enable();

		return text;
	}
}
