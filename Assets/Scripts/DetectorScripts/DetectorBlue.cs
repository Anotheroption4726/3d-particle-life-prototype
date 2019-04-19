using UnityEngine;

public class DetectorBlue : DetectorMAIN
{
    //
    //  OnTriggerStay Function
    //
    void OnTriggerStay(Collider col)
    {
        //  Checking if collider is a particle different from the parent
        if (col.GetComponent<ParticleScript>() != null)
        {
            ParticleScript pColScript = col.GetComponent<ParticleScript>();
            float distance = Vector3.Distance(transform.parent.transform.position, col.transform.position);

            //  Getting the position and type of the particle detected
            Vector3 pColPosition = col.transform.position;
            ParticleScript.ParticleType pColType = pColScript.pType;




            //  Applying physics behavior on same type
            if (pColType == ParticleScript.ParticleType.TYPE_3)
            {
                RepulseParticleRelative(pColPosition, distance);
            }




            //  Applying physics behavior on first batch
            if (pColType == ParticleScript.ParticleType.TYPE_1)
            {
                AttractParticleRelative(pColPosition, distance);
            }

            if (pColType == ParticleScript.ParticleType.TYPE_2)
            {
                RepulseParticleRelative(pColPosition, distance);
            }
        }
    }
}