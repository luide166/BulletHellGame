using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private TextMeshProUGUI roundCountText; 


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoundText(int roundCount)
    {
        roundCountText.text = "Round: " + roundCount;
    }
}
