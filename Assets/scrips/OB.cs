using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OB : MonoBehaviour{

    public GameObject preview;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            preview.SetActive(true);
        }
       
    }
    void Start()
    {
        
    }
    public virtual void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            preview.SetActive(false);

        }
    }
    public virtual void doStuff(string accion)
    {
        Debug.Log("holiwi");
    }
}

	
