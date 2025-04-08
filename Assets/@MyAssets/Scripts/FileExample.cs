using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileExample : MonoBehaviour
{
    string line;
    char[] matrixLine;
    [SerializeField] private string filePath = "\\Maps\\map1.txt";
    private int filas;
    private int columnas;
    private MapMatrix mapMatrix;
    List<string> lines = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
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
        mapMatrix = new MapMatrix(filas, columnas);

        for (int i = 0;i < filas; i++)
        {
            for (int  j = 0; j < columnas; j++)
            {
                mapMatrix[i, j] = Int32.Parse(lines[i][j].ToString());
            }
        }

        Debug.Log(mapMatrix);


    }
}
