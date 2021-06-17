using System.Collections.Generic;
using UIFramework;
using UnityEngine;

public class BackBtnManager : MonoBehaviour
{
    private Stack<ScreenBase> openedScreens = new Stack<ScreenBase>();
    public static BackBtnManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OnBackBtnClick(ScreenBase currentScreen)
    {
        currentScreen.Deactivate();
        if(openedScreens.Count > 0)
        {
            ScreenBase screen = openedScreens.Peek();
            ScreenFactory.Instance.Activate(screen);
            openedScreens.Pop();
        }
    }


    public void AddScreenToStack(ScreenBase screen)
    {
        openedScreens.Push(screen);
    }

    public void RemoveScreenFromStack()
    {
        openedScreens.Pop();
    }
}
