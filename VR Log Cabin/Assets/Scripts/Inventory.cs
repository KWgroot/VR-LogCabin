using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    //[HideInInspector]
    public float logs = 0, planks = 0;
    private int nextTargetAmount = 20;

    public TMP_Text logAmount, plankAmount;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLogs()
    {
        logs++;
        logAmount.text = "Logs: " + logs.ToString();
    }

    public void DecreaseLogs()
    {
        logs--;
        logAmount.text = "Logs: " + logs.ToString();
    }

    public void IncreasePlanks()
    {
        planks += 2;
        plankAmount.text = "Planks\n" + planks.ToString() + " / " + nextTargetAmount.ToString();
    }

    public void DecreasePlanks(int amountToRemove)
    {
        planks -= amountToRemove;

        if (amountToRemove == 20)
            nextTargetAmount = 10;
        else if (amountToRemove == 10)
            nextTargetAmount = 6;
        else if (amountToRemove == 6)
            nextTargetAmount = 0;

        plankAmount.text = "Planks\n" + planks.ToString() + " / " + nextTargetAmount.ToString();
    }

    public void EndGame()
    {
        plankAmount.text = "The end!";
    }
}
