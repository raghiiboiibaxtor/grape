using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;



    // Update is called once per frame
    void Update()
    {
        // Using SmoothDamp method to smooth moving camera frames. Passing position, new position, velocity & speed as parameters.
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);

    }

    public void MoveToNewRoom(Transform _newroom)
    {
        currentPosX = _newroom.position.x;
    }

}
