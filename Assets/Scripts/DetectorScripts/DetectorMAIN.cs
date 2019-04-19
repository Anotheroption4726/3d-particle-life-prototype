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
    //  Attract Particle Behavior - Relative
    //
    public void AttractParticleRelative(Vector3 cpPosition, float cpDistance)
    {
        Vector3 vDirection = (cpPosition - transform.position).normalized;
        pParRigidBody.AddForce(vDirection * (cpDistance * 10));
    }


    //
    //  Repulse Particle Behavior - Relative
    //
    public void RepulseParticleRelative(Vector3 cpPosition, float cpDistance)
    {
        Vector3 vDirection = (transform.position - cpPosition).normalized;
        pParRigidBody.AddForce(vDirection * ((GetComponent<SphereCollider>().radius - cpDistance) * 10));
    }


    //
    //  Attract Particle Behavior - Fixed
    //
    public void AttractParticleFixed(Vector3 cpPosition, float cpDistance)
    {
        Vector3 vDirection = (cpPosition - transform.position).normalized;
        pParRigidBody.AddForce(vDirection * 40);
    }


    //
    //  Repulse Particle Behavior - Fixed
    //
    public void RepulseParticleFixed(Vector3 cpPosition, float cpDistance)
    {
        Vector3 vDirection = (transform.position - cpPosition).normalized;
        pParRigidBody.AddForce(vDirection * 40);
    }
}