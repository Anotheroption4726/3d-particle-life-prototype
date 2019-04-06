using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private Rigidbody particleRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        particleRigidbody = GetComponent<Rigidbody>();
        // particleRigidbody.velocity = new Vector3(1, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}