using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    public UnityEngine.UI.Text bubbleText;
    // Start is called before the first frame update
    
    public void SetNumber(int i)
    {
        bubbleText.text = i.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
