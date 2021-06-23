using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPositions : TweenBase
{
    public override void AnimateObjects()
    {
        if (!playOnStart)
            return;
        

      PlayAnimation();



    }

    

    public override void PlayAnimation(Action OnCompleteAction = null)
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;

            Vector3 initPos = item.to;
            if (item.skipFromInit == false)
                item.target.anchoredPosition = item.from;

            if (item == tweens[tweens.Count - 1])
            {
                LTDescr ltDesc = LeanTween.move(item.target, item.to, ignoreScaleFactor ? item.time : item.time * speedFactor).setFrom(item.from);
                ltDesc.setDelay(ignoreScaleFactor ? item.startDelay : item.startDelay * speedFactor).setEase(item.ltType).setOnComplete(OnCompleteAction);
            }
            else
            {
                LTDescr ltDesc = LeanTween.move(item.target, item.to, ignoreScaleFactor ? item.time : item.time * speedFactor).setFrom(item.from);
                ltDesc.setDelay(ignoreScaleFactor ? item.startDelay : item.startDelay * speedFactor).setEase(item.ltType);
            }


        }
    }

    public override void ResetAnimation()
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;

            item.target.anchoredPosition = item.from;

        }
    }

    [ContextMenu("Set To")]
    void Evaluate()
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;

            item.to = item.target.anchoredPosition;
        }
    }

    public void BtnInfo(bool ison)
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;
            Debug.Log("hi");
            switch (ison)
            {
                case true:
                    LTDescr ltDesc = LeanTween.move(item.target, item.to, item.time * speedFactor).setFrom(item.from);
                    ltDesc.setDelay(ignoreScaleFactor ? item.startDelay : item.startDelay * speedFactor).setEase(item.ltType);
                    break;

                case false:
                    LTDescr ltDesc1 = LeanTween.move(item.target, item.to, ignoreScaleFactor ? item.time : item.time * speedFactor).setFrom(item.from);
                    ltDesc1.setDelay(ignoreScaleFactor ? item.startDelay : item.startDelay * speedFactor).setEase(item.ltType);
                    break;
            }
        }
    }
}
