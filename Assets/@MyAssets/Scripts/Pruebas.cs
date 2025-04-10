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
            Debug.Log("D");
            Debug.Log(movement.getMatrix().ToString());
            movement.MovementCheck(2);
            visualizarMatriz.Draw();
            
        }else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            Debug.Log(movement.getMatrix().ToString());
            movement.MovementCheck(1);
            visualizarMatriz.Draw();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            Debug.Log(movement.getMatrix().ToString());
            movement.MovementCheck(3);
            visualizarMatriz.Draw();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            Debug.Log(movement.getMatrix().ToString());
            movement.MovementCheck(4);
            visualizarMatriz.Draw();
        }


    }
}
