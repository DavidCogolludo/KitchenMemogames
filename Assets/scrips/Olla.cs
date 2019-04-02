using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olla : OB
{
    public Olla(){
       
    }
    bool agua = false;
    bool spaguettis = false;
    bool hasContent = false;
  
    public Light fuego; 

    public override void doStuff(string accion)
    {
        fuego.gameObject.SetActive(false);
        //Si la acción es agua se llena de agua
        if(accion == "agua")
        {   
            
            agua = true;
            setContent(accion, agua);
        }
        else if(accion == "boil") //Acción hervir 
        {
            if (agua)
            {
                //SI hay agua se enciende el fuego
                this.gameObject.transform.localPosition = new Vector3(-0.03341f, -0.01591f, 0.01261113f);
                fuego.gameObject.SetActive(true);
            }
            else this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);

        }
        else if (accion == "vaciar")
        {
            //Si hay agua se vacía
            if (agua)
            {
                agua = false;
                setContent(accion, agua);
            }
            this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);
        }
        else if (accion == "spaguetti")
        {
           
            spaguettis = true;
            setContent(accion, spaguettis);
        }
        /*else if (accion == "plato")
        {
            if (hasContent)
            {
                contenido[(int)content.SPAGUETTIS].gameObject.SetActive(true);
            }
        }*/
       
    }

    private void setContent(string content, bool state)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == content)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(state);
            }
        }
        for (int i = 0; i < preview.gameObject.transform.childCount; i++)
        {
            if (preview.gameObject.transform.GetChild(i).tag == content)
            {
                preview.gameObject.transform.GetChild(i).gameObject.SetActive(state);
            }
        }
    }
}
