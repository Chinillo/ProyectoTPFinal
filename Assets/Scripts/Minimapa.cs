using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapa : MonoBehaviour
{
    public Transform player; //referencia del player

    private void LateUpdate() //se usa lateupdate ya que actualiza mejor la camara
    {
        Vector3 newPosition = player.position;

        newPosition.y = transform.position.y; //hago que solo se mueva el eje y del player

        transform.position = newPosition;

    }
}
