using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<HealthComponent>()?.RegisterHealthEvent(OnHealthEnded);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHealthEnded()
    {
        GetComponent<HealthComponent>()?.UnregisterHealthEvent(OnHealthEnded);
        GetComponent<Animator>().SetTrigger(AnimationConstants.CubeDestroy);
    }
}
