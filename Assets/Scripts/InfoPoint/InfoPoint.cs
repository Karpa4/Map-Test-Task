using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InfoPoint
{
    [SerializeField] private string description;
    [SerializeField] private List<Sprite> images;
    [SerializeField] private Vector2 mapPosition;

    public Vector2 PointPosition => mapPosition;
    public string Description => description;
    public List<Sprite> PointImages => images;
}
