using UnityEngine;
using UnityEngine.UI;

public class GoldCoinsUI : MonoBehaviour
{
    public Text goldCoinsText; // Reference to the Text UI element on the canvas
    private int goldCoins = 30; // Example starting amount of gold coins

    private void Start()
    {
        goldCoinsText = GetComponent<Text>();
        goldCoinsText.text = "Gold: " + goldCoins.ToString(); // Update the text with the new value

    }
    void UpdateGoldCoinsText()
    {
        goldCoinsText.text = "Gold: " + goldCoins.ToString(); // Update the text with the new value
    }

    // Example function to deduct gold coins (call this when buying something)
   
}
