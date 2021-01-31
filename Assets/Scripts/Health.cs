using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
<<<<<<< Updated upstream
=======

    public int healthLevel;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
=======

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "dangerous") 
        {
            healthLevel -= 1;
        }
    }
>>>>>>> Stashed changes
}
