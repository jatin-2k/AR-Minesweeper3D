using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBlock : MonoBehaviour
{
    [SerializeField]
    private BlockType type = BlockType.Empty;
    [SerializeField]
    private int nearbyMineCount = 0;

    public BlockType Type
    {
        get { return type; }
        set { type = value; }
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
