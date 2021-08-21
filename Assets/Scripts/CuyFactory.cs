using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyFactory : MonoBehaviour
{
    [SerializeField]
    private List<string> keys = new List<string>();
    
    [SerializeField]
    private List<GameObject> values = new List<GameObject>();

    [SerializeField]
    private Dictionary<string,GameObject> availableCuys = new Dictionary<string,GameObject>();

    public GameObject CreateNewCuy(string key) {
        return Instantiate(availableCuys[key]);
    }

    private void GenerateXCuys(string key, int quantity){
        for(int i = 0; i < quantity; i++){
            CreateNewCuy(key);
        }
    }

    public void GenerateWave(Dictionary<string, int> cuysToBeSpawned){
        foreach (KeyValuePair<string, int> typeOfCuy in cuysToBeSpawned)
        {
            GenerateXCuys(typeOfCuy.Key, typeOfCuy.Value);
        }
    }
}
