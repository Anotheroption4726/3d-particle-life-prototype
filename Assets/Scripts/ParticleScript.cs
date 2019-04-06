using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public int thrust = 4000;

    private Rigidbody particleRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        particleRigidbody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(Random.value*360, Random.value*360, Random.value*360);
        // particleRigidbody.AddForce(new Vector3(Random.value * thrust, Random.value * thrust, Random.value * thrust));

        particleRigidbody.AddForce(particleRigidbody.transform.up * thrust);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}