using TMPro;
using UnityEngine;

public class KnifeDurabilityUI : MonoBehaviour
{
    public TextMeshProUGUI goldCoinsText; // Reference to the Text UI element on the canvas
    public TextMeshProUGUI KnifeDurabilityText;
    private TextMeshProUGUI DebugTxt;
    private int KnifeDurability = 5;
    private int goldCoins = 500; // Example starting amount of gold coins

    void Start()
    {
        UpdateKnifeDurabilityText();
        UpdateGoldCoinsText();
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
            //DebugTxt.text = ("No Enough Coins.");
        }
        else if (KnifeDurability == 10)
        {
            //DebugTxt.text = ("Durability is already Full.");
        }
        
        else
        {
            // Reduce gold coins and recharge durability
            goldCoins -= 100;
            KnifeDurability = 10;
            UpdateKnifeDurabilityText();
            UpdateGoldCoinsText();
           // DebugTxt.text = "Durability charged" ;


        }
    }

    
}
