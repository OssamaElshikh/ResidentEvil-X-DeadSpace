using TMPro;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    public TextMeshProUGUI goldCoinsText; // Reference to the Text UI element displaying gold coins
    private int goldCoins = 30;

    void Start()
    {
        UpdateGoldCoinsText(); // Initialize the gold coins text to 35 when the script starts
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           // OnPurchaseButtonClicked(int itemCost);
            goldCoins--;
        }
    }
    void UpdateGoldCoinsText()
    {
        goldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    // Method to handle a purchase
    public void OnPurchaseButtonClicked(int itemCost)
    {
        if (goldCoins >= itemCost)
        {
            Debug.Log("Purchase successful!");
            goldCoins -= itemCost; // Deduct the item cost from gold coins
            UpdateGoldCoinsText(); // Update the UI to display the new gold coins amount
            Debug.Log("Purchase successful!"); // Optionally, log a message indicating successful purchase
        }
        else
        {
            Debug.Log("Not enough gold coins!"); // Log a message if there are insufficient coins
            // Optionally, display a message to the player that they don't have enough coins
        }
    }
    public void Bebo()
    {
        Debug.Log("Bebs");

    }
}