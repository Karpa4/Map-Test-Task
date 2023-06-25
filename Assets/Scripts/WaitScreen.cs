using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WaitScreen : MonoBehaviour
{
    [SerializeField] private CheckInaction checkInaction;
    [SerializeField] private Button closeButton;
    [SerializeField] private CanvasGroup waitCanvas;
    [SerializeField] private float fadeDuration;

    private Tweener currentTween;

    private void Start()
    {
        currentTween.SetAutoKill(false);
        checkInaction.UserIsInactive += ActiveWaitScreen;
        closeButton.onClick.AddListener(CloseWaitScreen);
    }

    private void ActiveWaitScreen()
    {
        waitCanvas.gameObject.SetActive(true);
        closeButton.interactable = true;
        currentTween = waitCanvas.DOFade(1, fadeDuration);
    }

    private void CloseWaitScreen()
    {
        closeButton.interactable = false;
        checkInaction.ActivateChecking();
        currentTween = waitCanvas.DOFade(0, fadeDuration).OnComplete(()=> waitCanvas.gameObject.SetActive(false));
    }

    private void OnDestroy()
    {
        checkInaction.UserIsInactive -= ActiveWaitScreen;
        closeButton.onClick.RemoveListener(CloseWaitScreen);
    }
}
