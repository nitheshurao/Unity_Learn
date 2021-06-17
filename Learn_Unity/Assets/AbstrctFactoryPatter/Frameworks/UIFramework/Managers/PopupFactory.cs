using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UIFramework;

public class PopupFactory : UIAbstractFactory<PopupBase>
{
    public static PopupFactory Instance { get; private set; }

    private Stack<PopupBase> screenStack = new Stack<PopupBase>();
    public PopupBase defaultPopup;

    protected override void Init()
    {
        base.Init();
        Instance = this;
        if (defaultPopup != null)
            Activate(defaultPopup);
    }

    public PopupBase CurrentPopup
    {
        get
        {
            if (screenStack.Count == 0)
                return null;
            return screenStack.Peek();
        }
    }

    public T Activate<T>() where T : PopupBase
    {
        T popup = GetPanel<T>();
        popup.Activate();
        StartCoroutine(CallBackRoutine(popup.OnShow));
        screenStack.Push(popup as PopupBase);
        return popup;
    }

    public PopupBase Activate(PopupBase popup)
    {
        popup.Activate();
        StartCoroutine(CallBackRoutine(popup.OnShow));
        screenStack.Push(popup);
        return popup;
    }

    public T Deactivate<T>() where T : PopupBase
    {
        T popup = null;
        if (screenStack.Count > 0)
        {
            while (!screenStack.Peek().IsActive)
            {
                screenStack.Pop();
                if (screenStack.Count == 0)
                    return null;
            }

            if (screenStack.Peek().GetType().Name.Equals(typeof(T).Name))
                popup = screenStack.Pop() as T;
            else
                popup = GetPanel<T>();

            popup.Deactivate();
            StartCoroutine(CallBackRoutine(popup.OnHide));
        }
        return popup;
    }

    public PopupBase Deactivate(PopupBase popup)
    {
        if (screenStack.Count > 0)
        {
            while (!screenStack.Peek().IsActive)
            {
                screenStack.Pop();
                if (screenStack.Count == 0)
                    return null;
            }

            popup.Deactivate();
            StartCoroutine(CallBackRoutine(popup.OnHide));
        }
        return popup;
    }

    public void DeactivateTopPopup()
    {
        PopupBase popup = screenStack.Pop();
        popup.Deactivate();
        StartCoroutine(CallBackRoutine(popup.OnHide));
    }


    public void DeactivateAll()
    {
        foreach (var item in allPanels)
        {
            if (item.cachedGameObject.activeSelf)
            {
                item.cachedGameObject.SetActive(false);
            }
        }
    }
    public T DeactivateTopPopup<T>() where T : PopupBase
    {
        if (CurrentPopup != null && screenStack.Count > 0)
        {
            DeactivateTopPopup();
            return null;
        }
        else
        {
            return Deactivate<T>();
        }
    }
}