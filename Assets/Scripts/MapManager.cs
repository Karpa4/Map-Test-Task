using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] private MapZoomControl zoomControl;
    [SerializeField] private RawImage mapImage;
    [SerializeField] private InfoPointManager pointManager;
    [Header("StartMapSettings")]
    [SerializeField] private YaMap.TypeMap typeMap;
    [SerializeField] private YaMap.TypeMapLayer mapLayer;
    [SerializeField] private float lat;
    [SerializeField] private float lon;
    [SerializeField] private List<Vector2> markers;
    private MapLoader loader;
    private YaMap currentMap;
    private const int MapWidth = 450;
    private const int MapHeight = 450;

    private void Start()
    {
        InitStartMap();
        loader = new MapLoader();
        LoadNewMap();
        zoomControl.ZoomChanged += ChangeMapZoom;
    }

    private async void LoadNewMap()
    {
        Texture texture = await loader.LoadMap(currentMap);
        pointManager.ChangePointsPosition(new Vector2(lon, lat), currentMap.Zoom);
        mapImage.texture = texture;
    }

    private void InitStartMap()
    {
        currentMap = new YaMap()
        {
            EnabledLayer = true,
            LayerType = mapLayer,
            TypeOfMap = typeMap,
            Zoom = zoomControl.StartZoom,
            Width = MapWidth,
            Height = MapHeight,
            Longitude = lon,
            Latitude = lat,
        };
    }

    private void ChangeMapZoom(float zoom)
    {
        currentMap.Zoom = zoom;
        LoadNewMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GGG();
        }
    }

    private async void GGG()
    {
        YaMap map = new YaMap()
        {
            EnabledLayer = true,
            LayerType = mapLayer,
            TypeOfMap = typeMap,
            Width = MapWidth,
            Zoom = zoomControl.StartZoom,
            Height = MapHeight,
            Longitude = lon,
            Latitude = lat,
        };
        
        Texture texture = await loader.LoadMap(map);
        mapImage.texture = texture;
    }
}
