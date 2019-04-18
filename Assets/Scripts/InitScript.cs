using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour
{
    int totalRedParticles, totalGreenParticles, totalBlueParticles;

    [SerializeField] GameObject redParticle, greenParticle, blueParticle;
    [SerializeField] Slider redSlider, greenSlider, blueSlider;
    [SerializeField] Button resetButton;



    void Awake()
    {
        resetButton.onClick.AddListener(TaskOnClick);
        redSlider.onValueChanged.AddListener(delegate {SliderMethod();});
        greenSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
        blueSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
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

    void SliderMethod()
    {
        RemoveParticles();
        InitializeParticles();
    }

    void InitializeParticles()
    {
        totalRedParticles = (int)redSlider.value;
        totalGreenParticles = (int)greenSlider.value;
        totalBlueParticles = (int)blueSlider.value;

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
    }
}
