using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRoomAbduction : MonoBehaviour
{
    public ParkingManager parking;
    public void EndParkingLot()
    {
        parking.StartCoroutine(parking.EndParkingLot());
    }
}
