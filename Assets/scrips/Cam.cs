using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Collider2D))]
public class Cam : MonoBehaviour {

    // Use this for initialization
    public int dir;
    private GameObject camara;
	void Start () {
        camara = Camera.main.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseOver()
    {
        float x = 0, y = 0, z = 0;
        
       if(dir == 1) x = 0.005f;
       else if (dir == 3) x = -0.005f;
        if (x != 0)
        {
            if (camara.transform.position.x + x > -0.4 && camara.transform.position.x + x < 0.55)
                camara.transform.position = new Vector3(camara.transform.position.x + x, camara.transform.position.y + y, camara.transform.position.z + z);
        }
        else
        {
          
            if (camara.transform.rotation.x > -0.2 && dir == 0) 
                camara.transform.Rotate(new Vector3(1, 0, 0), -0.3f);
            else if( camara.transform.rotation.x < 0.4 && dir == 2){
                camara.transform.Rotate(new Vector3(1, 0, 0), 0.3f);
            }
        }
    }
}
