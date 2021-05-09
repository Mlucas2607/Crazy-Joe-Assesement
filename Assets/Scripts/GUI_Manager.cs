using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUI_Manager : MonoBehaviour
{
    [Header("GUI Elements")]
    public Text scoreText;
    public Text shroomText;
    public Image[] hearts;

    [Header("Gui Variables")]
    public int pScore;
    public int shroomCount;
    public int health;

    [Header("UI References")]
    public GameObject player;

    [Header("Help Panel")]
    public GameObject helpCanvas;
    bool isHelpEnabled;

    private void Start()
    {
        isHelpEnabled = true;
    }
    private void Update()
    {
        UpdateDisplayUI();
        UpdateHealth();
        DisplayHelp();

        if (Input.GetKeyDown(KeyCode.F))
            isHelpEnabled = !isHelpEnabled;

    }
    void UpdateDisplayUI()
    {
        pScore = player.GetComponent<PlayerController>().playerScore;
        scoreText.text = pScore.ToString();

        shroomCount = player.GetComponent<PlayerController>().shroomCount;
        shroomText.text = shroomCount.ToString();
    }

    void DisplayHelp()
    {
        helpCanvas.SetActive(isHelpEnabled);
    }
    void UpdateHealth()
    {
        health = player.GetComponent<PlayerController>().health;

        for (int i = 0; i < hearts.Length; i++)
        {
            int x = i + 1;
            if (x > health)
                hearts[i].enabled = false;
            else
                hearts[i].enabled = true;
        }
    }
}
