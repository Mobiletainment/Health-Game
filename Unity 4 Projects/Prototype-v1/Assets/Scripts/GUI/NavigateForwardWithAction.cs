using UnityEngine;
using System.Collections;

public class NavigateForwardWithAction : NavigateForward
{

    public ActionType PerformAction = ActionType.NotSpecified;
    public UIInput input;
    public UILabel output;


    // Use this for initialization
    void Start()
    {
        Backend.Callback = ActionPerformed;
        ResetButton();
    }

    void OnClick()
    {
        Debug.Log("Push Type: " + PerformAction.ToString());

        DisableButton();


            
        switch (PerformAction)
        {
            case ActionType.NotSpecified:
                Debug.LogError("PushType not specified!");
                break;
            case ActionType.NoAction:
                ActionCompleted();
                break;
            case ActionType.RegisterChild:

                //TODO: for test purpose only!
                if (NavigationHelper.IsDummyUser(input.value))
                {
                    ActionCompleted();
                    return;
                }
                
                Backend.RegisterUser(getInput(), true);
                break;
            case ActionType.RegisterParent:

                //TODO: for test purpose only!
                if (NavigationHelper.IsDummyUser(input.value))
                {
                    ClickForward();
                    return;
                }
                Backend.RegisterUser(getInput(), false);
                break;
            case ActionType.CheckIfParentAndChildRegistered:

                //TODO: for test purpose only!
                if (NavigationHelper.IsDummyUser(GetContextInfo()))
                {
                    ActionCompleted();
                    return;
                }

                Backend.CheckIfParentAndChildAreRegistered();
                break;
            case ActionType.SendInGameBonus:
                string rewardMessage = "Du hast " + GetContextInfo() + " von deinen Eltern bekommen, weil du " + input.value;
                Debug.Log(rewardMessage);
                Backend.SendPushMessage(rewardMessage);
                ActionCompleted();
                break;
            case ActionType.LoadGameScene:
                NavigationHelper.LoadGameScene();
                break;
            default:
                break;
        }
    }

    public void ActionPerformed(string response)
    {
        Debug.Log("Action performed: " + response);
    
        if (response.StartsWith("Error:"))
        { //TODO: refactor response as a class with errorcode and body
            ActionFailed(response);
        }
        else
        {
            ActionCompleted();
        }

    }

    void ActionCompleted()
    {
        switch (PerformAction)
        {
            case ActionType.RegisterChild:
                output.text = string.Format("Hallo, {0}!\nDein Benutzername {0} ist zugleich dein Team-Name.", getInput());
                customInfoForNextScreen = getInput();
                break;
            case ActionType.RegisterParent:
                //send push notification to child
                PerformAction =  ActionType.SendPushMessage;
                Backend.SendPushMessage("Deine Eltern haben das Team-Passwort eingegeben. Das Spiel kann beginnen!");
                break;
            case ActionType.SendPushMessage:
                break;
            default:
                break;
        }

        ClickForward();
    }

    string getInput()
    {
        if (input == null)
        {
            Debug.LogError("Trying to access UIInput, but not assigned!");
        }

        return NGUIText.StripSymbols(input.value);
    }

    void Update()
    {
        UpdatePoints();
        //Debug.Log(Backend.GetUsername());
    }
}

