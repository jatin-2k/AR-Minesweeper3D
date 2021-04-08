using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    MinefieldGraph graph;
    // Start is called before the first frame update
    void Start()
    {
        graph = new MinefieldGraph(3);
        graph.Add(new GameObject("object to test"), new Vector3(1, 1, 1));
        graph.Validate();
        Debug.Log(graph.Count + " ");
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
            Debug.Log(this.transform.position);
        }
    }
}
