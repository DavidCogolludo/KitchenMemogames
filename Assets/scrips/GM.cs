using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

   public enum States { BOILINGSPAGUETTI, SPAGUETTIREADY, WATERBOILING, POTHASWATER,POTEMPTY}
public class GM : MonoBehaviour {
    public GameObject[] triggers;
    public static GM instance;                   //Singelton del GM
    public GameObject[] listeners;                            
    bool _draggin;
    void Start () {
        //Creamos el singleton
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        _draggin = false;
       
    }
    public void sendAction(States action)
    {
        foreach (GameObject tg in listeners)
            ExecuteEvents.Execute<ICustomMessageTarget>(tg, null, (x, y) => x.receiveAction(action));
    }
    public void sendText(string text)
    {
        foreach (GameObject tg in listeners)
            ExecuteEvents.Execute<ICustomMessageTarget>(tg, null, (x, y) => x.setTexBox(text));
    }
  
    // Update is called once per frame
    void Update () {
        if (!_draggin&& Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hola");
            foreach (GameObject go in triggers)
            {
                go.SetActive(false);
            }
        }
	}

    public void Draggin()
    {
        foreach (GameObject go in triggers)
        {
            go.SetActive(true);
        }
        _draggin = true;
    }
    public void Dropped()
    {
        _draggin = false;
        
       foreach (GameObject go in triggers)
       {
            go.SetActive(false);
       }
        //doStuff();
    }
    private void OnMouseDown()
    {
        Debug.Log("Hola");
        foreach (GameObject go in triggers)
        {
            go.SetActive(false);
        }
    }
    string accion_; GameObject target = null;
    public void doStuff(string accion, GameObject go)
    {
        accion_ = accion;
        target = go;
        doStuff();
    }
    public void doStuff()
    {
        if (target)
        {
            target.GetComponent<OB>().doStuff(accion_);
        }
        target = null;
    }

    public bool draggin
    {
        get { return _draggin; } //you can do something like this mod function 
        set {  } //you can manipulate the value being set 

    }
}
