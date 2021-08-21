using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    static public TouchManager instance;


    private GameObject grabedTower;
    public bool isGrabing = false;

    void Awake()
    {
        instance = this;
    }

    void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "Tower")
                        {
                            isGrabing = true;
                            hit.collider.GetComponent<TowerTouchController>().GrabTower();
                            grabedTower = hit.collider.gameObject;
                        }
                    }
                }
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                if (isGrabing)
                {
                    isGrabing = false;
                    if (grabedTower.tag == "Tower")
                    {
                        grabedTower.GetComponent<TowerTouchController>().PutDownTower();
                    }
                }
            }
        }
    }

    void Update()
    {
        GetTouch();
    }
}
