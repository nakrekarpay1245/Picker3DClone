using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float moveSpeed;

    [Header("Movement Clamps")]
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;

    private float progress;

    [Header("References")]
    [SerializeField]
    private Rigidbody rigidbodyComponent;

    [SerializeField]
    private GameObject startLine;
    [SerializeField]
    private GameObject finishLine;

    private bool canMove;

    public static PlayerMovement playerMovement;
    private void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = this;
        }

        rigidbodyComponent = GetComponent<Rigidbody>();

        Vector3 startPosition = new Vector3(startLine.transform.position.x,
            transform.position.y, startLine.transform.position.z);
        transform.position = startPosition;
    }

    void Start()
    {
        moveSpeed = speed;
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y, transform.position.z);

        progress = (transform.position.z - startLine.transform.position.z) /
            (finishLine.transform.position.z - startLine.transform.position.z);

        UserInterfaceManager.userInterfaceManager.ShowProgress(progress);
    }
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (canMove)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    transform.position = Vector3.Lerp(transform.position,
                        new Vector3(raycastHit.point.x, transform.position.y, transform.position.z),
                        Time.deltaTime * 5);
                }
            }

            rigidbodyComponent.velocity = Vector3.forward * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rigidbodyComponent.velocity = Vector3.zero;
        }
    }

    public void CantMove()
    {
        //Debug.Log("CantMove");
        canMove = false;
    }
    public void CanMove()
    {
        canMove = true;
    }
    public bool IsPlayerCanMove()
    {
        return canMove;
    }
}
