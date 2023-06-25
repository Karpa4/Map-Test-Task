using System;
using UnityEngine;

public class InfoPointButton : MonoBehaviour
{
    public RectTransform Rect;
    private int index;

    public event Action<int> PointClicked;

    public void InitPoint(int index)
    {
        this.index = index;
    }

    public void Click()
    {
        PointClicked?.Invoke(index);
    }
}
