using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotionspeed = 100f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotionspeed * Time.deltaTime);
    }
}
