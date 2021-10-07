using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTouchController : MonoBehaviour
{

    [SerializeField]
    private BoxCollider towerTouchCollider;
    [SerializeField]
    private List<GameObject> ChildrenToActivate;
    private bool moving = false;
    private bool canBeMoved = true;

    private Vector3 LastPlatform;

    Plane LimitPlane = new Plane(Vector3.up, 0.0f);

    public void GrabTower()
    {
        if(canBeMoved){
            moving = true;
            towerTouchCollider.enabled = false;
        }
    }

    public void PutDownTower()
    {
        try{
            transform.GetChild(0).gameObject.SetActive(true);
        }
        catch {
            Debug.Log("Cool");
        }
        moving = false;
        canBeMoved = false;
        towerTouchCollider.enabled = true;
        gameObject.transform.position = LastPlatform;
        for(int i = 0; i < ChildrenToActivate.Count; i++){
            ChildrenToActivate[i].SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (moving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            float distance;
            if (Physics.Raycast(ray, out hit,10000f, 1 << 7 , QueryTriggerInteraction.Ignore))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Platform")
                    {
                        Vector3 extraPos = hit.collider.gameObject.transform.position;
                        gameObject.transform.position = new Vector3(extraPos.x, 0.25f , extraPos.z);
                        LastPlatform = gameObject.transform.position;
                    }
                }
            }
            else if(LimitPlane.Raycast(ray, out distance)){
                Vector3 PlanePos = ray.GetPoint(distance);
                gameObject.transform.position = new Vector3(PlanePos.x, 0.25f , PlanePos.z);
            }
        }
    }
}
