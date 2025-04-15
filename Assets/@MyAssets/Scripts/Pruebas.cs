using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pruebas : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private VisualizarMatriz visualizarMatriz;

    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.MovementCheck(2);
            visualizarMatriz.Draw();
            
        }else if (Input.GetKeyDown(KeyCode.W))
        {
            
            movement.MovementCheck(1);
            visualizarMatriz.Draw();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            
            movement.MovementCheck(3);
            visualizarMatriz.Draw();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
        
            movement.MovementCheck(4);
            visualizarMatriz.Draw();
        }


    }
}
