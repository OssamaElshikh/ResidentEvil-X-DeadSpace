using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopInteraction : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public GameObject promptText; // Reference to the UI element displaying the prompt
    public float interactionDistance = 50f; // Distance to trigger the interaction

    private bool inShopZone = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= interactionDistance)
        {
            inShopZone = true;
            promptText.SetActive(true); // Display the prompt text

            if (Input.GetKeyDown(KeyCode.B))
            {
                LoadStoreScene();
            }
        }
        else
        {
            inShopZone = false;
            promptText.SetActive(false); // Hide the prompt text
        }
    }

    void LoadStoreScene()
    {
        SceneManager.LoadScene("StoreScene"); // Load your StoreScene
    }
}
