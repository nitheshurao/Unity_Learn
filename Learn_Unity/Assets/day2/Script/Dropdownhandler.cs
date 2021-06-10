using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdownhandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Textbox;
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();


        dropdown.options.Clear();

        List<string> items = new List<string>();

        items.Add("item1");
        items.Add("item2");
        //to add item dinamicly

        foreach(var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item});
        }
        dropdownItemselected(dropdown);
        dropdown.onValueChanged.AddListener(delegate { dropdownItemselected(dropdown); });
        
    }

    void dropdownItemselected(Dropdown dropdown)
    {
        int index = dropdown.value;
        Textbox.text = dropdown.options[index].text;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
