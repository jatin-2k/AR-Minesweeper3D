using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinefieldGraph
{
    #region Fields
    FieldNode[,,] fields;
    int size;
    int countFields = 0;
    #endregion

    #region Properties
    public int Count
    {
        get
        {
            return countFields;
        }
    }
    #endregion

    #region Constructors
    public MinefieldGraph(int chunksize)
    {
        size = chunksize;
        fields = new FieldNode[size, size, size];
    }
    #endregion

    #region Methods
    public void Clear()
    {
        foreach (FieldNode field in fields)
        {
            if(field != null)
            {
                field.RemoveAllNeighbors();
                Object.Destroy(field.block);
            }
        }

        System.Array.Clear(fields, 0, fields.Length);
        countFields = 0;
    }

    public bool Add(GameObject block, Vector3 pos)
    {
        if (fields[(int)pos.x, (int)pos.y, (int)pos.z] != null) //----------------
        {
            return false;
        }
        else
        {
            fields[(int)pos.x, (int)pos.y, (int)pos.z] = new FieldNode(block);
            //local method
            bool inbound(float i)
            {
                return i < size && i >= 0;
            }
            //centerones
            if (inbound(pos.x + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y, (int)pos.z]);
            if (inbound(pos.x - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y, (int)pos.z]);
            if (inbound(pos.y + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y + 1, (int)pos.z]);
            if (inbound(pos.y - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y - 1, (int)pos.z]);
            if (inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y, (int)pos.z + 1]);
            if (inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y, (int)pos.z - 1]);
            //edgeones
            if (inbound(pos.x + 1) && inbound(pos.y + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y + 1, (int)pos.z]);
            if (inbound(pos.x + 1) && inbound(pos.y - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y - 1, (int)pos.z]);
            if (inbound(pos.x + 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y, (int)pos.z + 1]);
            if (inbound(pos.x + 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y, (int)pos.z - 1]);
            if (inbound(pos.x - 1) && inbound(pos.y + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y + 1, (int)pos.z]);
            if (inbound(pos.x - 1) && inbound(pos.y - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y - 1, (int)pos.z]);
            if (inbound(pos.x - 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y, (int)pos.z + 1]);
            if (inbound(pos.x - 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y, (int)pos.z - 1]);
            if (inbound(pos.y + 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y + 1, (int)pos.z + 1]);
            if (inbound(pos.y + 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y + 1, (int)pos.z - 1]);
            if (inbound(pos.y - 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y - 1, (int)pos.z + 1]);
            if (inbound(pos.y - 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x, (int)pos.y - 1, (int)pos.z - 1]);
            //cornerones
            if (inbound(pos.x + 1) && inbound(pos.y + 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y + 1, (int)pos.z + 1]);
            if (inbound(pos.x + 1) && inbound(pos.y + 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y + 1, (int)pos.z - 1]);
            if (inbound(pos.x + 1) && inbound(pos.y - 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y - 1, (int)pos.z + 1]);
            if (inbound(pos.x + 1) && inbound(pos.y - 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x + 1, (int)pos.y - 1, (int)pos.z - 1]);
            if (inbound(pos.x - 1) && inbound(pos.y + 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y + 1, (int)pos.z + 1]);
            if (inbound(pos.x - 1) && inbound(pos.y + 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y + 1, (int)pos.z - 1]);
            if (inbound(pos.x - 1) && inbound(pos.y - 1) && inbound(pos.z + 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y - 1, (int)pos.z + 1]);
            if (inbound(pos.x - 1) && inbound(pos.y - 1) && inbound(pos.z - 1)) fields[(int)pos.x, (int)pos.y, (int)pos.z].AddNeighbour(fields[(int)pos.x - 1, (int)pos.y - 1, (int)pos.z - 1]);

            countFields++;
            return true;
        }
    }

    public void Validate()
    {
        int removedNodes = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if(fields[i,j,k] != null && fields[i,j,k].neighbors.Count == 0)
                    {
                        RemoveNode(i, j, k);
                        removedNodes++;
                    }
                }
            }
        }
        Debug.Log("Removed: " + removedNodes + " Indivisual Fields.");
    }

    bool RemoveNode(int x, int y, int z)
    {
        if(fields[x,y,z] == null)
        {
            return false;
        }
        else
        {
            fields[x, y, z].RemoveAllNeighbors();
            Object.Destroy(fields[x, y, z].block);
            fields[x, y, z] = null;
            countFields--;
            return true;
        }
    }

    bool RemoveNode(FieldNode field)
    {
        if (field == null)
        {
            return false;
        }
        else
        {
            for(int i = 0; i<size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if(fields[i,j,k] == field)
                        {
                            fields[i, j, k].RemoveAllNeighbors();
                            Object.Destroy(fields[i,j,k].block);
                            fields[i, j, k] = null;
                        }
                    }
                }
            }
            countFields--;
            return true;
        }
    }

    public void SetMines(int numberOfMines)
    {
        for(int i = numberOfMines; i>0; )
        {
            if(SetMineAt(Random.Range(0, size), Random.Range(0, size), Random.Range(0, size)))
            {
                i--;
            }
        }
        Debug.Log("Mines in Place: " + numberOfMines);
    }

    private bool SetMineAt(int x, int y, int z)
    {
        if(fields[x,y,z] == null || fields[x,y,z].Type == BlockType.Mine)
        {
            return false;
        }
        else
        {
            fields[x, y, z].Type = BlockType.Mine;

            if(GameSettings.ShowMines == true)
            fields[x, y, z].block.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/MineTesting_Mat");

            return true;
        }
    }

    public void SetNumberFields()
    {
        foreach(FieldNode field in fields)
        {
            if(field != null && field.Type == BlockType.Number)
            {
                field.AssignNumber();
            }
        }
    }

    public void ShowMines()
    {
        if (GameSettings.ShowMines == true)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if(fields[i, j, k] != null && fields[i, j, k].Type == BlockType.Mine)
                        fields[i, j, k].block.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/MineTesting_Mat");
                    }
                }
            }
        }
    }

    public void HideMines()
    {
        if (GameSettings.ShowMines == false)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (fields[i, j, k] != null)
                            fields[i, j, k].block.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/TileBox_Mat");
                    }
                }
            }
        }
    }
    #endregion
}