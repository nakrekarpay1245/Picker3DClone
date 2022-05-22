using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private bool isGrounded;

    public GameObject rotator;
    public GameObject[] rotators;

    public static PlayerCollider playerCollider;
    private void Awake()
    {
        if (playerCollider == null)
        {
            playerCollider = this;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            UserInterfaceManager.userInterfaceManager.HideInGameUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            UserInterfaceManager.userInterfaceManager.FinishGame();
            other.gameObject.GetComponent<CollectArea>().Animate();
        }

        if (other.gameObject.CompareTag("RotatorActivator"))
        {
            PlayerRotatorSkillActive();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
        }
    }

    private void PlayerRotatorSkillActive()
    {
        rotator.SetActive(true);
    }

    public bool IsPlayerGrounded()
    {
        return isGrounded;
    }

    public void ChangeRotatorLayer()
    {
        foreach (GameObject peace in rotators)
        {
            peace.gameObject.layer = 11;
        }
    }
}
