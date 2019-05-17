using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICustomMessageTarget : IEventSystemHandler
{
    // functions that can be called via the messaging system
    void receiveAction(States Action);
    void setTexBox(string text);
    void Message2();
}

public class OB : MonoBehaviour{

    public GameObject preview;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            preview.SetActive(true);
            previewing = true;
            initQ = preview.transform.rotation;
        }
       
    }
    void Start()
    {
       
    }
    bool previewing = false;
    Quaternion initQ;


    public virtual void Update()
    {
       
        if (previewing)
        {
            if (Input.GetMouseButtonUp(1))
            {
                preview.SetActive(false);
                previewing = false;
                preview.transform.rotation = initQ;
            }

           
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
 {
               
                preview.transform.Rotate(new Vector3(-4f,-5f,-3f));
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
 {
                preview.transform.Rotate(new Vector3(4f, 5f, 3f));
            }
        }
    }
    public virtual void doStuff(string accion)
    {
       

    }
    public void sendAction(States action)
    {
        foreach (GameObject tg in GM.instance.listeners)
            ExecuteEvents.Execute<ICustomMessageTarget>(tg, null, (x, y) => x.receiveAction(action));
    }
    public void sendText(string text)
    {
        foreach (GameObject tg in GM.instance.listeners)
            ExecuteEvents.Execute<ICustomMessageTarget>(tg, null, (x, y) => x.setTexBox(text));
    }
}

	
