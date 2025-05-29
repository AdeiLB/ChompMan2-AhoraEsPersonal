using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class MovementChompMan : Movement
{

    [SerializeField] private Agent chompManAgent;

    private int combo = 0;

    public override void Move(int movement)
    {
        switch (movement)
        {
            case 1:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.x += 1;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 2:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.y += 1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 3:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.x -= 1;
                transform.rotation = Quaternion.Euler(0, 0, 270);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;

            case 4:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Vacio));
                this.position.y -= 1;
                transform.rotation = Quaternion.Euler(0, 0, 180);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.ChompMan));
                break;
        }
        Reaction(nextObject);

    }


    private void Reaction(Enum obj)
    {
        //Debug.Log("Combo: " + combo);
        switch (obj)
        {
            case Casillas.Bolita:
                combo++;
                //Debug.Log("tremenda comida de bola");
                chompManAgent.AddReward(1 * combo);
                break;

            case Casillas.Fantasma:
                death();
                break;

            default:
                combo = 0;
                break;

        }
    }



    public void death()
    {
        AgentManager.instance.GhostWin();
        //Debug.Log("Españoles Chomp-man ha muerto");
    }

    public override void spawn()
    {
        do
        {
            position = position = new Vector2(UnityEngine.Random.Range(1, visualizarMatriz.Matriz.GetRowCount() - 2), UnityEngine.Random.Range(1, visualizarMatriz.Matriz.GetColumnCount() - 2));
        } while (visualizarMatriz.Matriz[(int)position.x, (int)position.y] != 2);
        //Debug.Log(matrix);
        visualizarMatriz.Matriz.SetValue(((int)position.x), ((int)position.y), ((int)Casillas.ChompMan));
    }

    
}
