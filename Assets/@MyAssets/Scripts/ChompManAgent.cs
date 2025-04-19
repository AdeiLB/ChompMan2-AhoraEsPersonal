using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class ChompManAgent : Agent
{

    [SerializeField] private Movement movement;

    public override void OnActionReceived(ActionBuffers actions)
    {
        movement.MovementCheck(actions.DiscreteActions[0]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.W))
        {
            discreteActions[0] = 1; // Move Up
        }
        else if (Input.GetKey(KeyCode.S))
        {
            discreteActions[0] = 3; // Move Down
        }
        else if (Input.GetKey(KeyCode.A))
        {
            discreteActions[0] = 4; // Move Left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            discreteActions[0] = 2; // Move Right
        }
        else
        {
            discreteActions[0] = 0; // No Action
        }
    }
}
