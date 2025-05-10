using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected VisualizarMatriz visualizarMatriz;

    [SerializeField] protected Vector2 position;
    [SerializeField] protected Vector2 originalPosition;
    protected Casillas nextObject;
    // Start is called before the first frame update

    public Vector2 Position { get => position; set => position = value; }

    public abstract void spawn();
    public abstract void Move(int movement);


    private void Start()
    {
        originalPosition = position;
        spawn();
        
    }

    public void MovementCheck(int movement)
    {
       switch (movement)
       {
            case 0:
                break;
            case 1://arriba
                if (CheckTile(visualizarMatriz.Matriz.GetValue((int)position.x + 1, (int)position.y)))
                    Move(1);
                break;
            case 2://Derecha
                if(CheckTile(visualizarMatriz.Matriz.GetValue((int)position.x , (int)position.y+1)))
                    Move(2);
                break;
            case 3://Abajo
                if (CheckTile(visualizarMatriz.Matriz.GetValue((int)position.x - 1, (int)position.y)))
                    Move(3);
                break;
            case 4://Izquierda
                if (CheckTile(visualizarMatriz.Matriz.GetValue((int)position.x, (int)position.y - 1)))
                    Move(4);
                break;
       }

    }


    public bool CheckTile(int tileNumber)
    {
     

        switch(tileNumber)
        {
            case 0:
                nextObject = Casillas.Vacio;
                return true;

            case 1:
                return false;

            case 2:
                nextObject = Casillas.Bolita;
                return true;

            case 3:
                nextObject = Casillas.Fantasma;
                return true;

            case 5:
                nextObject = Casillas.ChompMan;
                return true;

            default:
                return true;

            
            
        }
    }


}
