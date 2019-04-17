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
        ParticleScript pColScript = col.GetComponent<ParticleScript>();

        if (pColScript != null)
        {
            Vector3 pColPosition = col.transform.position;
            ParticleScript.ParticleType colliderParticleType = pColScript.pType;

            BehaviorType1(colliderParticleType, pColPosition);
            BehaviorType2(colliderParticleType, pColPosition);
        }
    }


    //
    //  Behavior Type_1 - Detected Particle is TYPE_1
    //
    void BehaviorType1(ParticleScript.ParticleType cpType, Vector3 cpPosition)
    {
        Vector3 vDirection = (cpPosition - transform.position).normalized;

        if (parentParticleType != ParticleScript.ParticleType.TYPE_1 && cpType == ParticleScript.ParticleType.TYPE_1)
        {
            parentRigidBody.AddForce(vDirection * 40);
        }
    }


    //
    //  Behavior Type_2 - Detected Particle is TYPE_2
    //
    void BehaviorType2(ParticleScript.ParticleType cpType, Vector3 cpPosition)
    {
        Vector3 vDirection = (cpPosition - transform.position).normalized;

        if (parentParticleType != ParticleScript.ParticleType.TYPE_2 && cpType == ParticleScript.ParticleType.TYPE_2)
        {
            parentRigidBody.AddForce(vDirection * 40);
        }
    }
}
