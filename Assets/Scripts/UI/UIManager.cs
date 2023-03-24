using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Round Info")]
    [SerializeField]
    private TextMeshProUGUI roundCountText;

    [Header("Player Info")]
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private TextMeshProUGUI screwText;
    [SerializeField]
    private TextMeshProUGUI coinsText;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoundText(int roundCount)
    {
        roundCountText.text = "Round: " + roundCount.ToString();
    }

    public void ChangePlayerLife(float _maxHealth, float _currentHealth)
    {
        float fillpercentage = _currentHealth / _maxHealth;
        healthBar.fillAmount = fillpercentage;
    }

    public void ChangeScrewText(int amount)
    {
        screwText.text = amount.ToString();
    }
    public void ChangeCoinText(int amount)
    {
        coinsText.text = amount.ToString();
    }
}