
using UnityEngine;
public class Emphasiser : MonoBehaviour


{
    [Range(0, 1)]
    public float EmphasiseSpeed;
    [Range(1, 2)]
    public float EmphasisAmount;
    public LeanTweenType TweenType;

    private LTDescr activeTween;
    private bool isTweening;

    public void Emphasise()
    {
        if (!isTweening)
        {
            isTweening = true;
            activeTween = transform.LeanScale(Vector3.one * EmphasisAmount, EmphasiseSpeed).setEase(TweenType).setOnComplete(() => isTweening = false);
        }
        else
        {
            activeTween.setOnComplete(() => activeTween = transform.LeanScale(Vector3.one * EmphasisAmount, EmphasiseSpeed).setEase(TweenType).setOnComplete(() => isTweening = false));
        }
    }

    public void DeEmphasise()
    {
        if (!isTweening)
        {
            isTweening = true;
            activeTween = transform.LeanScale(Vector3.one, EmphasiseSpeed).setEase(TweenType).setOnComplete(() => isTweening = false);
        }
        else
        {
            activeTween.setOnComplete(() => activeTween = transform.LeanScale(Vector3.one, EmphasiseSpeed).setEase(TweenType).setOnComplete(() => isTweening = false));
        }
    }
}