using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementChompMan : Movement
{

    //TODO añadir mopvimiento con racciones totales EN LA MATRIZ
    public override void move(int movement)
    {
        Reaction(nextObject);
        switch (movement)
        {
            case 1:
                


                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;
        }

    }


    private void Reaction(Enum obj)
    {
        switch(obj)
        {
            case Casillas.Bolita:
                Debug.Log("tremenda comida de bola");
                break;

            case Casillas.Fantasma:
                Debug.Log("Españoles Chomp-man ha muerto");
                break;

        }
    }

    //TODO hacer metodo de muerte de chomp man(publico)


}
