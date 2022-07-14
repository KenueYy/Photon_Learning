using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks {

    [SerializeField] private LobbyUI lobbyUI;

    void Start() {
        UpdatePlayerList();
        SetPlayButtonState();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        UpdatePlayerList();
    }
    public override void OnLeftRoom() {
        GameManager.instance.ChangeScene(GameManager.instance.launcherSceneNumber);
    }
    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }
    public void UpdatePlayerList() {
        lobbyUI.Clear();
        foreach (Player player in PhotonNetwork.PlayerList) {
            lobbyUI.AddPlayerInList(player.NickName);
        }
    }
    private void SetPlayButtonState() {
        if (PhotonNetwork.IsMasterClient) {
            lobbyUI.button.interactable = true;
        }
        else {
            lobbyUI.button.interactable = false;
        }
    }
}
