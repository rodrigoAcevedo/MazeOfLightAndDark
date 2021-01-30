using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool key;
    public UnityEngine.UI.Image keyIcon;

    // Start is called before the first frame update
    void Start()
    {
        key = false;
        keyIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
