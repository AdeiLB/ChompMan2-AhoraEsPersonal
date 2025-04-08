using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMatrix
{
    private int[][] matrix;

    /*
     * 0 = Vacío
     * 1 = Pared
     * 2 = Bolita
     * 3 = Fantasma
     * 4 = Never gonna give you up, never gonna let you down Never gonna run around and desert you Never gonna make you cry, never gonna say goodbye Never gonna tell a lie and hurt you
     * 5 = Chomp man
     * 
     */

    public MapMatrix(int rows, int columns)
    {
        matrix = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[columns];
        }
    }

    public MapMatrix(int rows, int columns, int defaultValue)
    {
        matrix = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                matrix[i][j] = defaultValue;
            }
        }
    }

    public int GetValue(int row, int column)
    {
        if (row < 0 || row >= matrix.Length || column < 0 || column >= matrix[0].Length)
        {
            throw new System.IndexOutOfRangeException("Index out of range");
        }
        return matrix[row][column];
    }

    public void SetValue(int row, int column, int value)
    {
        if (row < 0 || row >= matrix.Length || column < 0 || column >= matrix[0].Length)
        {
            throw new System.IndexOutOfRangeException("Index out of range");
        }
        matrix[row][column] = value;
    }

    public int GetRowCount()
    {
        return matrix.Length;
    }

    public int GetColumnCount()
    {
        return matrix[0].Length;
    }

    public MapMatrix GetInverted()
    {
        MapMatrix mapMatrix = new MapMatrix(GetRowCount(), GetColumnCount());
        for (int i = GetRowCount()-1; i >= 0; i--)
        {
            for (int j = 0; j < GetColumnCount(); j++)
            {
                mapMatrix[GetRowCount()-1-i, j] = matrix[i][j];
            }
        }
        return mapMatrix;
    }

    public int this[int row, int column]
    {
        get { return GetValue(row, column); }
        set { SetValue(row, column, value); }
    }

    public override string ToString()
    {
        string mapString = "";
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                mapString += matrix[i][j] + " ";
            }
            mapString += "\n";
        }
        return mapString;
    }
}
