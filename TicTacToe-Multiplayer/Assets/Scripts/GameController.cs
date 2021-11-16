using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private string player;
    private int moveCount;

    public Text[] buttonList;
    public GameObject goPanel;
    public Text goText;

    private void Awake()
    {
        SetControllerRefOnButtons();
        player = "X";
        goPanel.SetActive(false);
        moveCount = 0;
    }

    void SetControllerRefOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridButtonScript>().SetControllerRef(this);
        }
    }

    public string GetPlayer()
    {
        return player; 
    }

    public void EndTurn()
    {
        moveCount++;

        if(buttonList[0].text == player && buttonList[1].text == player && buttonList[2].text == player)
        {
            GameOver();
        }
        if (buttonList[3].text == player && buttonList[4].text == player && buttonList[5].text == player)
        {
            GameOver();
        }
        if (buttonList[6].text == player && buttonList[7].text == player && buttonList[8].text == player)
        {
            GameOver();
        }
        if (buttonList[0].text == player && buttonList[3].text == player && buttonList[6].text == player)
        {
            GameOver();
        }
        if (buttonList[1].text == player && buttonList[4].text == player && buttonList[7].text == player)
        {
            GameOver();
        }
        if (buttonList[2].text == player && buttonList[5].text == player && buttonList[8].text == player)
        {
            GameOver();
        }
        if (buttonList[0].text == player && buttonList[4].text == player && buttonList[8].text == player)
        {
            GameOver();
        }
        if (buttonList[2].text == player && buttonList[4].text == player && buttonList[6].text == player)
        {
            GameOver();
        }

        if(moveCount >= 9)
        {
            SetGameOverText("It's a draw!!");
        }    

        ChangeSides();
    }

    private void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText(player + " Wins!");
    }

    private void ChangeSides()
    {
        player = (player == "X") ? "O" : "X";
    }

    private void SetGameOverText(string value)
    {
        goPanel.SetActive(true);
        goText.text = value;
    }
}
