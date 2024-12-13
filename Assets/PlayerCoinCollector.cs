using UnityEngine;
using TMPro;

public class PlayerCoinCollector : MonoBehaviour
{
    public int totalCoins; 
    public TextMeshProUGUI scoreText; 

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) 
        {
            totalCoins++;
            UpdateScoreText();
            Destroy(other.gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text =  totalCoins.ToString();
    }
}