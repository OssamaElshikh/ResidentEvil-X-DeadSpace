using TMPro;
using UnityEngine;

public class KnifeDurabilityUI : MonoBehaviour
{
    public TextMeshProUGUI goldCoinsText; // Reference to the Text UI element on the canvas
    public TextMeshProUGUI KnifeDurabilityText;
    private int KnifeDurability = 9;
    private int goldCoins = 500; // Example starting amount of gold coins

    void Start()
    {
        UpdateKnifeDurabilityText();
        UpdateGoldCoinsText();
    }

    private void Update()
    {
        OnRepairButtonPressed();
        UpdateGoldCoinsText();
        UpdateKnifeDurabilityText();
    }
    void UpdateGoldCoinsText()
    {
        goldCoinsText.text = "Gold: " + goldCoins.ToString(); // Update the text with the new value
    }

    void UpdateKnifeDurabilityText()
    {
        KnifeDurabilityText.text = "Knife Durability: " + KnifeDurability.ToString();

    }

    // Method to repair the knife
    public void OnRepairButtonPressed()
    {
        if ( goldCoins < 100)
        {
            Debug.Log("No Enough Coins.");
        }
        else if (KnifeDurability == 10)
        {
            Debug.Log("Durability is already Full.");
        }
        // Optionally, you can display a message if the conditions are not met
        else
        {
            // Reduce gold coins and recharge durability
            goldCoins -= 100;
            KnifeDurability = 10;
            UpdateKnifeDurabilityText();
            UpdateGoldCoinsText();


        }
    }

    
}
