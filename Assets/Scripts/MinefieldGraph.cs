using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinefieldGraph
{
    List<GameObject> blocks = new List<GameObject>();

    public int Count
    {
        get
        {
            return blocks.Count;
        }
    }

    #region Methods
    public void Add(GameObject block, Vector3 pos)
    {
        blocks.Add(block); // add node
    }

    public void Add(GameObject block)
    {
        blocks.Add(block); // add node
    }

    public void Clear()
    {
        foreach(GameObject block in blocks)
        {
            Object.Destroy(block);
        }
        blocks.Clear();
    }
    #endregion
}
