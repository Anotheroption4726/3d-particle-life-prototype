using UnityEngine;

public abstract class DetectorMAIN : MonoBehaviour
{
    //
    //  Parent Particle RigidBody
    //
    Rigidbody pParRigidBody;


    //
    // Awake Function
    //
    public void Awake()
    {
        pParRigidBody = transform.parent.GetComponent<Rigidbody>();
    }


    //
    //  Attract Particle Behavior
    //
    public void AttractParticle(Vector3 cpPosition, float cpDistance)
    {
        Vector3 vDirection = (cpPosition - transform.position).normalized;
        pParRigidBody.AddForce(vDirection * (cpDistance * 10));
    }


    //
    //  Repulse Particle Behavior
    //
    public void RepulseParticle(Vector3 cpPosition, float cpDistance)
    {
        Vector3 vDirection = (transform.position - cpPosition).normalized;
        pParRigidBody.AddForce(vDirection * ((GetComponent<SphereCollider>().radius - cpDistance) * 10));
    }
}
