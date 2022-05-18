using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectArea : MonoBehaviour
{
    public int collectedCollectableCount;
    public int minimumCollectedCollectableCount;

    public Text collectedCollectableCountText;

    public void IncreaseCollectedCollectableCount()
    {
        collectedCollectableCount++;
        DisplayCollectedCollectableCount();
    }

    private void DisplayCollectedCollectableCount()
    {
        collectedCollectableCountText.text = collectedCollectableCount + " / " + minimumCollectedCollectableCount;
    }
}
