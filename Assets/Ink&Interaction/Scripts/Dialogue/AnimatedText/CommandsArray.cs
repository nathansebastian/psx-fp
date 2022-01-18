using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsArray : MonoBehaviour
{
    private CommandIndexes[] commandArray = new CommandIndexes[2];
    public CommandIndexes[] CommandArray => commandArray;
    private void Awake()
    {
        CommandIndexes commandX = new CommandIndexes("x", GetComponent<WobblyText>());
        CommandIndexes commandW = new CommandIndexes("w", GetComponent<WibblyText>());
        commandArray[0] = commandX;
        commandArray[1] = commandW;
        Debug.Log(commandArray[0]);
    }
}
