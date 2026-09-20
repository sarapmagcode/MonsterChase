using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector] // Accessible in other scripts, but hidden from the Unity editor
    public float speed;

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        speed = 7;
    }

    private void FixedUpdate()
    {
        // linearVelocity replaces all cases where you would use velocity
        // References:
        // - https://www.reddit.com/r/Unity3D/comments/1fk45kg/rigidbodyvelocity_is_obsolete_for_unity_6_preview/
        // - https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Rigidbody-linearVelocity.html
        myBody.linearVelocity = new Vector2(speed, myBody.linearVelocity.y);
    }
}
