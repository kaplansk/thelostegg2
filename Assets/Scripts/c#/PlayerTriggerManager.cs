
using UnityEngine;

public class PlayerTriggerManager : MonoBehaviour
{

    private CharacterController _characterController;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _characterController._isGrounded = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _characterController._isGrounded = false;
    }

   
}
