using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    //
    //  Particle Type
    //
    public enum ParticleType
    {
        TYPE_1,
        TYPE_2,
        TYPE_3,
    };

    public ParticleType pType;


    //
    //  Display
    //
    [SerializeField] Material redMaterial, greenMaterial, blueMaterial;


    //
    // Physics
    //
    [SerializeField] int thrust = 4000;
    Rigidbody particleRigidbody;


    //
    //Cooldowns for user inputs
    //
    float m_NextSpaceTime;
    [SerializeField] float m_SpaceCoolDownDuration;








    //
    // Awake Function
    //
    void Awake()
    {
        particleRigidbody = GetComponent<Rigidbody>();

        if (pType == ParticleType.TYPE_1)
        {
            GetComponent<MeshRenderer>().material = redMaterial;
        }

        if (pType == ParticleType.TYPE_2)
        {
            GetComponent<MeshRenderer>().material = greenMaterial;
        }

        if (pType == ParticleType.TYPE_3)
        {
            GetComponent<MeshRenderer>().material = blueMaterial;
        }
    }


    //
    // Start Function
    //
    void Start()
    {
        m_NextSpaceTime = Time.time;
        Time.timeScale = 1f;
    }


    //
    // Update Function
    //
    void Update()
    {
        UserInputs();
    }


    //
    // Set Particle to a random direction
    //
    void SetRandomDirection()
    {
        transform.rotation = Quaternion.Euler(Random.value * 360, Random.value * 360, Random.value * 360);
    }


    //
    // Throw Particle Forward
    //
    void AddForce()
    {
        particleRigidbody.AddForce(particleRigidbody.transform.forward * thrust);
    }


    //
    // User Inputs
    //
    void UserInputs()
    {
        bool onSpace = Input.GetButton("Jump");

        if (onSpace && Time.time > m_NextSpaceTime)
        {
            SetRandomDirection();
            AddForce();
            m_NextSpaceTime = Time.time + m_SpaceCoolDownDuration;
        }
    }
}