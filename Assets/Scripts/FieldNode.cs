using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldNode
{
    public GameObject block;
    public List<FieldNode> neighbors;

    public FieldNode(GameObject block)
    {
        this.block = block;
        neighbors = new List<FieldNode>();
    }

    public bool AddNeighbour(FieldNode neighbor)
    {
        if (neighbor == null || neighbors.Contains(neighbor))
        {
            return false;
        }
        else
        {
            neighbors.Add(neighbor);
            neighbor.AddNeighbour(this);
            return true;
        }
    }

    public bool RemoveNeighbor(FieldNode neighbor)
    {
        return neighbors.Remove(neighbor);
    }

    public bool RemoveAllNeighbors()
    {
        for(int i = neighbors.Count - 1; i >= 0; i--)
        {
            neighbors[i].RemoveNeighbor(this);
            neighbors.RemoveAt(i);
        }
        return true;
    }

}
