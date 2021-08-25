using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyController : MonoBehaviour
{
    [SerializeField]
    private float Velocity = 1.0f;

    [Header("CuyPath")]
    [SerializeField]
    private GameObject path;

    private Queue<Vector3> Locations;

    public bool ChangingLocation = false;

    public bool Lured = false;

    public void SetLocations(GameObject Path){
        path = Path;
        Locations = new Queue<Vector3>(path.gameObject.GetComponent<LevelPath>().GetLocations());
    }

    void Start() {
        //Locations = new Queue<Vector3>(path.gameObject.GetComponent<LevelPath>().GetLocations());
    }

    void Update() {
        if(Locations.Count != 0 && !Lured) {
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    Locations.Peek(),
                                                    Velocity * Time.deltaTime);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward,
                                                    Locations.Peek() - transform.position,
                                                    Velocity / 5 * Time.deltaTime, 0.0f);
            //Debug.DrawRay(transform.position, Locations.Peek() - transform.position, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        if(Lured){
            Debug.Log("Lured");
        }

    }

    public void NextLocation() {
        if(!ChangingLocation){
            Locations.Dequeue();
            ChangingLocation = true;
        }
    }
}
