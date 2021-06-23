using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRotations : MonoBehaviour {

    [SerializeField] private float speed = 40f;
    [SerializeField] private float startDelay = 0.3f;

    private float currentTimeStep = 0;
    private Transform thisTransform;


    private void OnEnable()
    {
        currentTimeStep = 0;
        thisTransform = this.transform;
    }

    private void Update()
    {
        currentTimeStep += Time.deltaTime;

        if (currentTimeStep < startDelay)
            return;

        thisTransform.Rotate(Vector3.down * speed * Time.deltaTime);
    }

}
