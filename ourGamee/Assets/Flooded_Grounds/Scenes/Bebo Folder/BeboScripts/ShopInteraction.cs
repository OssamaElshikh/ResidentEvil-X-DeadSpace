using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopInteraction : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public GameObject promptText; // Reference to the UI element displaying the prompt
    public GameObject storeCanvas; // Reference to the Store Canvas GameObject
    public GameObject inventoryCanvas; // Reference to the Inventory Canvas GameObject
    

    private bool inShopZone = false;
    private bool isPaused = false;
    private CursorLockMode previousLockMode; // To store the previous cursor lock mode

    void Update()
    {
        if (isPaused) return; // If paused, don't perform the interaction check

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 15)
        {
            inShopZone = true;
            promptText.SetActive(true); // Display the prompt text

            if (Input.GetKeyDown(KeyCode.B))
            {
                PauseGame();
                ActivateStore();
            }
        }
        else
        {
            inShopZone = false;
            promptText.SetActive(false); // Hide the prompt text
        }
    }

    void ActivateStore()
    {
        storeCanvas.SetActive(true); // Activate the Store Canvas
        inventoryCanvas.SetActive(true); // Activate the Inventory Canvas
    }

    void DeActivateStore()
    {
        storeCanvas.SetActive(false); // Activate the Store Canvas
        inventoryCanvas.SetActive(false); // Activate the Inventory Canvas
    }



    void PauseGame()
    {
        isPaused = true;
        previousLockMode = Cursor.lockState; // Store the current cursor lock mode
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        ActivateStore(); 
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Restore the time scale
        DeActivateStore();
        Cursor.lockState = previousLockMode; // Restore the previous cursor lock mode
        Cursor.visible = false; // Hide the cursor
    }
}
