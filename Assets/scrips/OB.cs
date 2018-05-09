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
        Debug.Log("holiwi");
    }
}

	
