using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class GhostAgent : Agent
{
    [SerializeField] private Movement movement;
    [SerializeField] private VisualizarMatriz visualizarMatriz;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                if (i < visualizarMatriz.Matriz.GetRowCount() && j < visualizarMatriz.Matriz.GetColumnCount())
                {
                    sensor.AddObservation(visualizarMatriz.Matriz[i, j]);
                }
                else
                {
                    sensor.AddObservation(0);
                }
            }
        }

        base.CollectObservations(sensor);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        this.AddReward(-0.1f);
        movement.MovementCheck(actions.DiscreteActions[0]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            discreteActions[0] = 1; // Move Up
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            discreteActions[0] = 3; // Move Down
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActions[0] = 4; // Move Left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            discreteActions[0] = 2; // Move Right
        }
        else
        {
            discreteActions[0] = 0; // No Action
        }
    }

    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();
        movement.spawn();
    }
}
