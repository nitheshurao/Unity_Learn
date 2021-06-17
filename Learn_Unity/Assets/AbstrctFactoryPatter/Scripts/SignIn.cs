using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SignIn : ScreenBase
{
    // Start is called before the first frame update
    [SerializeField] private InputField _lbl_Email;
    [SerializeField] private InputField _lbl_Password;
    [SerializeField] private Image _ImgPwdVisibility;
    [SerializeField] private Sprite _showPwdimg;
    [SerializeField] private Sprite _hidePwdimg;
    [SerializeField] private Button _backBtn;
    [SerializeField] private Button BtnForgotPassword;
 
    //[SerializeField] private Button _Re;
    private string Email;
    private string Password;
    private string Name;



    private bool _isPasswordVisible = true;
    private void Awake()
    {
        //_deviceOS = SystemInfo.operatingSystem;
    }

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

    //public override void OnShow()
    //{
    //    base.OnShow();
    //    _isPasswordVisible = true;
    //    _TogglePasswordVisibility();
    //    _lbl_Email.ActivateInputField();
    //}

    public override void OnButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "Btn-Submit":
                _SignIn();
                break;
            case "Btn-Register":
                _Register();
                break;
            case "Btn-TogglePwd":
                _TogglePasswordVisibility();
                break;
            case "Btn-ForgotPassword":
                _ForgotPassword();
                break;
            case "Btb":
                _back();
                break;
        }
    }

    private void _SignIn()
    {
        //ScreenFactory.Instance.Activate< >();
        //ScreenFactory.Instance.Deactivate<SignIn>(canReturnToThisScreen: true);
        string json = File.ReadAllText(Application.dataPath + "/Details.json");


        Details da = JsonUtility.FromJson<Details>(json);
            Email = da.Email;
       Password = da.Password;
        Debug.Log(Email + " " + Password);
        if (_lbl_Email.text == string.Empty
            || _lbl_Password.text == string.Empty)
        {
            Debug.Log("is empty");
        }
        if (!_lbl_Email.text.IsValidEmail())
        {
            Debug.Log("is invalid");
        }
        if (!_lbl_Password.text.IsValidPassword())
        {
            Debug.Log("is pass invalid");
        }
        if(Email == _lbl_Email.text && Password == _lbl_Password.text)
        {
            Debug.Log("Perfect!");
        }
       

        }

        private void _TogglePasswordVisibility()
    {
        _isPasswordVisible = !_isPasswordVisible;

        if (_isPasswordVisible)
        {
            _ImgPwdVisibility.sprite = _showPwdimg;
            _lbl_Password.contentType = InputField.ContentType.Standard;
        }
        else
        {
            _ImgPwdVisibility.sprite = _hidePwdimg;
            _lbl_Password.contentType = InputField.ContentType.Password;
        }
        _lbl_Password.ActivateInputField();
    }

    private void _Register()
    {
        ScreenFactory.Instance.Activate<Rigister>();
        ScreenFactory.Instance.Deactivate<SignIn>(canReturnToThisScreen: true);
        Debug.Log(Email + " " + Password);
    }

    private void _DisplayErrorMessage(string header, string body)
    {
        //PopupFactory.Instance.GetPanel<AlertMessageOne>().ShowPopUp(header, body, MessageType.Error, () => { });
    }

    private void _ForgotPassword()
    {
        //ScreenFactory.Instance.Activate<ForgotPasswordScreen>();
        //ScreenFactory.Instance.Deactivate<SignInScreen>();
        //string json = File.ReadAllText(Application.dataPath + "/Details.json");


        //Details da = JsonUtility.FromJson<Details>(json);
        //Email = da.Email;
        //Password = da.Password;
        //name = da.Password;
        //Debug.Log(Email + " " + Password);
        //ScreenFactory.Instance.Activate<Passwordrest>();
        ScreenFactory.Instance.Deactivate<SignIn>(canReturnToThisScreen: true);



        //Debug.Log("HII");
    }
    
          private void _back()
    {
        ScreenFactory.Instance.Activate<Welcome>();
        ScreenFactory.Instance.Deactivate<SignIn>(canReturnToThisScreen: true);
        Debug.Log(Email + " " + Password);
    }

}
