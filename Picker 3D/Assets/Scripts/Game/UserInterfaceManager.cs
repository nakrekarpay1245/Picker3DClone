using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
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
    /// <summary>
    /// LEVEL TEXT GEM POINT
    /// </summary>

    [Header("Objects")]
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject hand;
    [SerializeField]
    private GameObject resultsMenu;
    [SerializeField]
    private GameObject super;
    [SerializeField]
    private GameObject door;

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
        StartCoroutine(TutorialEffectsCoroutine());
    }

    void Update()
    {
        if (!isTouchedTheScreen)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isTouchedTheScreen = true;
                StartCoroutine(GameStartCoroutine());
            }
        }
    }

    IEnumerator TutorialEffectsCoroutine()
    {
        while (!isTouchedTheScreen)
        {
            hand.transform.DOLocalMoveX(-300, 1).OnComplete(() =>
            hand.transform.DOLocalMoveX(300, 1));

            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator GameStartCoroutine()
    {
        tutorial.transform.DOScale(Vector3.zero, 1);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            CountDownEffect();
            yield return new WaitForSeconds(1);
        }

        countdownText.text = "Start";
        CountDownEffect();
        PlayerMovement.playerMovement.CanMove();
        yield return new WaitForSeconds(1);
    }

    IEnumerator GameFinishCoroutine()
    {
        isGameFinished = true;
        PlayerCollider.playerCollider.ChangeRotatorLayer();
        yield return new WaitForSeconds(1);

        PlayerMovement.playerMovement.CantMove();
        //Debug.Log("CantMove");
        yield return new WaitForSeconds(3);

        //door.SetTrigger("isActive");
        DoorEffect();
        //Debug.Log("doorActive");
        SuperEffect();
        //Debug.Log("Super");
        yield return new WaitForSeconds(0.25f);

        PlayerMovement.playerMovement.CanMove();
        //Debug.Log("CanMove");
        yield return new WaitForSeconds(5);

        PlayerMovement.playerMovement.CantMove();
        //Debug.Log("CantMove");
        yield return new WaitForSeconds(1);

        SaveAndLoadManager.saveAndLoadManager.SaveGame(
            (SaveAndLoadManager.saveAndLoadManager.GetLevelNumber() + 1),
            SaveAndLoadManager.saveAndLoadManager.GetGemPoint() + gemPoint);

        ShowResults();
        //Debug.Log("Results");
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
        progressSlider.transform.DOScale(Vector3.zero, 1);
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
        resultsMenu.transform.DOScale(Vector3.one, 1);
    }

    public void SuperEffect()
    {
        super.transform.DOScale(Vector3.one, 1).OnComplete(() =>
        super.transform.DOScale(Vector3.zero, 1));
    }

    public void CountDownEffect()
    {
        countdownText.gameObject.transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        countdownText.gameObject.transform.DOScale(Vector3.zero, 0.5f));
    }

    public void DoorEffect()
    {
        door.gameObject.transform.DOLocalMoveY(20, 2).SetEase(Ease.InBounce);
    }

    public void FinishGame()
    {
        if (!isGameFinished)
        {
            StartCoroutine("GameFinishCoroutine");
        }
    }
}
