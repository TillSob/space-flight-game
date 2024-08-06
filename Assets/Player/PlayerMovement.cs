using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This class handles the movement of the player.
    // The player can move along the horizontal and vertical axis.
    // There are colliders that prevent the player from flying out of the view.

    [SerializeField]
    private float speed = 3f;
 
    private void Update()
    {
        var dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
