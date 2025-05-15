using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class GhostAgent : Agent
{
    [SerializeField] private Movement chompManMovement;
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
        float distancia = applyAStar(movement.Position, chompManMovement.Position);
        this.AddReward(-distancia * distancia * 0.01f);
        movement.MovementCheck(actions.DiscreteActions[0]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            discreteActions[0] = 0; // Move Up
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            discreteActions[0] = 2; // Move Down
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActions[0] = 3; // Move Left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            discreteActions[0] = 1; // Move Right
        }
    }

    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();
        movement.spawn();
    }

    public float calcularDistancia(Vector2 pos1, Vector2 pos2)
    {
        Vector2 vectorEntrePuntos = pos1 - pos2;

        return (float)Mathf.Sqrt(Mathf.Pow(vectorEntrePuntos.x, 2) + Mathf.Pow(vectorEntrePuntos.y, 2));
    }

    public float applyAStar(Vector2 origin, Vector2 destination)
    {

        var start = new AStar.Node((int)origin.x, (int)origin.y);
        var goal = new AStar.Node((int) destination.x, (int)destination.y);
        var path = AStar.FindPath(visualizarMatriz.Matriz, start, goal);

        if (path != null)
        {
            //Debug.Log("Path found:");
            //foreach (var node in path)
            //{
            //    Debug.Log($"({node.X}, {node.Y})");
            //}
            visualizarMatriz.VisualizarCamino(path);
            return path.Count;
        }
        else
        {
            Debug.Log("No path found.");
            return 1;
        }
    }
}
