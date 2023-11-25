using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using System.Linq;

public class ProgramBlock : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private int snap;
    public RectTransform rectTransform;
    public GameObject ghost;
    public GameObject PH;
    public string name =" ";

    public string getName() {  return name; }

    private void Awake()
    {
        PH.GetComponent<ProgramHandler>().Add(gameObject);
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(rectTransform);
        Debug.Log(rectTransform.anchoredPosition);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ghost = Instantiate(gameObject, canvas.transform);
        ghost.transform.SetParent(canvas.transform.GetChild(2));
        ghost.GetComponent<Image>().color = new Color32(200, 200, 200, 100);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //ghost.GetComponent<ProgramBlock>().rectTransform.anchoredPosition = new Vector2(-300, Mathf.Round(rectTransform.anchoredPosition.y / 50) * 50);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dropHandler();
    }

    public void dropHandler()
    {
        PH.GetComponent<ProgramHandler>().list.Remove(ghost);
        Destroy(ghost);
        if (rectTransform.anchoredPosition.x > 0)
        {
            PH.GetComponent<ProgramHandler>().list.Remove(gameObject);
            Destroy(gameObject);
        }
        //rectTransform.anchoredPosition = new Vector2(-300, Mathf.Round(rectTransform.anchoredPosition.y / 50) * 50);
        gameObject.transform.SetParent(canvas.transform.GetChild(2));
 
        PH.GetComponent<ProgramHandler>().updateList();
    }

    public void dropHandler(int index)
    {
        
    }
}
