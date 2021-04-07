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

    //add edge

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
    #endregion
}