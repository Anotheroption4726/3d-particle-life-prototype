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
        TYPE_4,
        TYPE_5,
        TYPE_6,
    };

    public ParticleType pType;


    //
    //  Display
    //
    [SerializeField] Material redMaterial, greenMaterial, blueMaterial, cyanMaterial, purpleMaterial, yellowMaterial;


    //
    // Physics
    //
    [SerializeField] int spaceForce = 4000;
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

        if (pType == ParticleType.TYPE_4)
        {
            GetComponent<MeshRenderer>().material = cyanMaterial;
        }

        if (pType == ParticleType.TYPE_5)
        {
            GetComponent<MeshRenderer>().material = purpleMaterial;
        }

        if (pType == ParticleType.TYPE_6)
        {
            GetComponent<MeshRenderer>().material = yellowMaterial;
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
    public void SetRandomDirection()
    {
        transform.rotation = Quaternion.Euler(Random.value * 360, Random.value * 360, Random.value * 360);
    }


    //
    // Throw Particle Forward
    //
    public void AddForce()
    {
        particleRigidbody.AddForce(particleRigidbody.transform.forward * spaceForce);
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