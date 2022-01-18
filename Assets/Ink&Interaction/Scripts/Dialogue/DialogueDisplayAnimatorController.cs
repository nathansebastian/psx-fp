using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplayAnimatorController : MonoBehaviour
{
	[SerializeField] private SplitDialogueText splitDialogue;
	[SerializeField] private WobblyText wobbly;
	[SerializeField] private WibblyText wibbly;

	[SerializeField] private Animator portraitAnimator;
	[SerializeField] private Animator layoutAnimator;
	public Animator PortraitAnimator => portraitAnimator;
	public Animator LayoutAnimator => layoutAnimator;
	public void RefreshCycle ()
	{
		splitDialogue.RefreshNextIndex();

		wobbly.Disable();
		wibbly.Disable();
	}
	public void EnterDialogue()
	{
		portraitAnimator.Play("default");
		layoutAnimator.Play("right");
	}
}
