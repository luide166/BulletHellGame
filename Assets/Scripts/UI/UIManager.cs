using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

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

    [Header("Shop UI")]
    [SerializeField]
    private GameObject shopUI;
    private bool canBuild;
    private Transform buildSlot;
    public Vector3 offsetShopUI;
    private Camera cam;

    [Header("GameOverUI")]
    public GameObject gameOverMenu;

    [Header("GameWinUI")]
    public TextMeshProUGUI totalKilledEnemies;
    public TextMeshProUGUI totalCoinsCollected;
    public TextMeshProUGUI totalScrewsCollected;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        cam = Camera.main;
        DesactivateShopUI();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    #region Shop UI

    public void ActivateShopUI(Transform _buildSlot)
    {
        buildSlot = _buildSlot;
        BuildSlot slot = buildSlot.GetComponent<BuildSlot>();
        if (slot.canBuild)
        {
            Vector3 pos = cam.WorldToScreenPoint(buildSlot.position + offsetShopUI);
            shopUI.SetActive(true);
            if (shopUI.transform.position != pos)
            {
                shopUI.transform.position = pos;
            }
        }
    }

    public void DesactivateShopUI()
    {
        shopUI.SetActive(false);
    }

    public BuildSlot GetBuildSlot()
    {
        BuildSlot _buildSlot = buildSlot.GetComponent<BuildSlot>();
        return _buildSlot;
    }

    public Transform WhereToBuild()
    {
        DesactivateShopUI();
        BuildSlot slot = buildSlot.GetComponent<BuildSlot>();
        slot.canBuild = false;
        return buildSlot;
    }

    #endregion


    public void ChangeRoundText(int roundCount)
    {
        roundCountText.text = "Round: " + roundCount.ToString();
    }

    public void ChangePlayerLife(float _maxHealth, float _currentHealth)
    {
        float fillpercentage = _currentHealth / _maxHealth;
        healthBar.fillAmount = fillpercentage;
    }

    #region Collectables
    public void ChangeScrewText(int amount)
    {
        screwText.text = amount.ToString();
    }
    public void ChangeCoinText(int amount)
    {
        coinsText.text = amount.ToString();
    }
    #endregion

    public void ReplayLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateKilledEnemies(int amount)
    {
        totalKilledEnemies.text = amount.ToString();
    }
    public void UpdateCoinCollected(int amount)
    {
        totalCoinsCollected.text = amount.ToString();
    }
    public void UpdateScrewCollected(int amount)
    {
        totalScrewsCollected.text = amount.ToString();
    }

}