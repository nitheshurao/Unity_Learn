

using UnityEngine;

public class Sale : MonoBehaviour
{
    [Range(0, 1)]
    public float TweenSpeed;
    public LeanTweenType TweenType;

    private bool isTweenedIn = true;
    private bool tweenComplete = true;
    private CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleTween()
    {
        // Do not trigger another tween while a tween is still animating
        if (!tweenComplete) return;

        // Tween and setOnComplete to re-enable tweening
        tweenComplete = false;

        LeanTween.alphaCanvas(canvasGroup, isTweenedIn ? 0 : 1, TweenSpeed).setOnComplete(() => tweenComplete = true);
        //transform.LeanScale(isTweenedIn ? Vector3.zero : Vector3.one, TweenSpeed).setEase(TweenType).setOnComplete(() => tweenComplete = true);
        isTweenedIn = !isTweenedIn;
    }
}
