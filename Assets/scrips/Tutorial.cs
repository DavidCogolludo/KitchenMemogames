using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Tutorial : MonoBehaviour, ICustomMessageTarget
{

    public Text text;
    public Animation animTextBox;
    private bool played;
	// Use this for initialization
	void Start () {
        played = false;
	}
	
	
    public void receiveAction(States action)
    {
        Debug.Log("Message 1 received");
        animTextBox.Play();
        switch (action)
        {
            case States.BOILINGSPAGUETTI: break;
        }
    }
    public void setTexBox(string text)
    {
        Debug.Log("Message 1 received");
       animTextBox.Play();
  
       
        this.text.text = text;
       
    }

    public void Message2()
    {
        Debug.Log("Message 2 received");
    }


}
