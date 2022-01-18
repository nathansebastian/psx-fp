using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkVariableState : MonoBehaviour
{

    
    private bool isGreenVal = false;

    public bool IsGreenVal => isGreenVal;

    public void ChangeIsGreenVal(bool isGreen)
    {
        isGreenVal = isGreen;
    }
}
