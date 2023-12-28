using TMPro;
using UnityEngine;

public class StoreUI : MonoBehaviour
{
    public TextMeshProUGUI buygoldCoinsText; // Reference to the Text UI element displaying gold coins
    private int goldCoins = 30;
    public TextMeshProUGUI DebugText; // Reference to the Text UI element displaying gold coins
    void Start()
    {
        UpdateGoldCoinsText(); // Initialize the gold coins text to 35 when the script starts
    }

   
    void UpdateGoldCoinsText()
    {
        buygoldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    // Method to handle a purchase
    public void OnPurchaseButtonClicked(int itemCost)
    {
        if (goldCoins >= itemCost)
        {
            
            goldCoins -= itemCost; 
            UpdateGoldCoinsText();
            DebugText.text = "Purchase successful!";
        }
        else
        {
            DebugText.text =  "Not enough gold coins!"; 
            
        }
    }
   
}