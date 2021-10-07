using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    void Awake() {
        instance = this;
    }

    public void destroyEnemy(GameObject enemy) {
        Destroy(enemy);
    }
}
