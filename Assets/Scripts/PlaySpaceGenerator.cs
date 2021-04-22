using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaySpaceGenerator : MonoBehaviour
{
    #region Fields
    public GameObject blockPrefab;
    public GameObject MinePrefab;
    public GameObject NumberPrefab;
    public GameObject Offset;

    public int chunkSize = 50;
    [Range(0,100)]
    public int percentageOfMines = 7;
    public float noiseScale = 0.05f;
    [Range(0,1)]
    public float threshold = 0.5f;
    public int noiceOffset;
    public bool sphere = false;

    public MinefieldGraph minefield;
    #endregion

    private void Awake()
    {
        minefield = new MinefieldGraph(chunkSize, this);
        if(Offset == null) { Offset = this.gameObject; }
    }


    public void GeneratePlaySpace()
    {
        BegainGeneration();
        ValidatePlaySpace();
        SetMinesInPlaySpace();
    }

    public void ToggleShowMines()
    {
        GameSettings.ShowMines = !GameSettings.ShowMines;
    }

    #region Generation Of Space
    public void BegainGeneration()
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

                        minefield.Add(GameObject.Instantiate(blockPrefab, transform.TransformPoint(Offset.transform.localPosition + new Vector3(x, y, z)) ,Offset.transform.rotation,gameObject.transform), new Vector3(x,y,z)); // add to graph
                    }
                }
            }
        }
        #endregion

        if(minefield.Count <= chunkSize * chunkSize * chunkSize / 4) // count number of nodes in graph
        {
            BegainGeneration();
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

    #region After Generation
    void ValidatePlaySpace()
    {
        minefield.Validate();
    }

    void SetMinesInPlaySpace()
    {
        minefield.SetMines(percentageOfMines * minefield.Count / 100);
        minefield.SetNumberFields();
    }
    #endregion
}
