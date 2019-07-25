using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform _Player;

    private void Update()
    {
        if (_Player.position.x <= -3)
        {
            transform.position = new Vector3(-3, 0, transform.position.z);
        }
        else if (_Player.position.x >= 68.1f)
        {
            transform.position = new Vector3(68.1f, 0, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(_Player.position.x, 0, transform.position.z);
        }
    }
}
