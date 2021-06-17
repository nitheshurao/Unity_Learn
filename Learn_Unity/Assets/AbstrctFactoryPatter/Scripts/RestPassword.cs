using System.Collections;
using System.Text.RegularExpressions;
using UIFramework;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class RestPassword : ScreenBase
{
  


    [SerializeField] private Button _submitButton;
    [SerializeField] InputField _Email;
   
    //[SerializeField] private InputField _lbl_LastName;
    [SerializeField] InputField _Password;
    [SerializeField] InputField _RetypePassword;
    //[SerializeField] private Text _lbl_Error;
    [SerializeField] private Button _backBtn;
    //[SerializeField] private Button _getBtn;
    private string Email;
    private string Password;
    private string Name;


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


    }
    public override void OnHide()
    {
        base.OnHide();

    }

   


    

    public override void OnButtonClick(GameObject button)
    {
        switch (button.name)
        {
            case "BtnSmt":
                _RegisterToJson();
                break;
            //case "Btn-TermsOfUse":
            //    _OnTermsBtnClick();

            
            case "BtnBk":
                //Loadform();
                backtosign();
                break;
        }
    }

    /// <summary>
    private void _Valid()
    {

    }
        /// </summary>
        /// 



        private void _RegisterToJson()
    {
        

        //
      
        //

        string e = _Email.text;
        Debug.Log(e + " etr emli");
        if (_Email.text == string.Empty
               || _Password.text == string.Empty)
        {
            Debug.Log("is empty");
        }
        if (!_Email.text.IsValidEmail())
        {
            Debug.Log("is invalid");
        }
        if (!_Password.text.IsValidPassword())
        {
            Debug.Log("is pass invalid");
        }
        if (_Password.text != _RetypePassword.text)
        {
            Debug.Log("Password not match");
            _Password.text = string.Empty;
            _RetypePassword.text= string.Empty;
            _Email.text= string.Empty;
        }
        

        Debug.Log(Email + " " + Password);
        if (Email == _Email.text)
        {
            string json = File.ReadAllText(Application.dataPath + "/Details.json");


            Details da = JsonUtility.FromJson<Details>(json);
            string name = da.Name;
            Email = da.Email;
            Password = da.Password;
            da.Password = _Password.text;
            Details data = new Details();

            data.Email = _Email.text;
            data.Password = _Password.text;
            data.Name = name;
            data.Re_Password = _RetypePassword.text;

            string js = JsonUtility.ToJson(data, true);
            //string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Application.dataPath + "/Details.json", js);
            Debug.Log("doen");
            _Password.text = string.Empty;
            _RetypePassword.text = string.Empty;
            _Email.text = string.Empty;

        }


    }
    //

    private void backtosign()
    {
       
        ScreenFactory.Instance.Activate<RestPassword>();
        ScreenFactory.Instance.Deactivate<SignIn>();
    }

  

}
