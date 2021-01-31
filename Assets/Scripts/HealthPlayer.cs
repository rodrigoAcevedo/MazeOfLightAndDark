using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public HealthManager healthManager;
    public int life;
    public float invencibleTime;
    private float invencibleTimeReference;
    public NavigationManager navMng;

    private bool canGetHurt;
    void Start()
    {
        invencibleTimeReference = invencibleTime;
        canGetHurt = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetHearth();
        }
        canGetHurt = LifeCooldown();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "dangerous" && collision.gameObject.GetComponent<TrapBehavior>().GetState())
        {
            GetHearth();
        }
    }

    private void GetHearth()
    {
        if (canGetHurt)
        {
            life -= 1;
            healthManager.ChangeLifeIcon(life);
            canGetHurt = false;
            invencibleTime = invencibleTimeReference;
            if(life <= 0)
            {
                navMng.StartGame();
            }
        }
    }

    private bool LifeCooldown()
    {
        invencibleTime -= 0.1f;
        if(invencibleTime <= 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
