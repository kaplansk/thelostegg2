
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerManager : MonoBehaviour
{

    private CharacterController _characterController;

    [SerializeField] private Image _checkPointSlider;

    private bool _checkpoint1 = true, _checkpoint2 = true, _checkpoin3=true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint1") && _checkpoint1)
        {
            _checkPointSlider.fillAmount += 0.33f / 1f;
            _checkpoint1 = false;
        }
        if (other.gameObject.CompareTag("CheckPoint2")&& _checkpoint2)
        {
            _checkPointSlider.fillAmount += 0.33f / 1f;
            _checkpoint2=false;
        }
        if (other.gameObject.CompareTag("CheckPoint3") &&_checkpoin3)
        {
            _checkPointSlider.fillAmount += 0.33f / 1f;
            _checkpoin3 = false;    
        }
    }


}
