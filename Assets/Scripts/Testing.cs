using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    MinefieldGraph graph;
    // Start is called before the first frame update
    void Start()
    {
        graph = FindObjectOfType<PlaySpaceGenerator>().minefield;
        /*foreach(FieldNode field in graph.fields)
        {
            if(field != null)
            {
                Debug.Log(1);
            }
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(graph.Count + " " + graph.isGameWon);
        }
    }
}
