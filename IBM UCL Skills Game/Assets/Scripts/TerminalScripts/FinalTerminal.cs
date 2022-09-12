using UnityEngine;

/*
REFERENCES:
Unity 5.6 Tutorial | Distance Between Objects (Vector3) (Youtube/BeepBoopIndie):
https://www.youtube.com/watch?v=OMPV-duv25Q
Renderer.materials (Unity Documentation):
https://docs.unity3d.com/ScriptReference/Renderer-materials.html

*/

public class FinalTerminal : MonoBehaviour
{
    public GameObject player;
    public AudioSource buttonSelectedSFX;
    private float distance;
    private float range = 2.5f;
    public bool isInteracting = false;
    public bool inRange = false;
    public GameObject pauseMenu;

    public GameObject terminalInterface;
    public GameObject redLight;
    public GameObject normalLight;
    public GameObject ejectedSentinels;

    Renderer rend;
    // Material array for monitors:
    public Material[] optionmaterials;
    // Copy of currently used materials:
    public Material[] materials;
    public int x;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        // Load materials array of terminal game object into temporary array:
        materials = rend.materials;
        RenderTerminalOff();
    }

    void Update()
    {
        // Compute distance betweene player and terminal object:
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < range)
        {
            RenderTerminalOn();
            inRange = true;
        }
        else
        {
            RenderTerminalOff();
            inRange = false;
        }

        // Assign updated materials array to current materials array for terminal game object:
        rend.materials = materials;

        if (inRange && Input.GetKeyDown(KeyCode.E) && !isInteracting && pauseMenu.activeSelf == false)
        {
            // Open terminal interface:
            OpenTerminal();
            isInteracting = true;
            // Disable player movement when interacting with terminal:
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else if (inRange && Input.GetKeyDown(KeyCode.E) && isInteracting && pauseMenu.activeSelf == false || !terminalInterface.activeSelf)
        {
            CloseTerminal();
            if (inRange && isInteracting)
            {
                buttonSelectedSFX.volume = VolumeManager.sfxVolume;
                buttonSelectedSFX.Play();
            }
            isInteracting = false;
            // Enable player movement when player is no longer interacting:
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    void OpenTerminal()
    {
        // Open game's win screen:
        terminalInterface.SetActive(true);
        TimeManager.gameCompleted = true;
        // Add ejected droid objects to background:
        ejectedSentinels.SetActive(true);
        // Change environment lighting:
        redLight.SetActive(false);
        normalLight.SetActive(true);
    }

    void CloseTerminal()
    {
        // Close game's win screen:
        terminalInterface.SetActive(false);
    }

    void RenderTerminalOff()
    {
        // Terminal is off:
        x = 0;
        // Set terminal screen material to first optional material (black):
        materials[1] = optionmaterials[x];
        // Assign updated materials array to current materials array for game object:
        rend.materials = materials;
    }

    void RenderTerminalOn()
    {
        // Terminal switches on if player is in range, or terminal is completed:
        x = 1;
        // Set terminal screen material to second optional material (emissive blue):
        materials[1] = optionmaterials[x];
        // Assign updated materials array to current materials array for game object:
        rend.materials = materials;
    }
}
