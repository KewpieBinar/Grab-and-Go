using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;

    [SerializeField]
    private RoomListingMenu _roomListingMenu;

    private RoomCanvases _roomCanvases;
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        /*Debug.Log(_roomListingMenu);
        Debug.Log(canvases);*/
        _roomListingMenu.FirstInitialize(canvases);
    }
}
