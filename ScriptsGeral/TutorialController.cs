using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

    public enum ScreenType
    {
        None,
        Tuto1,
        Tuto2,
        Tuto3,
    }

    public Animator sideBar;
    bool anima = false;
    public Animator tuto1Animator;
    public Animator tuto2Animator;
    public Animator tuto3Animator;

    public AnimatorEventReceiver tuto1AnimatorEventReceiver;
    public AnimatorEventReceiver tuto2AnimatorEventReceiver;
    public AnimatorEventReceiver tuto3AnimatorEventReceiver;

    public ScreenType currentScreenType;
    public ScreenType toScreenType;
    public bool animando;

    void Start()
    {
        tuto1AnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        tuto2AnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        tuto3AnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        ChangeState(ScreenType.Tuto1);
    }

    void ChangeState(ScreenType toState)
    {
        if (currentScreenType == toState || animando)
            return;

        toScreenType = toState;
        CloseScreen();
    }

    void OpenScreen()
    {
        animando = true;
        if (currentScreenType == ScreenType.None)
            HandleOnAnimationEnd("Open");
        else if (currentScreenType == ScreenType.Tuto1)
            tuto1Animator.Play("Open");
        else if (currentScreenType == ScreenType.Tuto2)
            tuto2Animator.Play("Open");
        else if (currentScreenType == ScreenType.Tuto3)
            tuto3Animator.Play("Open");
    }

    void CloseScreen()
    {
        animando = true;
        if (currentScreenType == ScreenType.None)
            HandleOnAnimationEnd("Close");
        else if (currentScreenType == ScreenType.Tuto1)
            tuto1Animator.Play("Close");
        else if (currentScreenType == ScreenType.Tuto2)
            tuto2Animator.Play("Close");
        else if (currentScreenType == ScreenType.Tuto3)
            tuto3Animator.Play("Close");
    }

    #region OnClickButton Events Handlers

    public void HandleOnClickTuto1()
    {
        ChangeState(ScreenType.Tuto1);
    }

    public void HandleOnClickTuto2()
    {
        ChangeState(ScreenType.Tuto2);
    }

    public void HandleOnClickTuto3()
    {
        ChangeState(ScreenType.Tuto3);
    }

    #endregion

    #region AnimatorEventReceiver Events Handlers

    void HandleOnAnimationEnd(string identifier)
    {
        animando = false;
        currentScreenType = toScreenType;
        if (identifier == "Close")
        {
            OpenScreen();
        }
    }

    #endregion
}
