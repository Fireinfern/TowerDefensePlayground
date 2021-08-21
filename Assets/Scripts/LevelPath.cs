using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPath : MonoBehaviour
{
    private Queue<Vector3> Locations = new Queue<Vector3>();

    [SerializeField]
    private GameObject locationPrefab;

    [SerializeField]
    private TextAsset JSONPath;
    private Path path;

    void Awake() {
        path = JsonUtility.FromJson<Path>(JSONPath.ToString());
        foreach(Location loc in path.Locations) {
            Locations.Enqueue(new Vector3(loc.X, loc.Y, loc.Z));
            GameObject currentInstance = Instantiate(locationPrefab, new Vector3(loc.X, loc.Y, loc.Z), Quaternion.identity);
        }
    }

    public Queue<Vector3> GetLocations() {
        return Locations;
    }
}
