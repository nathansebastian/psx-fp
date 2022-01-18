using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;

public class ControlManager : MonoBehaviour
{
    [SerializeField] private SimpleWalkerController _character;
    [SerializeField] private CameraController _camera;

    public void SetActive(bool active)
    {
        _camera.enabled = active;
        _character.enabled = active;
    }
}
