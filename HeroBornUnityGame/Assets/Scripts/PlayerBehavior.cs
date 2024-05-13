using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody _rb;

    //Variables for moving and rotating
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float _vInput;
    private float _hInput;

    //Variables for Jumping
    public float JumpVelocity = 5f;
    private bool _isJumping;

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    //Shooting
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        //Fixing ground jump
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player jumps when space bar is pressed
        _isJumping |= Input.GetKeyDown(KeyCode.Space);

        //Moves and rotates with player input
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        //Shoot bullets when space bar is hit
        _isShooting |= Input.GetMouseButton(0);

        /*
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }

        _isJumping = false;

        //Shooting: bullets forced to same position and rotation/direction when shooting
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward * BulletSpeed;
        }

        _isShooting = false;

    }
        private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}

