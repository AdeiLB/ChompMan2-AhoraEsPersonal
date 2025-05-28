using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class ChompManAgent : Agent
{

    [SerializeField] private Movement movement;
    [SerializeField] private VisualizarMatriz visualizarMatriz;


    public float cummulativePenalization = 0;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        this.AddReward(-0.1f);
        Debug.Log(actions.DiscreteActions[0]);
        movement.MovementCheck(actions.DiscreteActions[0]);
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
                } else
                {
                    sensor.AddObservation(0);
                }
            }
        }

        base.CollectObservations(sensor);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.W))
        {
            discreteActions[0] = 0; // Move Up
        }
        else if (Input.GetKey(KeyCode.S))
        {
            discreteActions[0] = 2; // Move Down
        }
        else if (Input.GetKey(KeyCode.A))
        {
            discreteActions[0] = 3; // Move Left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            discreteActions[0] = 1; // Move Right
        }
    }

    public override void OnEpisodeBegin()
    {
        //Debug.Log("hola");
        base.OnEpisodeBegin();
        AgentManager.instance.OnEpisodeBeginGlobal();
        movement.spawn();
    }
}
