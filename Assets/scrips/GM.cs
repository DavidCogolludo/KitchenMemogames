using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public GameObject[] triggers;
    public static GM instance;                   //Singelton del GM
                                                 // Use this for initialization
    bool _draggin;
    void Start () {
        //Creamos el singleton
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        _draggin = false;
    }
	
	// Update is called once per frame
	void Update () {
		
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
        doStuff();
    }

    string accion_; GameObject target = null;
    public void doStuff(string accion, GameObject go)
    {
        accion_ = accion;
        target = go;
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
