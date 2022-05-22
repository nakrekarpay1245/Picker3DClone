using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    private int levelNumber;
    private int totalGemPoint;

    public static SaveAndLoadManager saveAndLoadManager;
    private void Awake()
    {
        if (saveAndLoadManager == null)
        {
            saveAndLoadManager = this;
        }
    }
    public void SaveGame(int levelNumber, int totalGemPoint)
    {
        PlayerPrefs.SetInt("levelNumber", levelNumber);
        PlayerPrefs.SetInt("totalGemPoint", totalGemPoint);
    }

    public int GetLevelNumber()
    {
        return PlayerPrefs.GetInt("levelNumber");
    }
    public int GetGemPoint()
    {
        return PlayerPrefs.GetInt("gemPoint");
    }
}
