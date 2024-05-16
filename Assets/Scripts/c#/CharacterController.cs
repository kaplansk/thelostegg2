using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed, playerJumpSpeed;

    [SerializeField] private Vector3Event onMovementVector3;


    private float hor, ver;
    private Rigidbody _playerRigidBody;
    private Vector3 movement;

    public bool _isGrounded;
    private void Awake()
    {
       _playerRigidBody = GetComponent<Rigidbody>();
        onMovementVector3.AddListener(PlayerDash);
    }

    private void FixedUpdate()
    {
        PlayerMovement();
       

    }

    private void Update()
    {
       PlayerInput();
        PlayerJump();
    }
    private void PlayerInput()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
      
        movement = new Vector3(-ver, 0f, hor);

        movement.Normalize();


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 Dash = new Vector3(-10f,0f,0f);
            onMovementVector3.Raise(Dash);

        }

    }

    private void PlayerDash(Vector3 pos)
    {
 _playerRigidBody.AddForce(pos, ForceMode.Impulse);
    }

    private void PlayerMovement()
    {

        _playerRigidBody.AddForce(movement* playerMovementSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }


    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
            _playerRigidBody.AddForce(Vector3.up * playerJumpSpeed, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        onMovementVector3.RemoveListener(PlayerDash);
    }
}
