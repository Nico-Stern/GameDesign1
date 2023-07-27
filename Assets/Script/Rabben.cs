using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabben : MonoBehaviour
{
    public RabbenTrigger RTrigger;

    [SerializeField] int Speed;

    public float Timer;
    void Update()
    {
        if (RTrigger.isTriggeredOnce)
        {
            print(1);
            transform.position += new Vector3(0, 0, -3)  * Time.deltaTime*Speed;
            Timer = Timer - Time.deltaTime;
            if (Timer <= 0)
            {
                killyourself();
            }
        }
    }

    void killyourself()
    {
        gameObject.SetActive(false);
    }
}
