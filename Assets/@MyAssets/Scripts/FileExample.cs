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

    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader(filePath);
        line = sr.ReadLine();
        while (line != null)
        {
            Debug.Log(line);
            matrixLine = line.ToCharArray();
            filas = matrixLine.Length;
            for(int i = 0; i < matrixLine.Length - 2; i++)
            {
                columnas += 1;
            }
            line = sr.ReadLine();
        }
        Debug.Log("Filas: " + filas + "; Columnas: " + columnas);
        sr.Close();
    }
}
