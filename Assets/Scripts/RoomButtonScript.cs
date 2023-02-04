using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButtonScript : MonoBehaviour
{
    public void SaveRoom(string roomName)
    {
        PlayerPrefs.SetString("roomType", roomName);
    }
}
