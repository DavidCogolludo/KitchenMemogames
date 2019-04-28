using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour {

    public GameObject slide;
    public float minY, maxY;
    public float bestY;
    public float time;
    float step;
    float timeStep = 0;
	
    public void Awake()
    {
        step = (maxY * 0.1f) / time;
        StartCoroutine(updateTherm());
    }

    IEnumerator updateTherm()
    {
        while (timeStep <= time)
        {
            slide.transform.localPosition = new Vector3(slide.transform.localPosition.x, slide.transform.localPosition.y+step, slide.transform.localPosition.z);
            timeStep += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
	
}
