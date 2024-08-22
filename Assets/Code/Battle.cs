using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Battle : MonoBehaviour
{
    List<string> wheel = new List<string>();
    public string[] enemiesList;
    public int[] enemiesPower;
    string enemyToFight = "";
    int x = 0;
    int y = 0;
    public int playerPower = PlayerStats.power;
    int enemyPower = 0;
    int chosenEnemy;
    public TextMeshProUGUI textBox;
    public float textSpeed;
    public GameObject winnerBox;
    public TextMeshProUGUI winnerText;
    bool buttonInteractable = false;
    public static bool canEscape = true;
    public static bool inBattle;

    // Start is called before the first frame update
    void Start()
    {
        chosenEnemy = Random.Range(0, enemiesList.Length);
        enemyToFight = enemiesList[chosenEnemy];
        enemyPower = enemiesPower[chosenEnemy];
        StartCoroutine(BattleStart());
        inBattle = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BattleStart()
    {
        foreach (char c in "You are fighting a " + enemyToFight + "!")
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(3);
        textBox.text = String.Empty;
        foreach (char c in "What will you do?")
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        buttonInteractable = true;
    }
    public void Attack()
    {
        StartCoroutine(Fight());
    }

    IEnumerator Fight()
    {
        if (buttonInteractable)
        {
            wheel.Clear();
            while (x <= playerPower)
            {
                wheel.Add("player");
                x += 1;
            }
            while (y <= enemyPower)
            {
                wheel.Add("enemy");
                y += 1;
            }

            string winner = wheel[Random.Range(0, wheel.Count)];
            if (winner == "enemy")
            {
                winnerBox.SetActive(true);
                winnerText.text = "Oh no! You lost!";
                inBattle = false;
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("Test Dungeon");
            }
            else
            {
                winnerBox.SetActive(true);
                winnerText.text = "You won!";
                inBattle = false;
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("Test Dungeon");
            }
        }
    }

    public void Escape()
    {
        StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        if (buttonInteractable && canEscape)
        {
            while (x <= PlayerStats.agility)
            {
                wheel.Add("escape");
                x += 1;
            }
            while (y <= enemyPower)
            {
                wheel.Add("enemy");
                y += 1;
            }

            string winner = wheel[Random.Range(0, wheel.Count)];
            if (winner == "enemy")
            {
                textBox.text = String.Empty;
                foreach (char c in "Couldn't escape...")
                {
                    textBox.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
                yield return new WaitForSeconds(3);
                textBox.text = String.Empty;
                foreach (char c in "What will you do?")
                {
                    textBox.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
                canEscape = false;
            }
            else
            {
                foreach (char c in "Escaped!")
                {
                    textBox.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("Test Dungeon");
            }
        }
    }
}
