using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class InfoPointWindow : MonoBehaviour
{
    [SerializeField] private RectTransform pointWindowRect;
    [SerializeField] private float duration;
    [SerializeField] private float closeX;
    [SerializeField] private float activeX;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI noImageText;
    [SerializeField] private Image pointImage;
    [SerializeField] private Button imageButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private PhotoGallery gallery;

    private List<Sprite> pointSprites;

    private void Start()
    {
        imageButton.onClick.AddListener(OpenGallery);
        closeButton.onClick.AddListener(CloseWindow);
    }

    public void CloseWindow()
    {
        if (gameObject.activeSelf)
        {
            pointWindowRect.DOAnchorPosX(closeX, duration).OnComplete(() => gameObject.SetActive(false));
            gallery.Close();
        }
    }

    public void ShowInfo(InfoPoint point)
    {
        gameObject.SetActive(true);
        description.text = point.Description;
        pointSprites = point.PointImages;
        if (CheckPointSprites())
        {
            pointImage.sprite = pointSprites[0];
            SwitchImageAndText(true);
        }
        else
        {
            SwitchImageAndText(false);
        }
        pointWindowRect.DOAnchorPosX(activeX, duration);
    }

    private void SwitchImageAndText(bool switcher)
    {
        if (imageButton.gameObject.activeSelf != switcher)
        {
            imageButton.gameObject.SetActive(switcher);
            noImageText.gameObject.SetActive(!switcher);
        }
    }

    private bool CheckPointSprites()
    {
        if (pointSprites == null)
        {
            return false;
        }
        else if (pointSprites.Count == 0)
        {
            return false;
        }
        return true;
    }

    private void OpenGallery()
    {
        gallery.InitGallery(pointSprites);
    }

    private void OnDestroy()
    {
        imageButton.onClick.RemoveListener(OpenGallery);
        closeButton.onClick.RemoveListener(CloseWindow);
    }
}
