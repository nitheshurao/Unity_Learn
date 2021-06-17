using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;


public class Welcome : ScreenBase
{
    [SerializeField] private Button _btn1;
    [SerializeField] private Button _btn2;
    private void Start()
    {
        //_backBtn.onClick.AddListener(OnButtonClick);
    }

    public override void OnButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "Btn1":
                _ChangeScen();
                break;
            case "Btn2":
                _ChangeScen1();
                break;

        }
    }
    //string str = LocalizationManager.Instance.FetchLabel(LabelType.MENDATORY_FIELD_ERROR);
    //string errorStr = LocalizationManager.Instance.FetchLabel(LabelType.ERROR);
    private void _ChangeScen()
    {
        Debug.Log("hi");

      
        ScreenFactory.Instance.Activate<SignIn>();
        //ScreenFactory.Instance.Deactivate<Welcome>();

        ScreenFactory.Instance.Deactivate<Welcome>();
        this.gameObject.SetActive(false);



    }
    private void _ChangeScen1()
    {
        Debug.Log("Register");


        ScreenFactory.Instance.Activate<Rigister>();
        //ScreenFactory.Instance.Deactivate<Welcome>();

        ScreenFactory.Instance.Deactivate<Welcome>();
        this.gameObject.SetActive(false);



    }
}


