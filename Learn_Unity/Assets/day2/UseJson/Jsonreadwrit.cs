using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Jsonreadwrit : MonoBehaviour
{
    public InputField IdInputfield;
    public InputField nameInputfield;
    public InputField InfoInpitfield;



    public void SaveToJson()
    {
        data data = new data();
        data.Id = IdInputfield.text;
        data.Name = nameInputfield.text;
        data.Info = InfoInpitfield.text;


        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/data.json", json);
    }
    public void Loadform()
    {
        string json = File.ReadAllText(Application.dataPath + "/data.json");

        data da = JsonUtility.FromJson<data>(json);
        IdInputfield.text = da.Id;
        nameInputfield.text = da.Name;
        InfoInpitfield.text = da.Info;
    }
}
