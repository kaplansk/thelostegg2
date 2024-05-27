using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed, playerJumpSpeed;

    [SerializeField] private Vector3Event onMovementVector3;

    [SerializeField] private AudioSource jumpAudio;


    private float hor, ver;
    private Rigidbody _playerRigidBody;
    private Vector3 movement;

    public bool _isGrounded;
    private void Awake()
    {
        jumpAudio = this.gameObject.GetComponent<AudioSource>();
       _playerRigidBody = GetComponent<Rigidbody>();
        //onMovementVector3.AddListener(PlayerDash);
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerSlowMotion();
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


        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 Dash = new Vector3(-10f,0f,0f);
        //    onMovementVector3.Raise(Dash);

        //}

    }

 //   private void PlayerDash(Vector3 pos)
 //   {
 //_playerRigidBody.AddForce(pos, ForceMode.Impulse);
 //   }

    private void PlayerMovement()
    {

        _playerRigidBody.velocity += movement * playerMovementSpeed * Time.unscaledDeltaTime;
        
    }


    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _playerRigidBody.AddForce(Vector3.up * playerJumpSpeed, ForceMode.Impulse);
            jumpAudio.Play();
        }
           
    }

    private void PlayerSlowMotion()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f*Time.timeScale;
            
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }

    private void OnDisable()
    {
        //onMovementVector3.RemoveListener(PlayerDash);
    }
}
