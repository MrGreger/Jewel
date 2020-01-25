using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMover : MonoBehaviour
{
    public void MoveImage(Image image, Vector2 moveTo)
    {
        image.rectTransform.position = moveTo;
    }
}
