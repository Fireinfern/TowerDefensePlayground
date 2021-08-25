using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyFactory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cuyes;

    [SerializeField]
    private GameObject path;

    private float spawnCounter = 0;

    public void SpawnCuy(int index){
        GameObject newCuy = Instantiate<GameObject>(cuyes[index]);
        newCuy.GetComponent<CuyController>().SetLocations(path);
        newCuy.SetActive(true);
    }

    void Update() {
        spawnCounter += Time.deltaTime;
        if(spawnCounter >= 1.0f){
            SpawnCuy(0);
            spawnCounter = 0;
        }
    }
}
