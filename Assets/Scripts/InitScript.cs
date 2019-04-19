using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour
{
    int totalRedParticles, totalGreenParticles, totalBlueParticles, totalCyanParticles, totalPurpleParticles, totalYellowParticles;

    [SerializeField] GameObject redParticle, greenParticle, blueParticle, cyanParticle, purpleParticle, yellowParticle;
    [SerializeField] Slider redSlider, greenSlider, blueSlider, cyanSlider, purpleSlider, yellowSlider;
    [SerializeField] Button resetButton;



    void Awake()
    {
        resetButton.onClick.AddListener(TaskOnClick);

        redSlider.onValueChanged.AddListener(delegate {SliderMethod();});
        greenSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
        blueSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
        cyanSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
        purpleSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
        yellowSlider.onValueChanged.AddListener(delegate { SliderMethod(); });
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

        totalCyanParticles = (int)cyanSlider.value;
        totalPurpleParticles = (int)purpleSlider.value;
        totalYellowParticles = (int)yellowSlider.value;




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




        for (int i = 0; i < totalCyanParticles; i++)
        {
            GameObject newParticle = Instantiate(cyanParticle);
            newParticle.GetComponent<ParticleScript>().SetRandomDirection();
            newParticle.GetComponent<ParticleScript>().AddForce();
        }

        for (int j = 0; j < totalPurpleParticles; j++)
        {
            GameObject newParticle = Instantiate(purpleParticle);
            newParticle.GetComponent<ParticleScript>().SetRandomDirection();
            newParticle.GetComponent<ParticleScript>().AddForce();
        }

        for (int k = 0; k < totalYellowParticles; k++)
        {
            GameObject newParticle = Instantiate(yellowParticle);
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
