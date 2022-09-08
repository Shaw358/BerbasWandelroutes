using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;

public class MapCenter : MonoBehaviour
{
    [SerializeField] AbstractMap aMap;
    [SerializeField] Vector2d berbasLocation;

    private void Update()
    {
        aMap.UpdateMap(berbasLocation);
    }
}