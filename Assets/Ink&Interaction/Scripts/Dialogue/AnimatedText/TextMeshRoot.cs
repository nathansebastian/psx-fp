using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextMeshRoot : MonoBehaviour
{
    [SerializeField] private DialogueSystemManager dialogueSystemManager;
    public TMP_Text textMesh;
    private void Start()
    {
        textMesh = dialogueSystemManager.DialogueText;
    }
    void Update()
    {
        textMesh.ForceMeshUpdate();
    }
}
