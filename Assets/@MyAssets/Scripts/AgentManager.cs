using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField] private Agent chompManAgent;
    [SerializeField] private Agent ghostAgent;
    [SerializeField] private VisualizarMatriz visualizarMatriz;
    public static AgentManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //EndEpisodeGlobal();
            OnEpisodeBeginGlobal();
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
        ghostAgent.AddReward(100);
        chompManAgent.AddReward(-100);
        EndEpisodeGlobal();
    }
}
