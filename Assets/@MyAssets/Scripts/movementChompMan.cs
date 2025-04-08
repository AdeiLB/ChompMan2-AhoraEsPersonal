using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementChompMan : Movement
{
    public override void move(int movement)
    {

         switch(movement)
        {
            case 1:
                nextObject = matrix.GetValue((int)position.x + 1, (int)position.y);

                break;

            case 2:
                nextObject = matrix.GetValue((int)position.x, (int)position.y + 1);

                break;

            case 3:
                nextObject = matrix.GetValue((int)position.x - 1, (int)position.y);

                break;

            case 4:
                nextObject = matrix.GetValue((int)position.x, (int)position.y - 1);

                break;
        }

    }


}
