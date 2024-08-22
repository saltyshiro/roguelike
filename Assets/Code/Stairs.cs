using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    public static bool goingUp = false;
    public GameObject panel;
    public static bool waitingForAnswer = false;
    private GameObject player;
    public float activationDistance = 2f;
    bool declined = false;

    void Start()
    {
        waitingForAnswer = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if (goingUp)
        {
            goingUp = false;
        }
    }

    void Update()
    {
        // Check if the player is within the activation distance of the stairs
        if (Vector3.Distance(player.transform.position, transform.position) <= activationDistance && !waitingForAnswer && !declined)
        {
            // Perform a raycast to ensure there are no obstacles between the player and the stairs
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, transform.position - player.transform.position, out hit, activationDistance))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // If the stairs are not obstructed, activate the panel
                    panel.SetActive(true);
                    waitingForAnswer = true;
                }
            }
        }
    }

    public void OnYesClicked()
    {
        goingUp = true;
        waitingForAnswer = false;
        SceneManager.LoadScene("Choose Class");
    }

    public void OnNoClicked()
    {
        panel.SetActive(false);
        waitingForAnswer = false;
        declined = true;
        player.GetComponent<PlayerController>().MoveBackward();
        StartCoroutine(OnDecline());
    }

    IEnumerator OnDecline()
    {
        yield return new WaitForSeconds(2);
        declined = false;
    }
}
