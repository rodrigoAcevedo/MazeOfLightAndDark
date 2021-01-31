using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapBehavior : MonoBehaviour
{
    public Sprite[] trapSprites;
    public float timeActived;
    public float timeDeactived;

    private float timerActivedReference;
    private float timerDeactivedReference;

    private bool isActived;
    // Start is called before the first frame update
    void Start()
    {
          timerActivedReference = timeActived;
          timerDeactivedReference = timeDeactived;
}

    // Update is called once per frame
    void Update()
    {
        TrapTimer();
    }

    private void TrapTimer()
    {
        if(isActived == false)
        {
            timeActived -= 0.1f;
            if (timeActived <= 0.0f)
            {
                timeActived = timerActivedReference;
                isActived = true;
                GetComponent<SpriteRenderer>().sprite = trapSprites[0];
            }
        }
        else
        {
            timeDeactived -= 0.1f;
            if (timeDeactived <= 0.0f)
            {
                timeDeactived = timerDeactivedReference;
                isActived = false;
                GetComponent<SpriteRenderer>().sprite = trapSprites[1];
            }
        }

    }

    public bool GetState()
    {
        return isActived;
    }
}
