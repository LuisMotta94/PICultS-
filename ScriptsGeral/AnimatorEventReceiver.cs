using UnityEngine;

public class AnimatorEventReceiver : MonoBehaviour
{
    #region Events

    public event System.Action<string> OnAnimationStart;
    public event System.Action<string> OnAnimationEnd;

    #endregion

    #region Fields

    [SerializeField]
    bool isDebug;
    Animator cachedAnimator;

    #endregion

    #region Properties

    public Animator CachedAnimator
    {
        get
        {
            if (cachedAnimator == null)
                cachedAnimator = GetComponent<Animator> ();
            return cachedAnimator;
        }
    }

    #endregion

    #region Public Methods

    public void PlayAnimation (string clip)
    {
        CachedAnimator.Play (clip);
    }

    #endregion

    #region Private Methods

    protected virtual void AnimationStartAction (string identifier)
    {
        if (isDebug)
            Debug.Log ("[AnimatorEventReceiver] (AnimationStartAction) identifier: " + identifier);

        if (OnAnimationStart != null)
            OnAnimationStart (identifier);
    }

    protected virtual void AnimationEndAction (string identifier)
    {
        if (isDebug)
            Debug.Log ("[AnimatorEventReceiver] (AnimationEndAction) identifier: " + identifier);

        if (OnAnimationEnd != null)
            OnAnimationEnd (identifier);
    }

    #endregion

    #region Animation Events Handlers

    void HandleOnAnimationStart (string identifier)
    {
        AnimationStartAction (identifier);
    }

    void HandleOnAnimationEnd (string identifier)
    {
        AnimationEndAction (identifier);
    }

    #endregion
}