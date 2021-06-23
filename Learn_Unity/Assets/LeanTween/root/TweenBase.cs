﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenBase : MonoBehaviour
{
    [System.Serializable]
    public class TweenData
    {
        public RectTransform target;
        public float time;
        public float startDelay;
        public Vector3 from;
        public Vector3 to;
        public LeanTweenType ltType;
        public bool skipFromInit;
       
    }

    public List<TweenData> tweens;
    public bool playOnStart = false;
    public bool PlayOnScal = false;

    protected float speedFactor = 0.8f;
    public bool ignoreScaleFactor = false;

    void OnEnable()
    {
        AnimateObjects();
    }

    void OnDisable()
    {
        DisableEverything();
    }

    public virtual void AnimateObjects()
    {

    }

    public virtual void PlayAnimation(Action OnCompleteAction = null)
    {

    }

   

    //     public virtual void PlayAnimationScal( Action OnCompleteAction = null)
    //{

    //}


    //public virtual void 

    public virtual void ResetAnimation()
    {

    }


    public virtual void PlayAnimationa()
    {

    }

    private void DisableEverything()
    {
        foreach (var item in tweens)
        {
            if (item == null)
                continue;

            if (item.target == null)
                continue;
            LeanTween.cancel(item.target);
        }
    }


}
