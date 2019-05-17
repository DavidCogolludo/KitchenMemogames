using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Olla : OB
{
    public Olla(){
        
    }
    public ColliderInfo colInfo;
    private void Start()
    {
        //colInfo = transform.Find("ColliderOlla").GetComponent<ColliderInfo>();
    }
    bool agua = false;
    bool boiling = false;
    bool spaguettis = false;
    bool coocked = false;
    bool hasContent = false;
    public float timeToBoil;

    public Thermometer thermometer;
    public Light fuego;
    public override void doStuff(string accion)
    {
       
        //Si la acción es agua se llena de agua
        if (accion == "agua")
        {
            sendAction(States.POTHASWATER);
           // sendText("¡Muy bien! Ahora pon a hervir el agua.");
            agua = true;
            setContent(accion, agua);
        }
        
        else if(accion == "boil") //Acción hervir 
        {
            if (agua && !coocked)
            {
                boiling = true;
                if (spaguettis)
                {
                    sendAction(States.BOILINGSPAGUETTI);
                    StartCoroutine(Boil());
                    thermometer.gameObject.SetActive(true);
                }
                else
                {
                    sendAction(States.WATERBOILING);
                }
                //SI hay agua se enciende el fuego
                this.gameObject.transform.localPosition = new Vector3(-0.03341f, -0.01591f, 0.01261113f);
                fuego.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);
                sendAction(States.POTEMPTY);
                
            }

        }
        else if (accion == "vaciar")
        {
            //Si hay agua se vacía
            if (agua)
            {
                boiling = false;
                Debug.Log(coocked);
                if(coocked) colInfo.accion = "ollaCoocked";
                fuego.gameObject.SetActive(false);
                thermometer.gameObject.SetActive(false);
                agua = false;
                setContent("agua", agua);
                setContent("particles", false);
                if (spaguettis)
                {
                    sendAction(States.SPAGUETTIREADY);
                    //sendText("Busca un plato y sirve los spaguettis");
                }
            }
            this.gameObject.transform.localPosition = new Vector3(-0.0323f, -0.0092f, 0.0125f);
        }
        else if (accion == "spaguetti")
        {
            if (boiling)
            {
                sendAction(States.BOILINGSPAGUETTI);
                StartCoroutine(Boil());
                thermometer.gameObject.SetActive(true);
            }
            spaguettis = true;
            setContent(accion, spaguettis);
        }
        else if (accion == "plato")
        {
            if(!agua && spaguettis&& coocked)
            {
                setContent("spaguettiCooked", false);
                setContent("particles", false);
                fuego.gameObject.SetActive(false);
                thermometer.gameObject.SetActive(false);
                coocked = false;
                spaguettis = false;
                colInfo.accion = "olla";
            }
        }
       
    }

    IEnumerator Boil()
    {
        yield return new WaitForSeconds(timeToBoil);
        if (spaguettis)
        {
            coocked = true;
            setContent("spaguetti", false);
            setContent("spaguettiCooked", true);
            setContent("particles", true);
            

        }

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
