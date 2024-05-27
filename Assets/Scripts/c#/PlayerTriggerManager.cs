
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerTriggerManager : MonoBehaviour
{

    private CharacterController _characterController;

    [SerializeField] private Image _checkPointSlider;
    [SerializeField] private Slider _checkSlider;

    private ParticleSystem _particle;

    private bool _checkpoint1 = true, _checkpoint2 = true, _checkpoint3=true;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _particle = GetComponentInChildren<ParticleSystem>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _characterController._isGrounded = true;
            _particle.Play();
        }


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
            _checkPointSlider.DOFillAmount(0.33f, 2f);
            _checkSlider.GetComponent<DOTweenAnimation>().DOPlay();
            _checkpoint1 = false;
        }
        if (other.gameObject.CompareTag("CheckPoint2")&& _checkpoint2)
        {
            _checkPointSlider.DOFillAmount(0.33f, 2f);
            _checkSlider.GetComponent<DOTweenAnimation>().DOPlay();
            _checkpoint2 =false;
        }
        if (other.gameObject.CompareTag("CheckPoint3") &&_checkpoint3)
        {
            _checkPointSlider.DOFillAmount(0.33f, 2f);
            _checkSlider.GetComponent<DOTweenAnimation>().DOPlay();
            _checkpoint3 = false;
           

        }
    }


}
