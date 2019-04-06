using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public int thrust = 2000;

    private Rigidbody particleRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        particleRigidbody = GetComponent<Rigidbody>();

        particleRigidbody.AddForce(new Vector3(Random.value * thrust, Random.value * thrust, Random.value * thrust));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}