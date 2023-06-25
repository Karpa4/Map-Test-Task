using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PhotoGallery : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private float duration;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    [SerializeField] private Button close;
    [SerializeField] private Image mainImage;
    private List<Sprite> currSprites;
    private int currIndex;
    private int spritesCount;
    private Vector2 startPos;
    private Vector3 startScale;

    private void Start()
    {
        startPos = rect.position;
        startScale = rect.localScale;
        next.onClick.AddListener(ShowNextImage);
        prev.onClick.AddListener(ShowPrevImage);
        close.onClick.AddListener(Close);
    }

    public void InitGallery(List<Sprite> sprites)
    {
        currSprites = sprites;
        mainImage.sprite = sprites[0];
        currIndex = 0;
        spritesCount = currSprites.Count;
        CheckNextPrevButtons();
        gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();
        seq.Append(rect.DOAnchorPos(Vector2.zero, duration)).Insert(0, rect.DOScale(1, duration));
    }

    public void Close()
    {
        if (gameObject.activeSelf)
        {
            rect.position = startPos;
            rect.localScale = startScale;
            gameObject.SetActive(false);
        }
    }

    private void ShowNextImage()
    {
        currIndex++;
        ShowNewImage();
    }

    private void ShowPrevImage()
    {
        currIndex--;
        ShowNewImage();
    }

    private void ShowNewImage()
    {
        mainImage.sprite = currSprites[currIndex];
        CheckNextPrevButtons();
    }

    private void CheckNextPrevButtons()
    {
        if (spritesCount == 1)
        {
            prev.interactable = false;
            next.interactable = false;
            return;
        }

        if (currIndex == 0)
        {
            prev.interactable = false;
            next.interactable = true;
        }
        else
        {
            if (currIndex == spritesCount - 1)
            {
                next.interactable = false;
                prev.interactable = true;
            }
            else
            {
                if (!next.interactable)
                {
                    next.interactable = true;
                }
                if (!prev.interactable)
                {
                    prev.interactable = true;
                }
            }
        }
    }

    private void OnDestroy()
    {
        next.onClick.RemoveListener(ShowNextImage);
        prev.onClick.RemoveListener(ShowPrevImage);
        close.onClick.RemoveListener(Close);
    }
}
