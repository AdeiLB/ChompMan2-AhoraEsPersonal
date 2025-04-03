using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileExample : MonoBehaviour
{
    string line;
    char[] matrixLine;
    string filePath = "C:\\\\Iker\\Prueba.txt";
    int filas;
    int columnas;
    MapMatrix mapMatrix;
    List<string> lines = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader(filePath);
        line = sr.ReadLine();
        while (line != null)
        {
            Debug.Log(line);
            matrixLine = line.ToCharArray();
            columnas = matrixLine.Length;
            for(int i = 0; i < matrixLine.Length - 2; i++)
            {
                Debug.Log("Hola");
                filas += 1;
            }
            lines.Add(line);
            line = sr.ReadLine();
        }
        Debug.Log("Filas: " + filas + "; Columnas: " + columnas);
        mapMatrix = new MapMatrix(filas, columnas);
        sr.Close();

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
