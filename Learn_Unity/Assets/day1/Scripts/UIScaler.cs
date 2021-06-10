using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScaler : MonoBehaviour
{
    // Start is called before the first frame update
    public float resX;
    public float rexY;
    private CanvasScaler cas;

    private void Start()
    {
        cas = GetComponent<CanvasScaler>();
        SetInfo();

    }
    void SetInfo()
    {
        resX = (float)Screen.currentResolution.width;
        rexY = (float)Screen.currentResolution.height;

        cas.referenceResolution = new Vector2(resX, rexY);
    }
}
