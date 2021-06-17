using System.Collections;
using System.Text.RegularExpressions;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Rigister : ScreenBase
{
    [SerializeField] private Toggle _toggle_TermsOfUse;
    [SerializeField] private Button _submitButton;
    [SerializeField]  InputField _Email;
    [SerializeField]  InputField _Name;
    //[SerializeField] private InputField _lbl_LastName;
    [SerializeField]  InputField _Password;
    [SerializeField]  InputField _RetypePassword;
    //[SerializeField] private Text _lbl_Error;
    [SerializeField] private Button _backBtn;
    [SerializeField] private Button _getBtn;

    // Start is called before the first frame update
    private void Start()
    {
        _backBtn.onClick.AddListener(OnBackBtnClicked);
    }

    private void OnDestroy()
    {
        _backBtn.onClick.RemoveListener(OnBackBtnClicked);
    }

    private void OnBackBtnClicked()
    {
        BackBtnManager.instance.OnBackBtnClick(this);
    }
    public override void OnShow()
    {
        base.OnShow();
        OnTermsToggleValueChanged(_toggle_TermsOfUse.isOn);
        _toggle_TermsOfUse.onValueChanged.AddListener(OnTermsToggleValueChanged);

    }
    public override void OnHide()
    {
        base.OnHide();
        _toggle_TermsOfUse.onValueChanged.RemoveAllListeners();
    }

    public void AcceptTermsAndConditions(bool isOn)
    {
        _toggle_TermsOfUse.isOn = isOn;
    }


    private void OnTermsToggleValueChanged(bool isAccepted)
    {
        _submitButton.interactable = isAccepted;
    }


    public override void OnButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "Btn-Submit":
                _RegisterToJson();
                break;
                //case "Btn-TermsOfUse":
                //    _OnTermsBtnClick();
               
            case "Btn-AlreadyAUser":
                _OnSignInBtnClick();
                break;
            case "get":
                Loadform();
                break;
        }
    }

/// <summary>
/// /
/// </summary>
    private void _ValidateFields()
    {
        if (_Email.text == string.Empty
            || _Name.text == string.Empty
           
            || _Password.text == string.Empty
            || _RetypePassword.text == string.Empty)
        {

            //string str = _lbl_Email.text;
            //string errorStr = LocalizationManager.Instance.FetchLabel(LabelType.ERROR);
            //if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(errorStr))
            //    _DisplayErrorMessage(errorStr, str);
            //else
            //    _DisplayErrorMessage("Error!!", "Fill all the mandatory fields");
            //return;
            Debug.Log("invalid email");
        }


        if (!_Email.text.IsValidEmail())
        {
            //string str = LocalizationManager.Instance.FetchLabel(LabelType.INVALID_EMAIL);
            //string errorStr = LocalizationManager.Instance.FetchLabel(LabelType.ERROR);
            //if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(errorStr))
            //    _DisplayErrorMessage(errorStr, str);
            //else
            //    _DisplayErrorMessage("Error!!", "Invalid email id!!");
            Debug.Log("invalid email");
            //return;
        }
        //if (!_ValidateEmail(_lbl_Email.text))
        //{
        //    _DisplayErrorMessage("Error!!", "Invalid email id!!");
        //    return;
        //}

        if (!_Password.text.Equals(_RetypePassword.text))
        {
            //string str = LocalizationManager.Instance.FetchLabel(LabelType.PWD_MATCH_ERROR);
            //string errorStr = LocalizationManager.Instance.FetchLabel(LabelType.ERROR);
            //if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(errorStr))
            //    _DisplayErrorMessage(errorStr, str);
            //else
            //    _DisplayErrorMessage("Error!!", "Passwords doesn't match!!");
            //return;
            Debug.Log("invalid password");
        }


        if (!_RetypePassword.text.IsValidPassword())
        {
            //string str = LocalizationManager.Instance.FetchLabel(LabelType.INVALID_PWD);
            //string errorStr = LocalizationManager.Instance.FetchLabel(LabelType.ERROR);
            //if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(errorStr))
            //    _DisplayErrorMessage(errorStr, str);
            //else
            //    _DisplayErrorMessage("Error!!", "Password must be at least 6 characters, no more than 12 characters, and must include at least one upper case letter, one lower case letter, one numeric digit and one of special characters(~!@#$%^&*+=-_)");
            //return;
            Debug.Log("invalid same pass");
        }

        //if (!_IsValidPassword(_lbl_RetypePassword.text))
        //{
        //    _DisplayErrorMessage("Error!!", "Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, one numeric digit and one of special characters(@#$%^&+=-)");
        //    return;
        //}

        //User.CurrentUser.userInfo = new UserInfo(_lbl_Email.text, _lbl_FirstName.text, _lbl_LastName.text, _lbl_Password.text);
        _RegisterToJson();
        //ScreenFactory.Instance.Activate<APIRequestWaitScreen>();
    }


    private void _RegisterToJson()
    {
        Details data = new Details();
        data.Name = _Name.text;
        data.Email = _Email.text;
        data.Password = _Password.text;
        data.Re_Password = _RetypePassword.text;



        //store data in Json
        Debug.Log("to json");
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Details.json", json);



    }
//

    private void _OnSignInBtnClick()
    {
        _Email.text = string.Empty;
        _Name.text = string.Empty;
      
        _Password.text = string.Empty;
        _RetypePassword.text = string.Empty;
        ScreenFactory.Instance.Activate<Welcome>();
        ScreenFactory.Instance.Deactivate<Rigister>();
    }

    public void Loadform()
    {
        string json = File.ReadAllText(Application.dataPath + "/Details.json");

        Details da = JsonUtility.FromJson<Details>(json);
        _Email.text = da.Email;
        _Name.text = da.Name;
        _Password.text = da.Password;
        _RetypePassword.text = da.Re_Password;
    }

}
