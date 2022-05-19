using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [Header("Images")]

    [Header("Sliders")]
    [SerializeField]
    private Slider progressSlider;

    [Header("Texts")]
    [SerializeField]
    private Text gemPointText;
    [SerializeField]
    private Text countdownText;

    [Header("Objects")]
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject resultsMenu;
    [SerializeField]
    private GameObject super;
    [SerializeField]
    private Animator door;

    private int gemPoint;

    bool isGameFinished;
    bool isTouchedTheScreen;
    public static UserInterfaceManager userInterfaceManager;

    private void Awake()
    {
        if (userInterfaceManager == null)
        {
            userInterfaceManager = this;
        }
    }

    void Update()
    {
        if (!isTouchedTheScreen)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(GameStartCoroutine());
            }
        }
    }

    IEnumerator GameStartCoroutine()
    {
        isTouchedTheScreen = true;
        tutorial.SetActive(false);
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "Start";
        PlayerMovement.playerMovement.CanMove();
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
    }

    IEnumerator GameFinishCoroutine()
    {
        isGameFinished = true;
        yield return new WaitForSeconds(1);
        PlayerMovement.playerMovement.CantMove();
        Debug.Log("CantMove");
        yield return new WaitForSeconds(3);
        door.SetTrigger("isActive");
        Debug.Log("doorActive");
        super.SetActive(true);
        Debug.Log("Super");
        yield return new WaitForSeconds(0.25f);
        PlayerMovement.playerMovement.CanMove();
        Debug.Log("CanMove");
        yield return new WaitForSeconds(1);
        super.SetActive(false);
        yield return new WaitForSeconds(4);
        PlayerMovement.playerMovement.CantMove();
        Debug.Log("CantMove");
        yield return new WaitForSeconds(1);
        resultsMenu.SetActive(true);
        Debug.Log("Results");
    }

    public void IncreaseGemPoint()
    {
        gemPoint++;
        ShowGemPoint();
    }

    private void ShowGemPoint()
    {
        gemPointText.text = gemPoint.ToString();
    }

    public int GetGemPoint()
    {
        return gemPoint;
    }

    public void HideInGameUI()
    {
        progressSlider.gameObject.SetActive(false);
    }

    public void ShowProgress(float progress)
    {
        if (progress < 1)
        {
            progressSlider.value = progress;
        }
    }

    public void ShowResults()
    {
        resultsMenu.SetActive(true);
    }

    public void FinishGame()
    {
        if (!isGameFinished)
        {
            StartCoroutine("GameFinishCoroutine");
        }
    }
}
