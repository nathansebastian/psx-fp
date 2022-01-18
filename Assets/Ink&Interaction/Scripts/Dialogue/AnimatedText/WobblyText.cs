using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WobblyText : MonoBehaviour, ITextEffect
{
    [SerializeField] private TextMeshRoot meshRoot;

    private CommandIndexes indexes;
    private Vector3[] verts;
    private Mesh mesh;
    
    public void Enable()
    {
        enabled = true;
    }
    public void Disable()
    {
        Debug.Log("Disable");
        enabled = false;
    }
    private void OnEnable()
    {
        indexes = GetComponent<CommandsArray>().CommandArray[0];
    }

    void Update()
    {
        mesh = meshRoot.textMesh.mesh;
        verts = mesh.vertices;
        SineWaveThroughChars(indexes.firstIndex, indexes.lastIndex);
        meshRoot.textMesh.mesh.vertices = verts;
        meshRoot.textMesh.canvasRenderer.SetMesh(meshRoot.textMesh.mesh);

    }
    void SineWaveThroughChars(int firstIndex, int lastIndex)
    {
        for (int i = firstIndex; i < lastIndex; i++)
        {
            TMP_TextInfo textInfo = meshRoot.textMesh.textInfo;
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;
            for (int j = 0; j < 4; ++j)
            {
                Vector3 orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
            }
        }
    }
}
