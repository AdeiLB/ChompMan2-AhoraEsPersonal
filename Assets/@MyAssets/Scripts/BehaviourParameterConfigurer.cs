using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Policies;
using UnityEngine;

[RequireComponent(typeof(BehaviorParameters))]
public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private BehaviorParameters behaviorParameters;
    [SerializeField] private VisualizarMatriz visualizarMatriz;
}
