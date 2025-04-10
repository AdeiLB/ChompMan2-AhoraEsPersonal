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
        Reaction(nextObject);
        switch (movement)
        {
            case 1:
                matrix.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.x += 1;
                lastObject = matrix.GetValue((int)position.x, (int)position.y);
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;

            case 2:
                matrix.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.y += 1;
                lastObject = matrix.GetValue((int)position.x, (int)position.y);
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;

            case 3:
                matrix.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.x -= 1;
                lastObject = matrix.GetValue((int)position.x, (int)position.y);
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;

            case 4:
                matrix.SetValue((int)position.x, (int)position.y, lastObject);
                this.position.y -= 1;
                lastObject = matrix.GetValue((int)position.x, (int)position.y);
                matrix.SetValue((int)position.x, (int)position.y, ((int)Casillas.Fantasma));
                break;
        }
    }

    public override void spawn()
    {
        matrix.SetValue(((int)position.x), ((int)position.y), ((int)Casillas.Fantasma));
    }

    private void Reaction(Casillas nextObject)
    {
        if(nextObject == Casillas.ChompMan)
        {
            chompMan.GetComponent<MovementChompMan>().death();
        }
    }
}
