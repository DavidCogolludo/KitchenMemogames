using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInfo : MonoBehaviour {

    public string accion;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    bool enter = false;
    private Collider aux;
    private void OnTriggerEnter(Collider other)
    {
        enter = true;
        aux = other;
    }
    private void OnDisable()
    {
        if (enter)
        {
            if (!Input.GetMouseButton(0))
            {
                Debug.Log(aux.name + ", " + accion);
                GM.instance.doStuff(accion, aux.gameObject);
            }
            enter = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        enter = false;
        
    }
}
