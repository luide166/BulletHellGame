using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    public Transform WhereToBuild()
    {
        DesactivateShopUI();
        BuildSlot slot = buildSlot.GetComponent<BuildSlot>();
        slot.canBuild = false;
        return buildSlot;
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

    public void ReplayLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
