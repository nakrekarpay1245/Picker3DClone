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

    private int gemPoint;

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
                isTouchedTheScreen = true;
                tutorial.SetActive(false);
                countdownText.gameObject.SetActive(true);
                StartCoroutine(GameStartCoroutine());
            }
        }
    }

    IEnumerator GameStartCoroutine()
    {
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
        progressSlider.value = progress;
    }

    public void ShowResults()
    {
        resultsMenu.SetActive(true);
    }
}
