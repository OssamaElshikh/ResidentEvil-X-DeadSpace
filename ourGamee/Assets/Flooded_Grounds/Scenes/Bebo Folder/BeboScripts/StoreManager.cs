using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public int goldCoins = 30;
    public int redHerbCost = 10;
    public TextMeshProUGUI goldCoinsText;
    public TextMeshProUGUI feedbackText;

    private void Start()
    {
        UpdateGoldCoinsDisplay(); // Call a method to update the initial display of gold coins
    }

    void UpdateGoldCoinsDisplay()
    {
        goldCoinsText.text = "Gold: " + goldCoins.ToString();
    }

    public void PurchaseRedHerb()
    {
        if (goldCoins >= redHerbCost)
        {
            goldCoins -= redHerbCost;
            UpdateGoldCoinsDisplay(); // Update the display after the purchase
            feedbackText.text = "You purchased a red herb!";
        }
        else
        {
            feedbackText.text = "Insufficient gold coins!";
        }
    }
}
