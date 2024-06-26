﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomCanvases _roomCanvas;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvas = canvases;
    }
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomCanvas.CurrentRoomCanvas.Hide();
    }

   
}
