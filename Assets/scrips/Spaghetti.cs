using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaghetti : OB
{
    public Spaghetti()
    {

    }

    public GameObject spaghettisCazuela;
    public override void doStuff(string accion)
    {
       if(accion == "Coloca")
       {
            spaghettisCazuela.SetActive(true);
       }

    }
}
