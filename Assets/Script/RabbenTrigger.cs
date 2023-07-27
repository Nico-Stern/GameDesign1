using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbenTrigger : MonoBehaviour
{
    public GameObject Rabe;
    public bool isTriggeredOnce =false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredOnce)
        {
            isTriggeredOnce=true;
        }
    }
}
