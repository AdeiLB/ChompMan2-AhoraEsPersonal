using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementGhost : Movement
{
    private int lastObject = ((int)Casillas.Bolita);

    [SerializeField] private GameObject chompMan;

    public override void Move(int movement)
    {
        switch (movement)
        {
            case 1:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.x += 1;
                lastObject = visualizarMatriz.Matriz.GetValue((int)position.x, (int)position.y);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;

            case 2:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.y += 1;
                lastObject = visualizarMatriz.Matriz.GetValue((int)position.x, (int)position.y);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;

            case 3:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.x -= 1;
                lastObject = visualizarMatriz.Matriz.GetValue((int)position.x, (int)position.y);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;

            case 4:
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.y -= 1;
                lastObject = visualizarMatriz.Matriz.GetValue((int)position.x, (int)position.y);
                visualizarMatriz.Matriz.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;
        }
        Reaction(nextObject);
    }

    public override void spawn()
    {
        lastObject = ((int)Casillas.Bolita);
        do
        {
            position = position = new Vector2(UnityEngine.Random.Range(1, visualizarMatriz.Matriz.GetRowCount() - 2), UnityEngine.Random.Range(1, visualizarMatriz.Matriz.GetColumnCount() - 2));
        } while (visualizarMatriz.Matriz[(int)position.x, (int)position.y] != 2);
        visualizarMatriz.Matriz.SetValue(((int)position.x), ((int)position.y), ((int)Casillas.Fantasma));
    }

    private void Reaction(Casillas nextObject)
    {
        if(nextObject == Casillas.ChompMan)
        {
            chompMan.GetComponent<MovementChompMan>().death();
        }
    }

    public bool IsOverPellet()
    {
        return lastObject == ((int)Casillas.Bolita);
    }
}
