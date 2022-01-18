using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_ColourSelection : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private InkVariableState inkVariableState;
    private bool isGreenVal = false;
    public void ColourSelection(string colour)
    {
        switch (colour)
        {
            case "red":
                spriteRenderer.color = Color.red;
                isGreenVal = false;
                break;
            case "green":
                spriteRenderer.color = Color.green;
                isGreenVal = true;
                break;
            case "blue":
                isGreenVal = false;
                spriteRenderer.color = Color.blue;
                break;
        }
        inkVariableState.ChangeIsGreenVal(isGreenVal);
    }
}
