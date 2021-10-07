using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureTowerEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject RangeObject;

    [SerializeField]
    private GameObject LureFoodObject;

    void Awake()
    {

    }

    void FixedUpdate()
    {
        if (RangeObject.activeSelf)
        {
            if (RangeObject.GetComponent<RangeController>().getEnemiesInRange().Count > 0
                && LureFoodObject.activeSelf)
            {
                Debug.Log(RangeObject.GetComponent<RangeController>().getEnemiesInRange()[0]);
            }
        }
    }
}
