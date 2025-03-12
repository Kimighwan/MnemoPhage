using UnityEngine.UI;
using UnityEngine;

public class ButtonEffect : SingletonBehaviour<ButtonEffect>
{

    public LobbyUIController lobbyUIController;
    private Button button;

    void Strat()
    {
        button = GetComponent<Button>();
    }

    public void StartButton()
    {

    }

}
