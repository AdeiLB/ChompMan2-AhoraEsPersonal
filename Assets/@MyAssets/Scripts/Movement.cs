using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected MapMatrix matrix;
    protected Vector2 position;
    protected int nextObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void move(int movement);
    



        public void movementCheck(int movement)
    {
        switch (movement)
        {
            case 0:
                break;
            case 1://arriba
                if (checkTile(matrix.GetValue((int)position.x + 1, (int)position.y)))
                    move(1);
                break;
            case 2://Derecha
                if(checkTile(matrix.GetValue((int)position.x , (int)position.y+1)))
                    move(2);
                break;
            case 3://Abajo
                if (checkTile(matrix.GetValue((int)position.x - 1, (int)position.y)))
                    move(3);
                break;
            case 4://Izquierda
                if (checkTile(matrix.GetValue((int)position.x, (int)position.y - 1)))
                    move(4);
                break;
        }

    }


    public bool checkTile(float tileNumber)
    {
        if(tileNumber == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }




}
