using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class MovementChompMan : Movement
{

    [SerializeField] private Agent chompManAgent;

    public override void Move(int movement)
    {
        
        switch (movement)
        {
            case 1:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.x += 1;
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 2:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.y += 1;
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 3:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.x -= 1;
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 4:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.y -= 1;
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;
        }
        Reaction(nextObject);

    }


    private void Reaction(Enum obj)
    {
        switch(obj)
        {
            case Casillas.Bolita:
                //Debug.Log("tremenda comida de bola");
                chompManAgent.AddReward(1);
                break;

            case Casillas.Fantasma:
                death();
                break;

        }
    }



    public void death()
    {
        AgentManager.instance.GhostWin();
        Debug.Log("Españoles Chomp-man ha muerto");
    }

    public override void spawn()
    {
        position = originalPosition;
        //Debug.Log(matrix);
        visualizarMatriz.Matriz.SetValue(((int)position.x), ((int)position.y), ((int)Casillas.ChompMan));
    }
}
