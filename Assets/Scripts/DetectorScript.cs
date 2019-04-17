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
    //  Detected Particle Variables
    //
    Collider pCol;
    Vector3 pColPosition;
    ParticleScript pColScript;
    ParticleScript.ParticleType colliderParticleType;


    //
    //  Movement Vector
    //
    Vector3 vDirection;


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
        pCol = col;
        pColScript = pCol.GetComponent<ParticleScript>();

        pColPosition = pCol.transform.position;
        vDirection = (pColPosition - transform.position).normalized;


        if (pColScript != null)
        {
            colliderParticleType = pColScript.pType;

            BehaviorType1();
            BehaviorType2();
        }
    }


    //
    //  Behavior Type_1 - Detected Particle is TYPE_1
    //
    void BehaviorType1()
    {
        if (parentParticleType != ParticleScript.ParticleType.TYPE_1 && colliderParticleType == ParticleScript.ParticleType.TYPE_1)
        {
            parentRigidBody.AddForce(vDirection * 40);
        }
    }


    //
    //  Behavior Type_2 - Detected Particle is TYPE_2
    //
    void BehaviorType2()
    {
        if (parentParticleType != ParticleScript.ParticleType.TYPE_2 && colliderParticleType == ParticleScript.ParticleType.TYPE_2)
        {
            parentRigidBody.AddForce(vDirection * 40);
        }
    }
}
