using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface ITextEffect
{
    void Enable();
    void Disable();
}

public class WibblyText : MonoBehaviour, ITextEffect
{
    [SerializeField] private TextMeshRoot meshRoot;

    private CommandIndexes indexes;
    private Mesh mesh;
    private Vector3[] verts;
    public void Enable()
    {
        enabled = true;
    }
    public void Disable()
    {
        enabled = false;
    }
    private void OnEnable()
    {
       indexes = GetComponent<CommandsArray>().CommandArray[1];
    }
    void Update()
    {
        mesh = meshRoot.textMesh.mesh;
        verts = mesh.vertices;
        WobbleThroughChars(indexes.firstIndex, indexes.lastIndex);
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
    void WobbleThroughChars(int firstIndex, int lastIndex)
    {
        Debug.Log(firstIndex + "First Index");
        for (int i = firstIndex; i < lastIndex; i++)
        {
            TMP_CharacterInfo c = meshRoot.textMesh.textInfo.characterInfo[i];
            if (!c.isVisible)
                continue;
            int index = c.vertexIndex;
            Vector3 offset = Wobble(Time.time + i);

            verts[index] += offset;
            verts[index + 1] += offset;
            verts[index + 2] += offset;
            verts[index + 3] += offset;
        }
    }
    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 20f), Mathf.Cos(time * 24f));
    }
}
