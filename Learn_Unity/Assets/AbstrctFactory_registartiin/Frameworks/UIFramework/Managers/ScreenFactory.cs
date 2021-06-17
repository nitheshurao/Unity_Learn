using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIFramework;

public class ScreenFactory : UIAbstractFactory<ScreenBase>
{
    public static ScreenFactory Instance { get; private set; }

    public ScreenBase defaultScreen;
    public ScreenBase commonScreen;

    private ScreenBase currentScreen;

    protected override void Init()
    {
        base.Init();
        Instance = this;
        if (defaultScreen != null)
        {
            defaultScreen.Activate();
            StartCoroutine(CallBackRoutine(defaultScreen.OnShow));
            currentScreen = defaultScreen;
        }
    }

    public virtual T Activate<T>() where T : ScreenBase
    {
        T panel = GetPanel<T>();
        panel.Activate();
        
        StartCoroutine(CallBackRoutine(panel.OnShow));
        if (commonScreen != panel)
            currentScreen = panel;
        return panel;
    }

    public virtual void Activate(ScreenBase screenBase)
    {
        screenBase.Activate();
        StartCoroutine(CallBackRoutine(screenBase.OnShow));
        if (commonScreen != screenBase)
            currentScreen = screenBase;
    }

    public virtual T Deactivate<T>(bool canReturnToThisScreen = false) where T : ScreenBase
    {
        T panel = GetPanel<T>();
        panel.Deactivate();
        if (canReturnToThisScreen)
            BackBtnManager.instance.AddScreenToStack(panel);
        StartCoroutine(CallBackRoutine(panel.OnHide));
        return panel;
    }

    public virtual ScreenBase Deactivate(ScreenBase panel)
    {
        panel.Deactivate();
        StartCoroutine(CallBackRoutine(panel.OnHide));
        return panel;
    }

    public void DeactivateAll()
    {
        foreach (var item in allPanels)
        {
            if (item.cachedGameObject.activeSelf)
                item.cachedGameObject.SetActive(false);
            currentScreen = null;
        }
    }
}
