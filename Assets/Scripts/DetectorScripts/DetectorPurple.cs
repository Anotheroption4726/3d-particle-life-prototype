using UnityEngine;

public class DetectorPurple : DetectorMAIN
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
            if (pColType == ParticleScript.ParticleType.TYPE_5)
            {
                RepulseParticleFixed(pColPosition, distance);
            }




            //  Applying physics behavior on second batch
            if (pColType == ParticleScript.ParticleType.TYPE_4)
            {
                RepulseParticleFixed(pColPosition, distance);
            }
        }
    }
}
