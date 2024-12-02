using UnityEngine;

public class HandleFly : MonoBehaviour
{
    [SerializeField] float _jumpPower = 2f;
    [SerializeField] float _rotationSpeed = 10f;

    private Rigidbody2D _rb;
    private AudioSource _jumpSound;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void FixedUpdate()
    {
        HandleRotation();
    }

    void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.linearVelocity = Vector2.up * _jumpPower;

            if(!_jumpSound.isPlaying && !GameManager.instance._isPlaying == false)
            {
                _jumpSound.Play();
            }
        }
    }

    void HandleRotation()
    {
        transform.rotation = Quaternion.Euler(0,0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }

}
