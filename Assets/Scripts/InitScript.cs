using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour
{
    [SerializeField] GameObject redParticle, greenParticle, blueParticle;
    [SerializeField] int totalRedParticles, totalGreenParticles, totalBlueParticles;
    [SerializeField] InputField inputRedParticles, inputGreenParticles, inputBlueParticles;

    [SerializeField] Button resetButton;

    void Awake()
    {
        resetButton.onClick.AddListener(TaskOnClick);
    }

    void Start()
    {
        InitializeParticles();
    }

    void TaskOnClick()
    {
        RemoveParticles();
        InitializeParticles();
    }

    void InitializeParticles()
    {
        ClampValues();

        for (int i = 0; i < totalRedParticles; i++)
        {
            GameObject newParticle = Instantiate(redParticle);
            newParticle.GetComponent<ParticleScript>().SetRandomDirection();
            newParticle.GetComponent<ParticleScript>().AddForce();
        }

        for (int j = 0; j < totalGreenParticles; j++)
        {
            GameObject newParticle = Instantiate(greenParticle);
            newParticle.GetComponent<ParticleScript>().SetRandomDirection();
            newParticle.GetComponent<ParticleScript>().AddForce();
        }

        for (int k = 0; k < totalBlueParticles; k++)
        {
            GameObject newParticle = Instantiate(blueParticle);
            newParticle.GetComponent<ParticleScript>().SetRandomDirection();
            newParticle.GetComponent<ParticleScript>().AddForce();
        }
    }

    void RemoveParticles()
    {
        GameObject[] oldParticles = GameObject.FindGameObjectsWithTag("Particles");

        foreach (GameObject particle in oldParticles)
        {
            Destroy(particle);
        }

        totalRedParticles = int.Parse(inputRedParticles.text);
        totalGreenParticles = int.Parse(inputGreenParticles.text);
        totalBlueParticles = int.Parse(inputBlueParticles.text);
    }

    void ClampValues()
    {
        totalRedParticles = Mathf.Clamp(totalRedParticles, 0, 15);
        totalGreenParticles = Mathf.Clamp(totalGreenParticles, 0, 15);
        totalBlueParticles = Mathf.Clamp(totalBlueParticles, 0, 15);
    }
}
