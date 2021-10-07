using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuyController : MonoBehaviour
{
    [SerializeField]
    private float Velocity = 1.0f;

    [SerializeField]
    private float CurrentLife = 20.0f; 

    [Header("CuyPath")]
    [SerializeField]
    private GameObject path;

    private Queue<Vector3> Locations;

    public bool ChangingLocation = false;

    public bool Lured = false;

    private List<GameObject> InRangeOf;

    public void SetLocations(GameObject Path){
        path = Path;
        Locations = new Queue<Vector3>(path.gameObject.GetComponent<LevelPath>().GetLocations());
    }

    void Start() {
        //Locations = new Queue<Vector3>(path.gameObject.GetComponent<LevelPath>().GetLocations());
        InRangeOf = new List<GameObject>();
    }

    void Update() {
        CheckIfAlive();
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

    void CheckIfAlive() {
        if(CurrentLife <= 0){
            for(int i = 0; i < InRangeOf.Count; i++){
                InRangeOf[i].GetComponent<RangeController>().removeEnemyInRange(this.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void NextLocation() {
        if(!ChangingLocation){
            Locations.Dequeue();
            ChangingLocation = true;
        }
    }

    public void killCuy(){
        for(int i = 0; i < this.InRangeOf.Count; i++){
            InRangeOf[i].GetComponent<RangeController>().removeEnemyInRange(this.gameObject);
        }
        GameManager.instance.destroyEnemy(this.gameObject);
    }

    public void addInRange(GameObject range){
        this.InRangeOf.Add(range);
    }

    public void removeInRange(GameObject range){
        this.InRangeOf.Remove(range);
    }

    public List<GameObject> getInRange(){
        return this.InRangeOf;
    }

    void OnCollisionEnter(Collision other){
        if(other.collider.tag == "Proyectile"){
            this.CurrentLife -= other.gameObject.GetComponent<ProjectileController>().Damage;
            other.gameObject.GetComponent<ProjectileController>().DestroySelf();
        }
    }
}
