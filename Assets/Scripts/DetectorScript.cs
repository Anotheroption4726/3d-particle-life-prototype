using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    //
    //  Parent Particle Variables
    //
    Transform parentParticleTransform;
    ParticleScript.ParticleType parentParticleType;
    Rigidbody parentRigidBody;


    //
    // Awake Function
    //
    void Awake()
    {
        parentParticleTransform = transform.parent;
        parentParticleType = parentParticleTransform.GetComponent<ParticleScript>().pType;
        parentRigidBody = parentParticleTransform.GetComponent<Rigidbody>();
    }


    //
    //  OnTriggerStay Function
    //
    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<ParticleScript>() != null && parentParticleType != col.GetComponent<ParticleScript>().pType)
        {
            ParticleScript pColScript = col.GetComponent<ParticleScript>();
            Vector3 pColPosition = col.transform.position;
            ParticleScript.ParticleType pColType = pColScript.pType;

            if (parentParticleType == ParticleScript.ParticleType.TYPE_1)
            {
                if (pColType == ParticleScript.ParticleType.TYPE_2)
                {
                    AttractParticle(pColPosition);
                }

                if (pColType == ParticleScript.ParticleType.TYPE_3)
                {
                    RepulseParticle(pColPosition);
                }
            }

            if (parentParticleType == ParticleScript.ParticleType.TYPE_2)
            {
                if (pColType == ParticleScript.ParticleType.TYPE_1)
                {
                    RepulseParticle(pColPosition);
                }

                if (pColType == ParticleScript.ParticleType.TYPE_3)
                {
                    AttractParticle(pColPosition);
                }
            }

            if (parentParticleType == ParticleScript.ParticleType.TYPE_3)
            {
                if (pColType == ParticleScript.ParticleType.TYPE_1)
                {
                    AttractParticle(pColPosition);
                }

                if (pColType == ParticleScript.ParticleType.TYPE_2)
                {
                    RepulseParticle(pColPosition);
                }
            }
        }
    }


    //
    //  Attract Particle Behavior
    //
    void AttractParticle(Vector3 cpPosition)
    {
        Vector3 vDirection = (cpPosition - transform.position).normalized;
        parentRigidBody.AddForce(vDirection * 40);
    }


    //
    //  Repulse Particle Behavior
    //
    void RepulseParticle(Vector3 cpPosition)
    {
        Vector3 vDirection = (transform.position - cpPosition).normalized;
        parentRigidBody.AddForce(vDirection * 40);
    }
}
