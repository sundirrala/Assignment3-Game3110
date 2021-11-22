using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour
{
    // ------------ login/create account/match variables ---------- //
    GameObject username, password, usernameTxt, passwordTxt, loginButt, createAccButt, togLog, togCreate, networkedClient, findGameSeshButt, placeholderGameButt;

    // ----------- tic tac toe variables ------------//
    GameObject bgPanel, boardPanel, gp1, gp2, gp3, gp4, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9;

    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>(); // creating an array and finding all the game objects in the scene.

        // ----- lets go through the array --------- //
        foreach(GameObject go in allObjects)
        {
            if (go.name == "Username")
            {
                username = go;
            }
            else if (go.name == "Password")
            {
                password = go;
            }
            else if (go.name == "LoginButton")
            {
                loginButt = go;
            }
            else if (go.name == "CreateAccountButton")
            {
                createAccButt = go;
            }
            else if (go.name == "LoginToggle")
            {
                togLog = go;
            }
            else if (go.name == "CreateAccountToggle")
            {
                togCreate = go;
            }
            else if (go.name == "NetworkedClient")
            {
                networkedClient = go;
            }
            else if(go.name == "FindGameRoom")
            {
                findGameSeshButt = go;
            }
            else if(go.name == "PlaceHolderTicTacToe")
            {
                placeholderGameButt = go;
            }
            else if(go.name == "UsernameTxt")
            {
                usernameTxt = go;
            }
            else if(go.name == "PasswordTxt")
            {
                passwordTxt = go;
            }
            else if(go.name == "TTTBGPanel")
            {
                bgPanel = go;
            }
            else if(go.name == "TTTBoardPanel")
            {
                boardPanel = go;
            }
            else if(go.name == "TTTGridPanel1")
            {
                gp1 = go;
            }
            else if(go.name == "TTTGridPanel2")
            {
                gp2 = go;
            }
            else if(go.name == "TTTGridPanel3")
            {
                gp3 = go;
            }
            else if(go.name == "TTTGridPanel4")
            {
                gp4 = go;
            }
            else if(go.name == "TileButton1")
            {
                tb1 = go;
            }
            else if(go.name == "TileButton2")
            {
                tb2 = go;
            }
            else if(go.name == "TileButton3")
            {
                tb3 = go;
            }
            else if(go.name == "TileButton4")
            {
                tb4 = go;
            }
            else if(go.name == "TileButton5")
            {
                tb5 = go;
            }
            else if(go.name == "TileButton6")
            {
                tb6 = go;
            }
            else if(go.name == "TileButton7")
            {
                tb7 = go;
            }
            else if(go.name == "TileButton8")
            {
                tb8 = go;
            }
            else if(go.name == "TileButton9")
            {
                tb9 = go;
            }
        }

        loginButt.GetComponent<Button>().onClick.AddListener(LoginButtonPressed);
        createAccButt.GetComponent<Button>().onClick.AddListener(CreateAccountButtonPressed);
        togCreate.GetComponent<Toggle>().onValueChanged.AddListener(ToggleCreateValueChange);
        togLog.GetComponent<Toggle>().onValueChanged.AddListener(ToggleLoginValueChange);

        findGameSeshButt.GetComponent<Button>().onClick.AddListener(FindGameSessionButtonPressed);
        placeholderGameButt.GetComponent<Button>().onClick.AddListener(PlaceHolderGameButton);

        ChangeGameStates(GameStates.Login);

    }

    void Update()
    {
        
    }

    private void LoginButtonPressed()
    {
        //Debug.Log("We gucciiiii !!");

        string name = username.GetComponent<InputField>().text;
        string pass = password.GetComponent<InputField>().text;
        if(togLog.GetComponent<Toggle>().isOn)
        {
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Login + ", " + name + ", " + pass);
        }

        //if(togLog.GetComponent<Toggle>().isOn)
        //{
        //    networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.Login + ", " + name + ", " + pass);        }
        //else
        //{
        //    networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.CreateAccount + ", " + name + ", " + pass);
        //}
    }

    private void CreateAccountButtonPressed()
    {
        string name = username.GetComponent<InputField>().text;
        string pass = password.GetComponent<InputField>().text;

        if(togCreate.GetComponent<Toggle>().isOn)
        {
            networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.CreateAccount + ", " + name + ", " + pass);
        }
    }

    private void ToggleCreateValueChange(bool newVal)
    {
        togLog.GetComponent<Toggle>().SetIsOnWithoutNotify(!newVal);
        ChangeGameStates(GameStates.CreateAccount);
    }

    private void ToggleLoginValueChange(bool newVal)
    {
        togCreate.GetComponent<Toggle>().SetIsOnWithoutNotify(!newVal);
        ChangeGameStates(GameStates.Login);
    }

    private void FindGameSessionButtonPressed()
    {
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.AddToGameSessionQueue + "");
        ChangeGameStates(GameStates.WaitingForMatch);
    }

    private void PlaceHolderGameButton()
    {
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");

    }

    public void ChangeGameStates(int newState)
    {
        //username, password, submitBut, togLog, togCreate, findGameSeshButt, placeholderGameButt;
        username.SetActive(false);
        password.SetActive(false);
        usernameTxt.SetActive(false);
        passwordTxt.SetActive(false);
        loginButt.SetActive(false);
        createAccButt.SetActive(false);
        togLog.SetActive(false);
        togCreate.SetActive(false);
        findGameSeshButt.SetActive(false);
        placeholderGameButt.SetActive(false);

        // bgPanel, boardPanel, gp1, gp2, gp3, gp4, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9;
        bgPanel.SetActive(false);
        boardPanel.SetActive(false);
        gp1.SetActive(false);
        gp2.SetActive(false);
        gp3.SetActive(false);
        gp4.SetActive(false);
        tb1.SetActive(false);
        tb2.SetActive(false);
        tb3.SetActive(false);
        tb4.SetActive(false);
        tb5.SetActive(false);
        tb6.SetActive(false);
        tb7.SetActive(false);
        tb8.SetActive(false);
        tb9.SetActive(false);


        if (newState == GameStates.Login)
        {
            username.SetActive(true);
            password.SetActive(true);
            usernameTxt.SetActive(true);
            passwordTxt.SetActive(true);
            loginButt.SetActive(true);
            togLog.SetActive(true);
            togCreate.SetActive(true);
        }
        else if(newState == GameStates.CreateAccount)
        {
            username.SetActive(true);
            password.SetActive(true);
            usernameTxt.SetActive(true);
            passwordTxt.SetActive(true);
            createAccButt.SetActive(true);
            togLog.SetActive(true);
            togCreate.SetActive(true);
        }
        else if(newState == GameStates.MainMenu)
        {
            findGameSeshButt.SetActive(true);

        }
        else if(newState == GameStates.WaitingForMatch)
        {

        }
        else if(newState == GameStates.PlayingTicTacToe)
        {
            //placeholderGameButt.SetActive(true);
            //SceneManager.LoadScene("Game");

            bgPanel.SetActive(true);
            boardPanel.SetActive(true);
            gp1.SetActive(true);
            gp2.SetActive(true);
            gp3.SetActive(true);
            gp4.SetActive(true);
            tb1.SetActive(true);
            tb2.SetActive(true);
            tb3.SetActive(true);
            tb4.SetActive(true);
            tb5.SetActive(true);
            tb6.SetActive(true);
            tb7.SetActive(true);
            tb8.SetActive(true);
            tb9.SetActive(true);
        }


    }
}

public static class GameStates
{
    public const int Login = 1;
    public const int CreateAccount = 2;
    public const int MainMenu = 3;
    public const int WaitingForMatch = 4;
    public const int PlayingTicTacToe = 5;


}
