using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    Transform parentParticleTransform;
    ParticleScript.ParticleType parentParticleType;
    Rigidbody parentRigidBody;



    void Awake()
    {
        parentParticleTransform = transform.parent;
        parentParticleType = parentParticleTransform.GetComponent<ParticleScript>().pType;
        parentRigidBody = parentParticleTransform.GetComponent<Rigidbody>();
    }


    void OnTriggerStay(Collider col)
    {
        ParticleScript.ParticleType colliderParticleType;
        ParticleScript pColScript = col.GetComponent<ParticleScript>();

        if (pColScript != null)
        {
            colliderParticleType = pColScript.pType;

            if (parentParticleType != ParticleScript.ParticleType.TYPE_2 && colliderParticleType == ParticleScript.ParticleType.TYPE_2)
            {
                // Debug.Log("Collision");
                parentParticleTransform.LookAt(col.transform);
                parentRigidBody.AddForce(parentRigidBody.transform.forward * 40);
            }

            if (parentParticleType != ParticleScript.ParticleType.TYPE_1 && colliderParticleType == ParticleScript.ParticleType.TYPE_1)
            {
                // Debug.Log("Collision");
                parentParticleTransform.LookAt(new Vector3(- col.transform.position.x, -col.transform.position.y, -col.transform.position.z));
                parentRigidBody.AddForce(parentRigidBody.transform.forward * 40);
            }
        }
    }
}
