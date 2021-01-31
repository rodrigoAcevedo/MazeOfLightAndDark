using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool key1;
    public bool key2;
    public bool key3;
    public bool diamond;
    public UnityEngine.UI.Image key1Icon;
    public UnityEngine.UI.Image key2Icon;
    public UnityEngine.UI.Image key3Icon;
    public UnityEngine.UI.Image diamongIcon;


    // Start is called before the first frame update
    void Start()
    {
        key1 = false;
        key2 = false;
        key3 = false;
        diamond = false;
        key1Icon.enabled = false;
        key2Icon.enabled = false;
        key3Icon.enabled = false;
        diamongIcon.enabled = false;
    }

    public bool HasKey(Key keyId)
    {
        switch(keyId)
        {
            case Key.Key1:
                return key1;
            case Key.Key2:
                return key2;
            case Key.Key3:
                return key3;
            case Key.Free:
                return true;
            default:
                return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Key1")
        {
            key1 = true;
            key1Icon.enabled = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Key2")
        {
            key2 = true;
            key2Icon.enabled = true;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.name == "Key3")
        {
            key3 = true;
            key3Icon.enabled = true;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.name == "Diamond")
        {
            diamond = true;
            diamongIcon.enabled = true;
            Destroy(collision.gameObject);

        }
    }
}
