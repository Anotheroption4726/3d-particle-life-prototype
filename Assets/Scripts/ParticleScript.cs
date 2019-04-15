using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] string particleType;


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

    float m_NextFire1Time;
    [SerializeField] float m_Fire1CoolDownDuration;








    //
    // Awake Function
    //
    private void Awake()
    {
        particleRigidbody = GetComponent<Rigidbody>();
    }


    //
    // Start Function
    //
    void Start()
    {
        m_NextSpaceTime = Time.time;
        m_NextFire1Time = Time.time;
        Time.timeScale = 0.1f;
    }


    //
    // Update Function
    //
    private void Update()
    {
        UserInputs();
    }


    //
    // FixedUpdate Function
    //
    void FixedUpdate()
    {

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
    private void UserInputs()
    {

        //
        // Setting up inputs
        //
        bool onSpace = Input.GetButton("Jump");
        bool onFire1 = Input.GetButton("Fire1");

        //
        // Space
        //
        if (onSpace && Time.time > m_SpaceCoolDownDuration)
        {
            AddForce();
            m_NextSpaceTime = Time.time + m_SpaceCoolDownDuration;
        }

        //
        // Left Mouse Click
        //
        if (onFire1 && Time.time > m_Fire1CoolDownDuration)
        {
            SetRandomDirection();
            m_NextFire1Time = Time.time + m_Fire1CoolDownDuration;
        }
    }
}