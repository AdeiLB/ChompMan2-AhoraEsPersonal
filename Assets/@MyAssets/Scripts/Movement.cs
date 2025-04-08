using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected MapMatrix matrix;
    [SerializeField] protected Vector2 position;
    protected Casillas nextObject;
    // Start is called before the first frame update

    protected int nextObject;

    public Vector2 Position { get => position; set => position = value; }

    public abstract void move(int movement);


    public void movementCheck(int movement)
    {
       switch (movement)
       {
            case 0:
                break;
            case 1://arriba
                if (CheckTile(matrix.GetValue((int)position.x + 1, (int)position.y)))
                    move(1);
                break;
            case 2://Derecha
                if(CheckTile(matrix.GetValue((int)position.x , (int)position.y+1)))
                    move(2);
                break;
            case 3://Abajo
                if (CheckTile(matrix.GetValue((int)position.x - 1, (int)position.y)))
                    move(3);
                break;
            case 4://Izquierda
                if (CheckTile(matrix.GetValue((int)position.x, (int)position.y - 1)))
                    move(4);
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
