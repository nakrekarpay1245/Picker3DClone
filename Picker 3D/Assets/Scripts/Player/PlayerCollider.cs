using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private bool isGrounded;

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
        //if (other.gameObject.CompareTag("Platform"))
        //{
        //    isGrounded = true;
        //}

        if (other.gameObject.CompareTag("FinishLine"))
        {
            UserInterfaceManager.userInterfaceManager.HideInGameUI();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            PlayerMovement.playerMovement.CantMove();
        }
    }

    public bool IsPlayerGrounded()
    {
        return isGrounded;
    }
}
