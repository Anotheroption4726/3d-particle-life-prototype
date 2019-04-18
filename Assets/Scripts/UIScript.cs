using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button wallsDisplayButton;
    public MeshRenderer wallTopRenderer, wallBottomRenderer, wallSideRenderer_1, wallSideRenderer_2, wallSideRenderer_3, wallSideRenderer_4;

    private static bool wallsDisplay = false;

    // Start is called before the first frame update
    void Awake()
    {
        wallsDisplayButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (wallsDisplay)
        {
            wallTopRenderer.enabled = true;
            wallBottomRenderer.enabled = true;
            wallSideRenderer_1.enabled = true;
            wallSideRenderer_2.enabled = true;
            wallSideRenderer_3.enabled = true;
            wallSideRenderer_4.enabled = true;
        }
        else
        {
            wallTopRenderer.enabled = false;
            wallBottomRenderer.enabled = false;
            wallSideRenderer_1.enabled = false;
            wallSideRenderer_2.enabled = false;
            wallSideRenderer_3.enabled = false;
            wallSideRenderer_4.enabled = false;
        }
    }

    void TaskOnClick()
    {
        if (wallsDisplay)
        {
            wallsDisplay = false;
            // Debug.Log("Walls Off");
        }
        else
        {
            wallsDisplay = true;
            // Debug.Log("Walls On");
        }
    }
}
