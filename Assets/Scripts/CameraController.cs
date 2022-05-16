using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Follow Player
    [SerializeField] private Transform player;
    // Camera variables to look forward
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


    // Update is called once per frame
    void Update()
    {
        // Follow Player : Moves camera with player on x axis, leaves y and z axis unchanged.
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        // Camera will take player's position on x and add/minus aheadDistance to move slightly forward.
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

 
}
