using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks {

    [SerializeField] private byte maxPlayersPerRoom;
    [SerializeField] private TextMeshProUGUI _logger;
    [SerializeField] private TMP_InputField _nickname;
    [SerializeField] private TMP_InputField _roomName_join;
    [SerializeField] private TMP_InputField _roomName_create;

    void Start() {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster() {
        Log("Подключено к местер-серверу");
    }
    public void CreateRoom() {
        if (_roomName_create.text.Length != 0 && _nickname.text.Length != 0) {
            PhotonNetwork.NickName = _nickname.text;
            Log("Установленно имя игрока: " + PhotonNetwork.NickName);
            PhotonNetwork.CreateRoom(_roomName_create.text, new Photon.Realtime.RoomOptions { MaxPlayers = maxPlayersPerRoom });
            Log($"Комната {_roomName_create.text} создана");
        }
        else {
            Log("Введите название комнаты");
        }
    }
    public void JoinRoom() {
        if (_roomName_join.text.Length != 0 && _nickname.text.Length != 0) {
            PhotonNetwork.NickName = _nickname.text;
            Log("Установленно имя игрока: " + PhotonNetwork.NickName);
            PhotonNetwork.JoinRoom(_roomName_join.text);
        }
        else {
            Log("Введите название комнаты");
        }
    }
    public override void OnJoinedRoom() {
        Log($"{PhotonNetwork.NickName} подключился");
        PhotonNetwork.LoadLevel("Lobby");
    }
    private void Log(string message) {
        Debug.Log(message);
        _logger.text += $"{message} \n";

    }
}
