using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;

public class Splash : ScreenBase
{
    [SerializeField] private Button _backBtn;
    private void Start()
    {
        //_backBtn.onClick.AddListener(OnButtonClick);
    }

    public override void OnButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "Btn2":
                _ChangeScen();
                break;

        }
    }
    //string str = LocalizationManager.Instance.FetchLabel(LabelType.MENDATORY_FIELD_ERROR);
    //string errorStr = LocalizationManager.Instance.FetchLabel(LabelType.ERROR);
    private void _ChangeScen()
    {
        Debug.Log("hi");

        //ScreenFactory.Instance.Deactivate<Splash>();
        //ScreenFactory.Instance.Activate<Welcome2>();



    }
}
