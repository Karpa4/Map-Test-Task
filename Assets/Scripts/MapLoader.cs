using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class MapLoader
{
    public async Task<Texture> LoadMap(YaMap map)
    {
        string url = GetYandexUrl(map);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            var download = DownloadHandlerTexture.GetContent(request);
            download.name = "YandexMap";
            return download;
        }
        else
        {
            return null;
        }
    }

    private string[] ConvertList(List<Vector2> markers)
    {
        string[] convert = new string[markers.Count];

        for (int i = 0; i < markers.Count; i++)
        {
            convert[i] = Convert(markers[i].x) + "," + Convert(markers[i].y);
        }

        return convert;
    }

    private string Convert(float value)
    {
        string convert = value.ToString().Replace(',', '.');
        return convert;
    }

    private string GetYandexUrl(YaMap map)
    {
        var url = map.EnabledLayer
        ? "https://static-maps.yandex.ru/1.x/?ll=" +
        Convert(map.Longitude) + "," +
        Convert(map.Latitude) +
        "&spn=" + Convert(map.Zoom) + "," + Convert(map.Zoom) +
        "&size=" + map.Width.ToString() + "," + map.Height.ToString() +
        "&l=" + map.TypeOfMap + "," + map.LayerType +
        "&apikey=1a4c1aab-9ccb-4b64-aa78-8c7449d3a0a2"
        : "https://static-maps.yandex.ru/1.x/?ll=" +
        Convert(map.Longitude) + "," +
        Convert(map.Latitude) +
        "&spn=" + Convert(map.Zoom) + "," + Convert(map.Zoom) +
        "&size=" + map.Width.ToString() + "," + map.Height.ToString() +
        "&l=" + map.TypeOfMap +
        "&apikey=1a4c1aab-9ccb-4b64-aa78-8c7449d3a0a2";
        return url;
    }
}
