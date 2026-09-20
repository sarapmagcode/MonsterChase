using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindWithTag(PlayerTag).transform;
    }

    /// <summary>
    /// Called after all calculations are done in <c>Update()</c> of the <see cref="Player"/>.
    /// </summary>
    /// <remarks>
    /// This is to avoid jittering on the screen when you play.
    /// </remarks>
    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        tempPos = transform.position; // Current position of the camera
        tempPos.x = player.position.x; // Player's x-coordinate position

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos; // Update the camera's position (basically, follow the player)
    }
}
