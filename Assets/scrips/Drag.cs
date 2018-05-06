using System.Collections;
using UnityEngine;

class Drag : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    GM gameManager;
    Vector3 initPos;


    private void Start()
    {
        
    }
    void OnMouseEnter()
    {
       //this.GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
       // this.GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        initPos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(initPos.x, initPos.y, initPos.z);
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        //transform.position = new Vector3(transform.position.x - cateto, transform.position.y, 0.65f);
        dragging = true;
        GM.instance.Draggin();
    }

    void OnMouseUp()
    {
        dragging = false;
        this.gameObject.transform.position = initPos;
        GM.instance.Dropped();
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance); //rayPoint.x = -0.0323f;
            transform.position = new Vector3(rayPoint.x, rayPoint.y, transform.position.z);
        }
    }
}