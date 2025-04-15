using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChompMan : Movement
{
    //TODO añadir mopvimiento con racciones totales EN LA MATRIZ
    //Hacer movimineto de los fantasmas 
    public override void Move(int movement)
    {
        Reaction(nextObject);
        switch (movement)
        {
            case 1:
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.x += 1;
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 2:
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.y += 1;
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 3:
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.x -= 1;
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 4:
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.y -= 1;
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;
        }

    }


    private void Reaction(Enum obj)
    {
        switch(obj)
        {
            case Casillas.Bolita:
                //Debug.Log("tremenda comida de bola");
                break;

            case Casillas.Fantasma:
                death();
                break;

        }
    }

    //TODO hacer metodo de muerte de chomp man(publico)


    public void death()
    {
        Debug.Log("Españoles Chomp-man ha muerto");
    }

    public override void spawn()
    {
        matrix.SetValue(((int)position.x), ((int)position.y), ((int)Casillas.ChompMan));
    }
}
