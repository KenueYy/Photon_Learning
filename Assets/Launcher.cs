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
        Log("���������� � ������-�������");
    }
    public void CreateRoom() {
        if (_roomName_create.text.Length != 0 && _nickname.text.Length != 0) {
            PhotonNetwork.NickName = _nickname.text;
            Log("������������ ��� ������: " + PhotonNetwork.NickName);
            PhotonNetwork.CreateRoom(_roomName_create.text, new Photon.Realtime.RoomOptions { MaxPlayers = maxPlayersPerRoom });
            Log($"������� {_roomName_create.text} �������");
        }
        else {
            Log("������� �������� �������");
        }
    }
    public void JoinRoom() {
        if (_roomName_join.text.Length != 0 && _nickname.text.Length != 0) {
            PhotonNetwork.NickName = _nickname.text;
            Log("������������ ��� ������: " + PhotonNetwork.NickName);
            PhotonNetwork.JoinRoom(_roomName_join.text);
        }
        else {
            Log("������� �������� �������");
        }
    }
    public override void OnJoinedRoom() {
        Log($"{PhotonNetwork.NickName} �����������");
        PhotonNetwork.LoadLevel("Lobby");
    }
    private void Log(string message) {
        Debug.Log(message);
        _logger.text += $"{message} \n";

    }
}
