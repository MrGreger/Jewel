using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScale : MonoBehaviour
{
    private CanvasScaler _canvasScaler;
    private Vector2 _screenResolution;

    private void Start()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
        _screenResolution = new Vector2(Screen.width, Screen.height);
        _canvasScaler.referenceResolution = _screenResolution;
    }
}
