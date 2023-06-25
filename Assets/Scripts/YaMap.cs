using System.Collections.Generic;
using UnityEngine;

public class YaMap
{
    public float Longitude { set; get; }
    public float Latitude { set; get; }
    public float Zoom { set; get; }
    public int Width { set; get; }
    public int Height { set; get; }
    public TypeMap TypeOfMap { set; get; }
    public TypeMapLayer LayerType { set; get; }
    public enum TypeMap
    {
        map,
        sat
    }
    public bool EnabledLayer { set; get; }
    public enum TypeMapLayer
    {
        skl,
        trf
    }
}
