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
    [SerializeField] private GameObject bolitaPrefab;

    [SerializeField] private GameObject chompMan;
    [SerializeField] private GameObject ghost;

    [SerializeField] private MapMatrix matriz;
    [SerializeField] private string filePath = "\\Maps\\map1.txt";
    [SerializeField] private List<GameObject> drawables = new List<GameObject>();

    private MapMatrix originalMap;

    private int numBolitas = 0;

    public MapMatrix Matriz { get => matriz; set => matriz = value; }

    // Start is called before the first frame update
    void Awake()
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

        Debug.Log(matriz.GetRowCount()+":"+matriz.GetColumnCount());

        originalMap = matriz.hardCopy();

        chompMan.SetActive(true);
        ghost.SetActive(true);


    }

    private void Update()
    {
        Draw();
        CheckBolitas();
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
            
            matrixLine = line.ToCharArray();
            columnas = matrixLine.Length;
            filas++;
            lines.Add(line);
            line = sr.ReadLine();
        }
        sr.Close();
        matriz = new MapMatrix(filas, columnas);

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                matriz[i, j] = Int32.Parse(lines[i][j].ToString());
            }
        }

    }

    //public void Draw()
    //{
    //    foreach (KeyValuePair<Movement, GameObject> pair in movables)
    //    {
    //        pair.Value.transform.position = new Vector2(initialPosition.x + pair.Key.Position.x * interval, initialPosition.y + pair.Key.Position.y * interval);
    //    }
    //}

    public void Draw()
    {
        //Debug.Log(matriz);
        numBolitas = 0;
        drawables.ForEach(d => Destroy(d));
        drawables = new List<GameObject>();
        for (int i = 0; i < matriz.GetRowCount(); i++)
        {
            for (int j = 0; j < matriz.GetColumnCount(); j++)
            {
                if (matriz[i, j] == 1)
                {
                    GameObject go = Instantiate(prefab, new Vector3(initialPosition.x + (j * interval), initialPosition.y + (i * interval), 0), Quaternion.identity);
                    drawables.Add(go);
                }
                else if (matriz[i, j] == 2)
                {
                    GameObject go = Instantiate(bolitaPrefab, new Vector3(initialPosition.x + (j * interval), initialPosition.y + (i * interval), 0), Quaternion.identity);
                    drawables.Add(go);
                    numBolitas++;
                }
                else if (matriz[i, j] == 5)
                {
                    chompMan.transform.position = new Vector3(initialPosition.x + (j * interval), initialPosition.y + (i * interval), 0);
                }
                else if (matriz[i, j] == 3)
                {
                    ghost.transform.position = new Vector3(initialPosition.x + (j * interval), initialPosition.y + (i * interval), 0);
                    if (ghost.GetComponent<MovementGhost>().IsOverPellet())
                    {
                        numBolitas++;
                    }
                }
            }
        }
    }

    public void CheckBolitas()
    {
        if(numBolitas <= 0)
        {
            AgentManager.instance.ChompManWin();
            Debug.Log("No hay mas volitas reset");
        }
    }

    public void Reset()
    {
        matriz = originalMap.hardCopy();
    }
}
