using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapZoomControl : MonoBehaviour
{
    [SerializeField] private Button zoomOut;
    [SerializeField] private Button zoomIn;
    [SerializeField] private List<float> allZooms;
    [SerializeField] private int startIndex;
    private int currentIndex;

    public float StartZoom => allZooms[startIndex];
    public event Action<float> ZoomChanged;

    private void Start()
    {
        currentIndex = startIndex;
        zoomIn.onClick.AddListener(ZoomIn);
        zoomOut.onClick.AddListener(ZoomOut);
    }

    public void CleanUp()
    {
        zoomIn.onClick.RemoveListener(ZoomIn);
        zoomOut.onClick.RemoveListener(ZoomOut);
    }

    private void ZoomIn()
    {
        currentIndex--;
        ZoomChanged?.Invoke(allZooms[currentIndex]);
        CheckZoomRange(currentIndex);
    }

    private void ZoomOut()
    {
        currentIndex++;
        ZoomChanged?.Invoke(allZooms[currentIndex]);
        CheckZoomRange(currentIndex);
    }

    private void CheckZoomRange(int currentIndex)
    {
        if (currentIndex == 0)
        {
            zoomIn.interactable = false;
        }
        else
        {
            if (currentIndex == allZooms.Count - 1)
            {
                zoomOut.interactable = false;
            }
            else
            {
                if (!zoomOut.interactable)
                {
                    zoomOut.interactable = true;
                }
                if (!zoomIn.interactable)
                {
                    zoomIn.interactable = true;
                }
            }
        }
    }
}
