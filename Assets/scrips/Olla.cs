using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olla : OB
{
    public Olla(){
       
    }
    bool agua = false;
    public Light fuego; 
  
    public override void doStuff(string accion)
    {
        fuego.gameObject.SetActive(false);
        if(accion == "agua")
        {
            agua = true;
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                if(gameObject.transform.GetChild(i).tag == accion)
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);

        }
        else if(accion == "boil")
        {
            if (agua)
            {
                this.gameObject.transform.localPosition = new Vector3(-0.03341f, -0.01591f, 0.01261113f);
                fuego.gameObject.SetActive(true);
            }
            else this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);

        }
        else if (accion == "vaciar")
        {
            if (agua)
            {
                agua = false;
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if (gameObject.transform.GetChild(i).tag == "agua")
                    {
                        gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
            this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);
        }
       
    }
}
