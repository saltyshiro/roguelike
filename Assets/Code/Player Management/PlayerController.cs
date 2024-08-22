using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool smoothTransition = false;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;
    private static GameObject sampleInstance;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (Stairs.goingUp)
        {
            
        }
        //targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (true)
        {
            prevTargetGridPos = targetGridPos;

            Vector3 targetPosition = targetGridPos;

            if (targetRotation.y > 270f  && targetRotation.y < 361f)
            {
                targetRotation.y = 0;
            }
            if (targetRotation.y < 0)
            {
                targetRotation.y = 270;
            }
            if (!smoothTransition)
            {
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition,Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
            }
        }
        else
        {
            //targetGridPos = prevTargetGridPos;
        }
    }

    public void RotateLeft()
    {
        if (atRest)
        {
            targetRotation -= Vector3.up * 90f;
        }
    }
    public void RotateRight()
    {
        if (atRest)
        {
            targetRotation += Vector3.up * 90f;
        }
    }
    public void MoveForward()
    {
        if (atRest)
        {
            targetGridPos += transform.forward;
        }
    }
    public void MoveBackward()
    {
        if (atRest)
        {
            targetGridPos -= transform.forward;
        }
    }
    public void MoveLeft()
    {
        if (atRest)
        {
            targetGridPos -= transform.right;
        }
    }
    public void MoveRight()
    {
        if (atRest)
        {
            targetGridPos += transform.right;
        }
    }
    bool atRest
    {
        get
        {
            if ((Vector3.Distance(transform.position, targetGridPos) < 0.05f) && (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
