using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    private List<GameObject> enemiesInRange;

    void Start() {
        enemiesInRange = new List<GameObject>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            enemiesInRange.Add(other.gameObject);
            other.gameObject.GetComponent<CuyController>().addInRange(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Enemy"){
            enemiesInRange.Remove(other.gameObject);
            other.gameObject.GetComponent<CuyController>().removeInRange(this.gameObject);
        }
    }

    public void removeEnemyInRange(GameObject enemy){
        enemiesInRange.Remove(enemy);
    }

    public List<GameObject> getEnemiesInRange(){
        return enemiesInRange;
    }

    public GameObject getPriorityEnemy() {
        return enemiesInRange[0];
    }
}
