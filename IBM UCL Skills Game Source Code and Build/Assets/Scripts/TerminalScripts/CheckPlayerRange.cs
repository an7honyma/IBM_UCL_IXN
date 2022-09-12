using UnityEngine;

/*
REFERENCES:
Renderer.materials (Unity Documentation):
https://docs.unity3d.com/ScriptReference/Renderer-materials.html

*/

public class CheckPlayerRange : MonoBehaviour
{
    public GameObject player;
    public GameObject visualPrompt;
    public AudioSource buttonSelectedSFX;
    private float distance;
    private float range = 2.5f;
    public bool isInteracting = false;
    public bool inRange = false;
    public GameObject pauseMenu;


    public GameObject terminalInterface;
    public GameObject mcqManager;
    private bool terminalCompleted;

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
        // Update from MCQ manager if terminal interface is complete:
        terminalCompleted = mcqManager.GetComponent<MCQManager>().isCompleted;
        // Compute distance betweene player and terminal object:
        distance = Vector3.Distance(player.transform.position, transform.position);
        // If player is within range, or terminal interface is completed:
        if (distance < range || terminalCompleted == true)
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

        // If player is within range of terminal AND hotkey is pressed AND terminal interface is not yet complete AND pause menu is off:
        if (inRange && Input.GetKeyDown(KeyCode.E) && !isInteracting && !terminalCompleted && pauseMenu.activeSelf == false)
        {
            // Open terminal interface:
            OpenTerminal();
            isInteracting = true;
            // Disable player movement when interacting with terminal:
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        // If player is within range of terminal AND hotkey is pressed AND is currently interacting AND pause menu is off:
        else if (inRange && Input.GetKeyDown(KeyCode.E) && isInteracting && pauseMenu.activeSelf == false)
        {
            // If player stops interacting, MCQ interface is closed, avatar is able to move:
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

        if (terminalCompleted)
        {
            // Floating E is no longer rendered if terminal is completed:
            visualPrompt.SetActive(false);
        }
        else
        {
            // Player is visually prompted to interact with terminal if not yet completed:
            visualPrompt.SetActive(true);
        }
    }

    void OpenTerminal()
    {
        // Open the assigned canvas panel containing the MCQ interface:
        terminalInterface.SetActive(true);
        // Pause time progression:
        Time.timeScale = 0f;
    }

    void CloseTerminal()
    {
        // Close the assigned canvas panel containing the MCQ interface:
        terminalInterface.SetActive(false);
        // Resume time progression:
        Time.timeScale = 1f;
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
