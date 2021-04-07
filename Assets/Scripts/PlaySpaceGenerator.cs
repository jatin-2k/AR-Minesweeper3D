﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaySpaceGenerator : MonoBehaviour
{
    #region Fields
    public GameObject blockPrefab;

    public int chunkSize = 50;
    public float noiseScale = 0.05f;
    [Range(0,1)]
    public float threshold = 0.5f;
    public int noiceOffset;
    public bool sphere = false;

    public MinefieldGraph minefield;
    #endregion

    private void Awake()
    {
        minefield = new MinefieldGraph(chunkSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GeneratePLaySpace();
        }
    }

    #region Methods
    public void GeneratePLaySpace()
    {
        noiseScale = Random.Range(0.01f, 0.5f);
        noiceOffset = Random.Range(0, 10);
        minefield.Clear(); // clear graph
        Generate();
    }

    private void Generate()
    {
        float startTime = Time.realtimeSinceStartup;

        #region Generate
        for (int x = 0; x < chunkSize; x++)
        {   for (int y = 0; y < chunkSize; y++)
            {   for (int z = 0; z < chunkSize; z++)
                {
                    float noiceValue = Perlin3D(noiceOffset + x * noiseScale, noiceOffset + y * noiseScale, noiceOffset + z * noiseScale);
                    if(noiceValue >= threshold)
                    {
                        float radius = chunkSize / 2;
                        if (sphere && Vector3.Distance(new Vector3(x, y, z), Vector3.one * radius) > radius)
                            continue;

                        minefield.Add(GameObject.Instantiate(blockPrefab, new Vector3(x,y,z),Quaternion.identity,gameObject.transform), new Vector3(x,y,z)); // add to graph
                    }
                }
            }
        }
        #endregion

        if(minefield.Count <= chunkSize * chunkSize * chunkSize / 4) // count number of nodes in graph
        {
            GeneratePLaySpace();
        }
        else
            Debug.Log("Loaded in: " + (Time.realtimeSinceStartup - startTime) + " Seconds. " + minefield.Count);
    }


    public static float Perlin3D(float x, float y, float z)
    {
        float ab = Mathf.PerlinNoise(x, y);
        float bc = Mathf.PerlinNoise(y, z);
        float ac = Mathf.PerlinNoise(x, z);

        float ba = Mathf.PerlinNoise(y, x);
        float cb = Mathf.PerlinNoise(z, y);
        float ca = Mathf.PerlinNoise(z, x);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / 6f;
    }
    #endregion
}
