using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMove : MonoBehaviour
{

    public GameObject target;
    private float RotateSpeed = 0.1f;
    private float Radius = 2.5f;

    private Vector2 center;
    private float angle;

    private void Start()
    {
        center = target.transform.localPosition;
        //Radius = target.transform.localScale.x / 1.5f;
        //Radius -= (int)Mathf.Lerp(0, 10, Time.deltaTime*3);
        //angle = angle + RotateSpeed * Time.deltaTime;
        //this.transform.Rotate(Vector3.forward * -angle * Time.deltaTime);

        //Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        //this.transform.position = center + offset;
    }

    private void Update()
    {

        angle = angle + RotateSpeed * Time.deltaTime;
        this.transform.Rotate(Vector3.forward * -angle * Time.deltaTime);

        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        this.transform.position = center + offset;


    }
}
