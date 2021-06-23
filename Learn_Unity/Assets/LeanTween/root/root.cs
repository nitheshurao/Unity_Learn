using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root : MonoBehaviour
{
    public GameObject pntitle, pnlbutn, pnlOption, pnlInfo;

    public LeanTweenType leanTweenType;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveX(pntitle.GetComponent<RectTransform>(), 0, 1f).setEase(leanTweenType);
        LeanTween.moveX(pnlbutn.GetComponent<RectTransform>(), 0, 0.5f).setEase(leanTweenType);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void btn()
    {
        Debug.Log("hiii");
    }

    public void BtnOption(bool ison)
    {
        Debug.Log("hi");
        switch (ison) { 
        case true:
                LeanTween.moveY(pnlOption.GetComponent<RectTransform>(), -220, 0.5f).setEase(leanTweenType);
                LeanTween.moveY(pntitle.GetComponent<RectTransform>(), 500, 0.5f).setEase(leanTweenType);

                LeanTween.moveY(pnlbutn.GetComponent<RectTransform>(), 600, 0.5f).setEase(leanTweenType);
                break;

        case false:
                LeanTween.moveY(pnlOption.GetComponent<RectTransform>(), 1500, 0.5f).setEase(leanTweenType);
                LeanTween.moveY(pntitle.GetComponent<RectTransform>(), 0, 0.5f).setEase(leanTweenType);

                LeanTween.moveY(pnlbutn.GetComponent<RectTransform>(), 0, 0.5f).setEase(leanTweenType);
                break;
         }

    }


    public void BtnInfo(bool ison)
    {
        Debug.Log("hi");
        switch (ison)
        {
            case true:
                LeanTween.scale(pnlInfo.GetComponent<RectTransform>(),new Vector3(1,1,1), 0.5f ).setEase(leanTweenType);
                LeanTween.moveY(pntitle.GetComponent<RectTransform>(), 500, 0.5f).setEase(leanTweenType);
                LeanTween.moveY(pnlbutn.GetComponent<RectTransform>(), 600, 0.5f).setEase(leanTweenType);
                break;

            case false:
                LeanTween.scale(pnlInfo.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f).setEase(leanTweenType);
                LeanTween.moveY(pntitle.GetComponent<RectTransform>(), 0, 0.5f).setEase(leanTweenType);
                LeanTween.moveY(pnlbutn.GetComponent<RectTransform>(), 0, 0.5f).setEase(leanTweenType);
                break;
        }

    }
}
