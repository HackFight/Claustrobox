using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    [Range(1, 20)]
    public int MaxPlayers;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;

    public GameObject roomsUI;

    private void Start()
    {
        roomsUI.SetActive(false);
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();

        print("Trying to connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to server.");

        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("Joined the lobby.");
        roomsUI.SetActive(true);
    }

    public void InitializeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        //Load scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        //Create room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = roomSettings.MaxPlayers;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("Joined a room.");

        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer.NickName + " joined the room.");

        base.OnPlayerEnteredRoom(newPlayer);
    }
}
