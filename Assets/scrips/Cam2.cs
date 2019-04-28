using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2 : MonoBehaviour {

    Vector2 touchDeltaPosition;
    public float bounds;
    public float speed = 1;
    public float eulerSpeed = 3.5f;
    public float maxAngleX, maxAngleY;
    public float maxX, minX;
    public float maxY, minY;
    float step = 0.5f;
    public GameObject target;
    int cont = 0;
    private float X;
    private float Y;
    private void Update()
    {
        if (Input.GetMouseButton(1) && Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * eulerSpeed, -Input.GetAxis("Mouse X") * eulerSpeed, 0));
            float angleY = gameObject.transform.localEulerAngles.y;


            if (angleY >= 180) angleY -= 360;
            if (transform.localEulerAngles.x <= maxAngleX)
                X = transform.rotation.eulerAngles.x;
            if (angleY <= maxAngleY && angleY >= -maxAngleY)
                Y = transform.rotation.eulerAngles.y;

            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
        else
        {
            float mouseX = Input.mousePosition.x;

            float mouseY = Input.mousePosition.y;
            if (mouseX < 0 || mouseX > Screen.width || mouseY < 0 || mouseY > Screen.height) return;
            if (mouseX <= bounds && transform.position.x >= minX)
            {
                gameObject.transform.position = new Vector3(transform.position.x - step * speed, transform.position.y, transform.position.z);
            }
            else if (mouseX >= Screen.width - bounds && transform.position.x <= maxX)
            {
                gameObject.transform.position = new Vector3(transform.position.x + step * speed, transform.position.y, transform.position.z);

            }
            else if (Input.mousePosition.y <= bounds && transform.position.y >= minY)
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - step * speed, transform.position.z);

            }
            else if (Input.mousePosition.y >= Screen.height - bounds && transform.position.y <= maxY)
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + step * speed, transform.position.z);

            }
        }

       
    }
}
