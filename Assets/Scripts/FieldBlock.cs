using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBlock : MonoBehaviour
{
    [SerializeField]
    private BlockType type = BlockType.Empty;
    [SerializeField]
    private int nearbyMineCount = 0;
    private Vector3Int positionInGraph;

    public BlockType Type
    {
        get { return type; }
        set { type = value; }
    }

    public Vector3Int PositionInGraph
    {
        get { return positionInGraph; }
        set
        {
            positionInGraph = value;
        }
    }

    public int NearbyMineCount
    {
        get { return nearbyMineCount; }
        set
        {
            if(type == BlockType.Number)
            {
                nearbyMineCount = value;
            }
            else
            {
                throw new System.InvalidOperationException("Cannot Set Nearby mine count number for block of type: " + type.ToString());
            }
        }
    } 

    

}
