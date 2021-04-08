using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldNode
{
    public GameObject block;
    public List<FieldNode> neighbors;
    private FieldBlock fieldBlock;

    public BlockType Type
    {
        get { return fieldBlock.Type; }
        set 
        { 
            fieldBlock.Type = value; 
            if(value == BlockType.Mine)
            {
                foreach(FieldNode neighbor in neighbors)
                {
                    if (neighbor.Type != BlockType.Mine) neighbor.Type = BlockType.Number;
                }
            }
        }
    }

    public int NearbyMineCount
    {
        get { return fieldBlock.NearbyMineCount; }
        set
        {
            fieldBlock.NearbyMineCount = value;
        }
    }

    public FieldNode(GameObject block)
    {
        this.block = block;
        neighbors = new List<FieldNode>();
        if (this.block.GetComponent<FieldBlock>() == null)
        {
            this.block.AddComponent<FieldBlock>();
        }
        fieldBlock = this.block.GetComponent<FieldBlock>();
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

    public bool AssignNumber()
    {
        if(Type != BlockType.Number)
        {
            Debug.LogWarning("This is not a number type block");
            return false;
        }
        else
        {
            foreach(FieldNode neighbor in neighbors)
            {
                if(neighbor.Type == BlockType.Mine)
                {
                    NearbyMineCount++;
                }
            }
            return true;
        }
    }

}
