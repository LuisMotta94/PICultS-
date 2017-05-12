using UnityEngine;
using System.Collections;

public class animaController : MonoBehaviour {

    public enum ScreenType
    {
        None,
        Iniciar,
        Fases,
        Trofeus,
        PopUpAcerto,
        PopUpErro,
    }

    public Animator sideBar;
    bool anima = false;
    public Animator iniciarAnimator;
    public Animator popUpErroAnimator;
    public Animator fasesAnimator;
    public Animator trofeusAnimator;
    public Animator popUpAcertoAnimator;

    public AnimatorEventReceiver iniciarAnimatorEventReceiver;
    public AnimatorEventReceiver popUpErroAnimatorEventReceiver;
    public AnimatorEventReceiver fasesAnimatorEventReceiver;
    public AnimatorEventReceiver trofeusAnimatorEventReceiver;
    public AnimatorEventReceiver popUpAcertoAnimatorEventReceiver;

    public ScreenType currentScreenType;
    public ScreenType toScreenType;
    public bool animando;
     
    void Start()
    {
        popUpAcertoAnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        iniciarAnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        popUpErroAnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        fasesAnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        trofeusAnimatorEventReceiver.OnAnimationEnd += HandleOnAnimationEnd;
        
        ChangeState(ScreenType.Iniciar);
    }

    void ChangeState (ScreenType toState)
    {
        if (currentScreenType == toState || animando)
            return;

        toScreenType = toState;
        CloseScreen();
    }

    public void ShowQuestion()
    {
        print("entro newwwbwj");
        //GetComponent<Animator>().Play("OpenQuest");
        GetComponent<Animator>().Play("Close");
        //GetComponent<Animator>().Play("Acerto");
        
    }

    public void OpenScreen ()
    {
        animando = true;
        if (currentScreenType == ScreenType.None)
            HandleOnAnimationEnd("Open");
        else if (currentScreenType == ScreenType.Iniciar)
            iniciarAnimator.Play("OpenQuest");
        else if (currentScreenType == ScreenType.PopUpErro)
        {
            popUpErroAnimator.Play("Open");
            //popUpErroAnimator.Play("Fade");
        }
        else if (currentScreenType == ScreenType.Fases)
            fasesAnimator.Play("Open");
        else if (currentScreenType == ScreenType.Trofeus)
            trofeusAnimator.Play("Open");
        else if (currentScreenType == ScreenType.PopUpAcerto)
            popUpAcertoAnimator.Play("OpenQuest");
    }

    public void CloseScreen()
    {
        animando = true;
        if (currentScreenType == ScreenType.None)
            HandleOnAnimationEnd("Close");
        else if (currentScreenType == ScreenType.Iniciar)
            iniciarAnimator.Play("Close");
        else if (currentScreenType == ScreenType.PopUpErro)
            popUpErroAnimator.Play("Close");
        else if (currentScreenType == ScreenType.Fases)
            fasesAnimator.Play("Close");
        else if (currentScreenType == ScreenType.Trofeus)
            trofeusAnimator.Play("Close");
        else if (currentScreenType == ScreenType.PopUpAcerto)
            popUpAcertoAnimator.Play("CloseQuest");
    }

    #region OnClickButton Events Handlers

    public void HandleOnClickIniciar ()
    {
        ChangeState(ScreenType.Iniciar);
    }

    public void HandleOnClickpoPUpErro()
    {
        ChangeState(ScreenType.PopUpErro);
    }

    public void HandleOnClickFases()
    {
        ChangeState(ScreenType.Fases);
    }
    public void HandleOnClickTrofeus()
    {
        ChangeState(ScreenType.Trofeus);
    }
    public void HandleOnClickPopUpAcerto()
    {
        ChangeState(ScreenType.PopUpAcerto);
    }

    #endregion

    #region AnimatorEventReceiver Events Handlers

    void HandleOnAnimationEnd (string identifier)
    {
        animando = false;
        currentScreenType = toScreenType;
        if (identifier == "Close")
        {
            OpenScreen ();
        }
    }

    #endregion
    public void OpenSideBar()
    {
        if (!anima)
            sideBar.Play("Open");
        else
            sideBar.Play("Close");

        anima = !anima;
    }
}
