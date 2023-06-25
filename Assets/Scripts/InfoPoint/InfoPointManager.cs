using System.Collections.Generic;
using UnityEngine;

public class InfoPointManager : MonoBehaviour
{
    [SerializeField] private List<InfoPointButton> pointButtons;
    [SerializeField] private CheckInaction checkInaction;
    [SerializeField] private InfoPointWindow infoWindow;
    [SerializeField] private List<InfoPoint> points;

    private void Start()
    {
        checkInaction.UserIsInactive += ResetToDefault;

        if (points.Count > pointButtons.Count)
        {
            Debug.LogWarning("Add more InfoPointButton");
            return;
        }
        for (int i = 0; i < points.Count; i++)
        {
            pointButtons[i].InitPoint(i);
            pointButtons[i].PointClicked += ShowInfo;
        }
    }

    public void ChangePointsPosition(Vector2 center, float size)
    {
        for (int i = 0; i < points.Count; i++)
        {
            
        }
    }

    private void ResetToDefault()
    {
        infoWindow.CloseWindow();
    }

    private void ShowInfo(int index)
    {
        infoWindow.ShowInfo(points[index]);
    }

    private void OnDestroy()
    {
        checkInaction.UserIsInactive -= ResetToDefault;
        for (int i = 0; i < points.Count; i++)
        {
            pointButtons[i].PointClicked -= ShowInfo;
        }
    }
}
