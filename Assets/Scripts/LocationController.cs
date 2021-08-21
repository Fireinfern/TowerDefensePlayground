using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider)){
            other.GetComponent<CuyController>().NextLocation();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider)) {
            other.GetComponent<CuyController>().ChangingLocation = false;
        }
    }
}
