

    
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slide : MonoBehaviour
{

//using UnityEngine;

//public class Slide : MonoBehaviour
//{
  [Range(0, 1)]
    public float TweenSpeed;
    public LeanTweenType TweenType;

    private Canvas Canvas;
    private RectTransform rect;
    private float outPos;
    private float inPos;
    private bool isTweenedIn = true;
    private bool tweenComplete = true;

    private void Start()
    {
        Canvas = GetComponentInParent<Canvas>();

        rect = GetComponent<RectTransform>();

        // The slide amount comes from the width of the UI Element. RectTransformUtility.PixedlAdjustRect() helps us calculate the true width
        // Factor the pivot position to accomodate LeanTween's algorithm
        outPos = RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), Canvas).width * -1 * (1 - rect.pivot.x);
        inPos = RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), Canvas).width * rect.pivot.x;
    }

    public void ToggleTween()
    {
        // Do not trigger another tween while a tween is still animating
        if (!tweenComplete) return;

        // Tween and setOnComplete to re-enable tweening
        tweenComplete = false;
        transform.LeanMoveX(isTweenedIn ? outPos : inPos, TweenSpeed).setEase(TweenType).setOnComplete(() => tweenComplete = true);
        isTweenedIn = !isTweenedIn;
    }
}

