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
    ParticleScript pColScript;
    ParticleScript.ParticleType colliderParticleType;


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

        if (pColScript != null)
        {
            colliderParticleType = pColScript.pType;
            BehaviorType1();
            BehaviorType2();

            //BehaviorType1_LookAt();
            //BehaviorType2_LookAt();
        }
    }


    //
    //  Behavior Type_1 - Detected Particle is TYPE_1
    //
    void BehaviorType1()
    {
        if (parentParticleType != ParticleScript.ParticleType.TYPE_1 && colliderParticleType == ParticleScript.ParticleType.TYPE_1)
        {

        }
    }


    //
    //  Behavior Type_2 - Detected Particle is TYPE_2
    //
    void BehaviorType2()
    {
        if (parentParticleType != ParticleScript.ParticleType.TYPE_2 && colliderParticleType == ParticleScript.ParticleType.TYPE_2)
        {

        }
    }


    //
    //  Behavior Type_1 (Using LookAt) - Detected Particle is TYPE_1
    //
    void BehaviorType1_LookAt()
    {
        if (parentParticleType != ParticleScript.ParticleType.TYPE_1 && colliderParticleType == ParticleScript.ParticleType.TYPE_1)
        {
            // Debug.Log("Collision");
            parentParticleTransform.LookAt(pCol.transform);
            // parentParticleTransform.LookAt(new Vector3(- col.transform.position.x, -col.transform.position.y, -col.transform.position.z));
            parentRigidBody.AddForce(parentRigidBody.transform.forward * 40);
        }
    }


    //
    //  Behavior Type_2 (Using LookAt)- Detected Particle is TYPE_2
    //
    void BehaviorType2_LookAt()
    {
        if (parentParticleType != ParticleScript.ParticleType.TYPE_2 && colliderParticleType == ParticleScript.ParticleType.TYPE_2)
        {
            // Debug.Log("Collision");
            parentParticleTransform.LookAt(pCol.transform);
            parentRigidBody.AddForce(parentRigidBody.transform.forward * 40);
        }
    }
}
