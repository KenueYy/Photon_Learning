using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour {

    public TextMeshProUGUI playerList;
    public Button button;
    public void AddPlayerInList(string player) {
        playerList.text += $"{player} \n";
    }
    public void Clear() {
        playerList.text = "";
    }
}
