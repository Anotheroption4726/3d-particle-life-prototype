using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour
{

    ParticleScript.ParticleType particleColType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        /*
        if (col.GetComponent<ParticleScript>().particleType.Type2)
        {
            Debug.Log("Collision");
        }
        */

        ParticleScript pScript = col.GetComponent<ParticleScript>();

        if (pScript != null)
        {
            particleColType = pScript.pType;

            if (particleColType == ParticleScript.ParticleType.TYPE_2)
            {
                Debug.Log("Collision");
            }
        }
    }
}
