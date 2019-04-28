using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoCan : OB {

    public Dish dish;
    public override void doStuff(string accion)
    {

        if (accion == "plato")
        {
            dish.doStuff("dressing");

        }

    }
}
