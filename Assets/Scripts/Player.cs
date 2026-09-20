using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // Make it configurable on the Unity editor
    private float _moveForce = 10f;

    [SerializeField] // Make it configurable on the Unity editor
    private float _jumpForce = 11f;

    private float _movementX;

    private Rigidbody2D _myBody;

    private SpriteRenderer _sr;

    private Animator _anim;
    private const string WalkAnimation = "Walk";

    private bool _isGrounded = true;
    private const string GroundTag = "Ground";

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() { }

    // Update is called once per frame
    private void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    /// <summary>
    /// Not called every frame. We usually use this to perform physics calculation involving
    /// the physics systems such as the RigidBody2D.
    /// </summary>
    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal"); // Possible values: -1, 0, 1
        transform.position += new Vector3(_movementX, 0f, 0f) * _moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (_movementX > 0) // Right
        {
            _anim.SetBool(WalkAnimation, true);
            _sr.flipX = false;
        }
        else if (_movementX < 0) // Left
        {
            _anim.SetBool(WalkAnimation, true);
            _sr.flipX = true;
        }
        else
        {
            _anim.SetBool(WalkAnimation, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _myBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _isGrounded = true;
            Debug.Log("On ground");
        }
    }
}
