using UnityEngine;

public class DetectorGreen : DetectorMAIN
{
    //
    //  OnTriggerStay Function
    //
    void OnTriggerStay(Collider col)
    {
        //  Checking if collider is a particle different from the parent
        if (col.GetComponent<ParticleScript>() != null && col.GetComponent<ParticleScript>().pType != ParticleScript.ParticleType.TYPE_2)
        {
            ParticleScript pColScript = col.GetComponent<ParticleScript>();

            //  Getting the position and type of the particle detected
            Vector3 pColPosition = col.transform.position;
            ParticleScript.ParticleType pColType = pColScript.pType;

            //  Applying physics behavior
            if (pColType == ParticleScript.ParticleType.TYPE_1)
            {
                RepulseParticle(pColPosition);
            }

            if (pColType == ParticleScript.ParticleType.TYPE_3)
            {
                AttractParticle(pColPosition);
            }
        }
    }
}