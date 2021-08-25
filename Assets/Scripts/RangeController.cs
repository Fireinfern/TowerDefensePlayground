using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    private List<GameObject> enemiesInRange;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Enemy"){
            enemiesInRange.Remove(other.gameObject);
        }
    }

    public List<GameObject> getEnemiesInRange(){
        return enemiesInRange;
    }
}
