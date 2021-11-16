using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButtonScript : MonoBehaviour
{
    private GameController gcRef;

    public Button gridB;
    public Text buttonT;
    //public string player;

    public void SetGrid()
    {
        buttonT.text = gcRef.GetPlayer();
        gridB.interactable = false;
        gcRef.EndTurn();
    }

    public void SetControllerRef(GameController controller)
    {
        gcRef = controller;
    }
}
