using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "is dropped on: " + gameObject.name);
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        
        if(d != null)
        {
            d.returnToParent = this.transform;
        }
    }
}   
