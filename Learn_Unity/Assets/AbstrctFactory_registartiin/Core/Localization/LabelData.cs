//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Newtonsoft.Json;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public enum LabelType
//{
//    SELECT_STORY,
//    AVAILABLE_PROJECTS,
//    CONTINUE,
//    BACK,
//    DIARY,
//    LAST_SYNC,
//    AVAILABLE_POINTS,
//    NOSURVEYS_MSG_DIARY,
//    REWARD,
//    COMPLETED,
//    POINTS,
//    NOSURVEYS_MSG_ADHOC,
//    REWARDS,
//    COMPLETED_SURVEYS,
//    ASSIGNED_SURVEYS,
//    VOUCHERS,
//    TOTAL_REWARDS,
//    TUTORIALS,
//    HELPDESK,
//    ABOUT_US,
//    LOGOUT,
//    TERMS_CONDITIONS,
//    PRIVACY_POLICIES,
//    COPYRIGHT,
//    APPVERSION,
//    MANUAL_SYNC,
//    SYNC_SUCCESS,
//    NO_INTERNET_MSG,
//    SLOW_INTERNET_MSG,
//    ALERT,
//    WARNING,
//    SUCCESS,
//    ERROR,
//    OFFLINE_EXTERNAL_MSG,
//    COMPLETED_PROJECT_MSG,
//    MANUAL_SYNC_ERROR,
//    PROJECT_DATA_ERROR,
//    CONGRATULATIONS,
//    EARNED_POINTS,
//    SURVEY_COMPLETE_ALERT,
//    SELECT_PRODUCT,
//    THANK_YOU,
//    REDEEM_SUCCESS,
//    PROJECT_CHANGE,
//    LOGIN_ERROR,
//    SESSION_TIMEOUT,
//    MEDATORY_QUESTION_ALERT,
//    OFFLINE_SURVEY_MSG,
//    WELCOME,
//    REGISTER,
//    LOGIN,
//    OTP_VERIFICATION,
//    VERIFICATION_EMAIL,
//    VERIFY,
//    ENTER_OTP,
//    BARCODE_CONTINUE_ALERT,
//    THANK_YOU_OCCASION,
//    DONE,
//    SCAN_BARCODE,
//    TYPE_BARCODE,
//    CONTINUE_WITHOUT_SCAN,
//    YES,
//    NO,
//    BARCODE_DETAILS_CHOOSE,
//    DASHBOARD,
//    SETTINGS,
//    MOREPRODUCTS_ALERT,
//    AVAILABLE_VOUCHERS,
//    MY_VOUCHERS,
//    REDEEM,
//    VOUCHERS_NOT_AVAILABLE,
//    CLOSE,
//    START,
//    SUBMIT,
//    REGISTRATION,
//    EMAIL_ID,
//    FIRST_NAME,
//    LAST_NAME,
//    PASSWORD,
//    RETYPE_PWD,
//    AGREEMENT_1,
//    MEMBERSHIP,
//    AGREEMENT,
//    PRIVACY_POLICY,
//    ALREADY_USER,
//    REGISTER_BTN,
//    LETS,
//    USERNAME,
//    FORGOT_PWD,
//    SCAN,
//    RESULT,
//    TELL_SOMETHING,
//    TAKE_SURVEY,
//    ADHOC_SURVEYS,
//    NO_VOUCHERS,
//    ENTER_EMAIL_ID,
//    TYPE_EMAIL_ID,
//    SEND_OTP,
//    ENTER_NEW_PWD,
//    RESET_PWD,
//    VERIFICATION_FAILED,
//    TRY_AGAIN,
//    ENTER_CORRECT_OTP,
//    SUCCESSFULLY_VERIFIED,
//    SUCCESSFULLY_REGISTERED,
//    NEXT,
//    SELECT_LANGUAGE,
//    AVAILABLE_LANGUAGES,
//    CHOOSE_OTHER_LANGUAGE_ALERT,
//    SERVER_ERROR,
//    BACKDATE_ERROR,
//    FUTUREDATE_ERROR,
//    INVALID_OTP,
//    INVALID_PWD,
//    PWD_MATCH_ERROR,
//    MENDATORY_FIELD_ERROR,
//    INVALID_EMAIL,
//    INVALID_CREDENTIALS,
//    USER_NOT_FOUND,
//    VOUCHER_ERROR,
//    SOME_ERROR,
//    OTP_ERROR,
//    THANK_YOU_SURVEY,
//    ACCEPT,
//    DECLINE,
//    LICENSE_AGREEMENT,
//    SCROLL_AGREEMENT,
//    BARCODE_RESULT,
//    SCANNED_CORRECTLY,
//    PRODUCT_NAME,
//    DESCRIPTION,
//    READY_TO_SCAN,
//    SCANNING,
//    BARCODE_NOT_FOUND,
//    SKIP,
//    SAME_OCCASIONAL_MSG,
//    BARCODE_HISTORY,
//    SELECT_BARCODE,
//    CALENDAR_INSTRUCTION,
//    CONVERSATION_INSTRUCTION,
//    CHECKPOINT_INSTRUCTION

//}

//[Serializable]
//public class LabelLanguageTranslation
//{
//    public int labelLanguageId;
//    public int active;
//    public string localDesc;
//    public int labelId;
//    public string labelDesc;
//}

//[Serializable]
//public class LabelLanguageTranslationData
//{
//    public int languageId;
//    public string languageDesc;
//    public List<LabelLanguageTranslation> labelLanguageTranslations = new List<LabelLanguageTranslation>();
//}

//[Serializable]
////public class LanguageData : Data
////{
////    public List<LabelLanguageTranslationData> labelLanguageTranslationList = new List<LabelLanguageTranslationData>();
////}


//[Serializable]
//public class LabelData
//{
//    public LabelType LabelType;
//    public Text LabelText;
//    public TMPro.TMP_Text LabelTextMeshPro;
//}