//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using UnityEngine;

//public class LocalizationManager : SingletonBase<LocalizationManager>
//{
//    [SerializeField]
//    private List<LabelData> LabelList = new List<LabelData>(); //Text elements which needs to be updated
//    //internal LanguageData AllLanguages = new LanguageData();
//    public LabelLanguageTranslationData ActiveLanguage { get; private set; }
//    public int pLabelId { get; private set; }
//    public int pProjectLanguageId { get; private set; }

//    public void UpdateCurrentLanguageList(string languageDesc)
//    {
//        foreach (var item in AllLanguages.labelLanguageTranslationList.Where(item => item.languageDesc == languageDesc))
//        {
//            pLabelId = item.languageId;
//            break;
//        }

//        var langList = AllLanguages.labelLanguageTranslationList.Where(t => t.languageId == pLabelId).SelectMany(t => t.labelLanguageTranslations).ToList();
//        ActiveLanguage = new LabelLanguageTranslationData()
//        {
//            languageId = pLabelId,
//            languageDesc = languageDesc,
//            labelLanguageTranslations = langList
//        };

//        foreach (var item in LabelList)
//        {
//            string str = FetchLabel(item.LabelType);
//            if (!String.IsNullOrEmpty(str))
//            {
//                if (item.LabelText != null)
//                    item.LabelText.text = str;
//                else if (item.LabelTextMeshPro != null)
//                    item.LabelTextMeshPro.text = str;
//            }
//            //else do not update hard coded labels
//        }
//    }

//    internal string FetchLabel(LabelType labelType)
//    {
//        if (ActiveLanguage == null)
//            return "";
//        foreach (var item in ActiveLanguage.labelLanguageTranslations.Where(item => item.labelDesc == labelType.ToString()))
//        {
//            return item.localDesc;
//        }
//        return "";
//    }

//    public void SetLanguageId(int id)
//    {
//        pProjectLanguageId = id;
//        Debug.Log($"New language ID - {id}");
//    }
    
//    public void ReadLocalisationFile()
//    {
//        var path = PathLoader.Instance.GetPath("getLabelLanguageTranslationList");
//        var completePath = OfflineJsonParser.Instance._GetLocation(path, false);

//        if (File.Exists(completePath))
//        {
//            OfflineJsonParser.Instance._ReadData<LanguageData>(path,
//                successResponse =>
//                {
//                    // Debug.Log($"{successResponse.labelLanguageTranslationList.Count}");
//                    _CreateLanguageLists(successResponse);
//                },
//                failureResponse =>
//                {

//                }, false);
//        }
//        else
//        {
//            Debug.Log($"File not found");
//            ScreenFactory.Instance.GetPanel<SplashScreen>().AddDefaultOption();
//        }
//    }

//    private void _CreateLanguageLists(LanguageData languagesDetails)
//    {
//        foreach (var lang in languagesDetails.labelLanguageTranslationList)
//        {
//            LabelLanguageTranslationData languages = new LabelLanguageTranslationData();
//            languages.languageId = lang.languageId;
//            languages.languageDesc = lang.languageDesc;
//            languages.labelLanguageTranslations = new List<LabelLanguageTranslation>();

//            foreach (var labelsDetail in lang.labelLanguageTranslations)
//            {
//                LabelLanguageTranslation lc = new LabelLanguageTranslation();
//                lc.labelId = labelsDetail.labelId;
//                lc.labelDesc = labelsDetail.labelDesc;
//                lc.localDesc = labelsDetail.localDesc;
//                languages.labelLanguageTranslations.Add(lc);
//            }
//            AllLanguages.labelLanguageTranslationList.Add(languages);
//        }
//        ScreenFactory.Instance.GetPanel<SplashScreen>()._ShowAvailableLanguages(languagesDetails);
//    }
//}
