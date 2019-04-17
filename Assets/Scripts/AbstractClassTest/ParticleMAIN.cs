using UnityEngine;

public abstract class ParticleMAIN : MonoBehaviour
{
    // PLACE THIS SCRIPT ON A DETECTOR?

    //
    //  Display
    //
    [SerializeField] Material particleTexture;


    //
    // Physics
    //
    Rigidbody particleRigidbody;
    [SerializeField] int forceIntensity = 4000;
    GameObject detector;


    //
    // Awake Function
    //
    void Awake()
    {
        particleRigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material = particleTexture;
    }
}
