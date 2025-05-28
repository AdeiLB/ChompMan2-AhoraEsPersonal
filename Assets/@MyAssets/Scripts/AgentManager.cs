using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField] private Agent chompManAgent;
    [SerializeField] private Agent ghostAgent;
    [SerializeField] private VisualizarMatriz visualizarMatriz;
    [SerializeField] private int stepsPerFrame;
    public static AgentManager instance;
    public bool SlowMode;
    private int counter = 0;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
        Academy.Instance.AutomaticSteppingEnabled = !SlowMode;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //EndEpisodeGlobal();
            OnEpisodeBeginGlobal();
        }

        if (SlowMode)
        {
            if (counter == stepsPerFrame)
            {
                visualizarMatriz.Draw();
                Academy.Instance.EnvironmentStep();
                counter = 0;
            }
            counter++;

        } else
        {
            visualizarMatriz.Draw();
        }
    }

    public void OnEpisodeBeginGlobal()
    {
        Debug.Log("Reinicio de episodio");
        visualizarMatriz.Reset();
    }

    public void EndEpisodeGlobal()
    {
        chompManAgent.EndEpisode();
        ghostAgent.EndEpisode();
    }

    public void ChompManWin()
    {
        Debug.Log("Victoria de Chomp-Man");
        chompManAgent.AddReward(10000);
        ghostAgent.AddReward(-100);
        EndEpisodeGlobal();
    }

    public void GhostWin()
    {
        Debug.Log("Victoria de Fantasma");
        ghostAgent.AddReward(1000);
        chompManAgent.AddReward(-100);
        EndEpisodeGlobal();
    }

    public int getStepsPerFrame()
    {
        return stepsPerFrame;
    }
}
