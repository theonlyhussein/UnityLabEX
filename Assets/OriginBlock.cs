using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;
using Palmmedia.ReportGenerator.Core;

public class clickAndDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject PB;
    private GameObject newPB;
    public GameObject PH;

    public void OnBeginDrag(PointerEventData eventData)
    {
        newPB = Instantiate(PB, canvas.transform);
        newPB.SetActive(true);
        newPB.GetComponent<ProgramBlock>().OnBeginDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        newPB.GetComponent<ProgramBlock>().OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        newPB.GetComponent<ProgramBlock>().dropHandler();
    }
    
}



