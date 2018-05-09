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
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject);
        if (Input.GetMouseButtonUp(0))
        {
            GM.instance.doStuff(accion, other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
