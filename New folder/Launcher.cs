using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("ConnectingToMaster");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("ConnectedToMaster");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joinned Lobby"); 
    }
}
