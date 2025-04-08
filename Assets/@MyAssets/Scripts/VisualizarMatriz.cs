using Google.Protobuf.Collections;
using System;
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
    [SerializeField] private string filePath = "\\Maps\\map1.txt";

    // Start is called before the first frame update
    void Start()
    {
        //matriz = new MapMatrix(3, 3, 0);
        //matriz[0, 0] = 1;
        //matriz[0, 1] = 1;
        //matriz[0, 2] = 1;
        //Debug.Log(matriz);
        //Debug.Log(matriz.GetRowCount());
        //Debug.Log(matriz.GetColumnCount());

        ReadFile();

        matriz = matriz.GetInverted();

        for (int i = 0; i < matriz.GetRowCount(); i++)
        {
            for (int j = 0; j < matriz.GetColumnCount(); j++)
            {
                if (matriz[i,j] == 1)
                {
                    GameObject go = Instantiate(prefab, new Vector3(initialPosition.x + (j * interval), initialPosition.y + (i * interval), 0), Quaternion.identity);

                }
            }
        }
    }

    private void ReadFile()
    {
        string line;
        char[] matrixLine;
        int filas = 0;
        int columnas = 0;
        List<string> lines = new List<string>();

        StreamReader sr = new StreamReader(Application.dataPath + filePath);
        line = sr.ReadLine();
        while (line != null)
        {
            Debug.Log(line);
            matrixLine = line.ToCharArray();
            columnas = matrixLine.Length;
            filas++;
            lines.Add(line);
            line = sr.ReadLine();
        }
        sr.Close();
        Debug.Log("Filas: " + filas + "; Columnas: " + columnas);
        matriz = new MapMatrix(filas, columnas);

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = Int32.Parse(lines[i][j].ToString());
            }
        }

        Debug.Log(matriz);
    }
}
