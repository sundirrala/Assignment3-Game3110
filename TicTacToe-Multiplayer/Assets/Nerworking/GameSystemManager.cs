using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemManager : MonoBehaviour
{

    GameObject username, password, usernameTxt, passwordTxt, loginButt, createAccButt, togLog, togCreate, networkedClient, findGameSeshButt, placeholderGameButt;

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

        if(newState == GameStates.Login)
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
            placeholderGameButt.SetActive(true);
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
