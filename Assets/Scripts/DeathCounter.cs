using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    private int deathCount = 0;
    public TMP_Text deathText;

    public void IncrementDeathCount()
    {
        deathCount++;
        deathText.text = "Death: " + deathCount;
    }
}
