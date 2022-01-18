using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class QuestionColour : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;

    private void Start()
    {
        
    }
    public void JumpKnot(Story currentStory)
    {
        Debug.Log("JumpKnot");
        currentStory.variablesState["isGreen"] = true;
        currentStory.variablesState["hp"] = 99;
        bool health = (bool)currentStory.variablesState["isGreen"];
        Debug.Log("isgreen "+health);
    }
    public void DisplayIsGreen()
    {

    }
}
