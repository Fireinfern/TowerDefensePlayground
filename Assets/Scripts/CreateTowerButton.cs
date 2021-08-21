using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateTowerButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{  
    [SerializeField]
    private GameObject towerToCreate;
    GameObject createdTower;

    public void CreateTower(){
        createdTower = Instantiate(towerToCreate);
        createdTower.GetComponent<TowerTouchController>().GrabTower();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CreateTower();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        createdTower.GetComponent<TowerTouchController>().PutDownTower();
        createdTower = null;
    }
}
