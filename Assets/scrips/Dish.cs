using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : OB {

    public Dish()
    {

    }
    int numDressings = 0;
    bool hasContent = false;
    public override void doStuff(string accion)
    {
        //fuego.gameObject.SetActive(false);
            Debug.Log("HOLA");
        if (accion == "ollaCoocked")
        {
            hasContent = true;
            gameObject.transform.GetChild(numDressings).gameObject.SetActive(true);
            preview.gameObject.transform.GetChild(numDressings).gameObject.SetActive(true);
            sendText("Añade la salsa de tomate y habrás terminado.");
        }
        else if(accion == "dressing" && hasContent)
       {
            gameObject.transform.GetChild(numDressings).gameObject.SetActive(false);
            gameObject.transform.GetChild(numDressings +1).gameObject.SetActive(true);
            preview.gameObject.transform.GetChild(numDressings).gameObject.SetActive(false);
            preview.gameObject.transform.GetChild(numDressings+1).gameObject.SetActive(true);
            numDressings++;
            sendText("Muy bien!");
       }

    }
}
