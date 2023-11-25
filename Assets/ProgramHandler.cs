using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ProgramHandler : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private GameObject Carlo;
    public List<GameObject> list;
    public List<string> command;
    private object rectTransform;
    private int top;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   /** void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            Debug.Log(list.Count);
            getCommand();
            for (int i = 0; i < command.Count; i++)
            {
                Debug.Log(command[i]);
            }
            Debug.Log(getCommand());
        }
    }
   **/
    public void updateList()
    {
        top = (int) Mathf.Round(canvas.GetComponent<RectTransform>().rect.height);
        //Debug.Log("Height " + top);
        //Debug.Log(list);
        //Debug.Log(list.Count);
        GameObject[] fist = list.ToArray();
        foreach (GameObject item in list)
        {
            //item.GetComponent<ProgramBlock>;
            fuckinbitch(item, list.IndexOf(item));
            //GameObject obj = item.TryGetComponent<ProgramBlock>;
            //Debug.Log(list.IndexOf(item));
        }
    }

    public void fuckinbitch(GameObject obj, int i)
    {
        obj.GetComponent<ProgramBlock>().rectTransform.anchoredPosition = new Vector2(-350, (top/2)-20-(i*40));
    }

    public void Add(GameObject obj)
    {
        list.Add(obj);
        Debug.Log("Added");
    }

    public void Remove(GameObject obj)
    {
        list.Remove(obj);
        //Debug.Log("Removed");
    }

    public void log()
    {
        //Debug.Log(list);
    }

    public string[] getCommand()
    {
        command.Clear();
        foreach (GameObject item in list)
        {
            command.Add(item.GetComponent<ProgramBlock>().getName());
        }
        return command.ToArray();
    }
}
