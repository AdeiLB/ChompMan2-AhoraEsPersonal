using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    //-1 = pared 0=nada 
    [SerializeField] private int[][] matrix;
    private Vector2 position;
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
            case 1:
                //get de la casilla a la cual se quiere mover 
                //checkTile(matrix.GetValue([position.x - 1],[position.y-1]));
                break;
            case 2:
                position.y += 1;
                break;
            case 3:
                position.x += 1;
                break;
            case 4:
                position.y -= 1;
                break;
        }

    }


    public bool checkTile(float tileNumber)
    {
        if(tileNumber == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }




}
