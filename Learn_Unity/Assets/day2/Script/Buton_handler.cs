﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buton_handler : MonoBehaviour
{
    // Start is called before the first frame update
    public  void SetText(string text)
    {
      Text txt =  transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }
   
}
