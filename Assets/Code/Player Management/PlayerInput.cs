using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{

    PlayerController controller;
    public int encounterRate = 5;
    int counter = 0;
    public AudioSource encounterSound;
    bool battleStarting = false;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && !Stairs.waitingForAnswer && !battleStarting)
        {
            controller.MoveForward();
            StartCoroutine(Encounter());
            counter++;
            if (counter == 5)
            {
                encounterRate += Random.Range(1, 6);
                counter = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) && !Stairs.waitingForAnswer && !battleStarting)
        {
            controller.MoveLeft();
            StartCoroutine(Encounter());
            counter++;
            if (counter == 5)
            {
                encounterRate += Random.Range(1, 6);
                counter = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.S) && !Stairs.waitingForAnswer && !battleStarting)
        {
            controller.MoveBackward();
            StartCoroutine(Encounter());
            counter++;
            if (counter == 5)
            {
                encounterRate += Random.Range(1, 6);
                counter = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.D) && !Stairs.waitingForAnswer && !battleStarting)
        {
            controller.MoveRight();
            StartCoroutine(Encounter());
            counter++;
            if (counter == 5)
            {
                encounterRate+= Random.Range(1,6);
                counter = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Q) && !Stairs.waitingForAnswer && !battleStarting)
        {
            controller.RotateLeft();
        }
        if (Input.GetKeyUp(KeyCode.E) && !Stairs.waitingForAnswer && !battleStarting)
        {
            controller.RotateRight();
        }

    }

    IEnumerator Encounter()
    {
        int rng = Random.Range(1,101);
        Debug.Log(rng);
        if (rng <= encounterRate)
        {
            battleStarting = true;
            GameObject bgm = GameObject.FindGameObjectWithTag("BGM");
            bgm.GetComponent<AudioSource>().Stop();
            encounterSound.Play();
            yield return new WaitForSeconds(2.19f);
            Debug.Log("Encounter Rate: " + encounterRate);
            SceneManager.LoadScene("Battle");
            encounterRate = 5;
            battleStarting = false;
        }
    }
}
