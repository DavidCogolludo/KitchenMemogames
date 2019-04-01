using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaghetti : OB
{
    public Spaghetti()
    {

    }

    public Olla olla;
    public override void doStuff(string accion)
    {
       if(accion == "Coloca")
       {
            olla.doStuff("spaguettis");
           
       }

    }
}
