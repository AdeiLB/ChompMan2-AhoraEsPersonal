using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VisualizarMatriz : MonoBehaviour
{
    [SerializeField] private Vector2 initialPosition;
    [SerializeField] private float interval;
    [SerializeField] private GameObject prefab;
    [SerializeField] private MapMatrix matriz;

    // Start is called before the first frame update
    void Start()
    {
        matriz = new MapMatrix(3, 3, 0);
        matriz[0, 0] = -1;
        matriz[0, 1] = -1;
        matriz[0, 2] = -1;
        Debug.Log(matriz);
        Debug.Log(matriz.GetRowCount());
        Debug.Log(matriz.GetColumnCount());

        for (int i = 0; i < matriz.GetRowCount(); i++)
        {
            for (int j = 0; j < matriz.GetColumnCount(); j++)
            {
                if (matriz[i,j] == -1)
                {
                    GameObject go = Instantiate(prefab, new Vector3(initialPosition.x + (j * interval), initialPosition.y + (i * interval), 0), Quaternion.identity);
                }
            }
        }
    }
}
