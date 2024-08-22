using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassChooser : MonoBehaviour
{
    public static bool knight = false;
    public static bool archer = false;
    public static bool wizard = false;
    public GameObject wizardPanel, knightPanel, archerPanel, basePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackClicked()
    {
        wizardPanel.SetActive(false);
        knightPanel.SetActive(false);
        archerPanel.SetActive(false);
        basePanel.SetActive(true);
    }

    public void WizardClicked()
    {
        wizardPanel.SetActive(true);
        basePanel.SetActive(false);
    }
    public void ArcherClicked()
    {
        archerPanel.SetActive(true);
        basePanel.SetActive(false);
    }
    public void KnightClicked()
    {
        knightPanel.SetActive(true);
        basePanel.SetActive(false);
    }

    public void OnKnightConfirmClicked()
    {
        knight = true;
        PlayerStats.power = 8;
        PlayerStats.health = 10;
        PlayerStats.agility = 3;
        PlayerStats.luck = 3;
        SceneManager.LoadScene("Test Dungeon");
    }
    public void OnArcherConfirmClicked()
    {
        archer = true;
        PlayerStats.power = 3;
        PlayerStats.health = 8;
        PlayerStats.agility = 10;
        PlayerStats.luck = 5;
        SceneManager.LoadScene("Test Dungeon");
    }
    public void OnWizardConfirmClicked()
    {
        wizard = true;
        PlayerStats.power = 5;
        PlayerStats.health = 2;
        PlayerStats.agility = 2;
        PlayerStats.luck = 10;
        SceneManager.LoadScene("Test Dungeon");
    }
}
