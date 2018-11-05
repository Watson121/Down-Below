using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    #region Declerations

    #region GameObjects
    public Transform Player;
    private GameObject JumpCollider;
    #endregion

    #region Components
    Rigidbody PlayerRigidBody;
    CapsuleCollider PlayerCollider;
    PlayerStats PlayerStatsScript;
    JumpingCollide Jump;
    #endregion

    #region Speeds
    float Speed; //Global Speed
    float JumpSpeed;
    //Walking Speed
    float WalkingSpeed = 5.0f;
    float StopSpeed = 0.0f;
    bool WalkingTrue;
    //Sprinting
    float SprintSpeed = 8.0f;
    bool SprintingTrue;
    //Jumping
    float WalkingJumpingSpeed = 5.0f;
    float SprintJumpingSpeed = 7.0f;
    public bool Grounded;
    //Crouching
    float CrouchingSpeed = 2.0f;
    public bool CrouchingTrue;
    //Falling
    float FallingSpeed;
    #endregion

    #region Inputs
    float VerticalInput;
    float HorizontalInput;
    #endregion

    #region Camera
    float MouseSensitivity = 5.0f;
    float VerticalRotation = 0;
    float UpDownRange = 60.0f;
    #endregion

    #region Distance
    float DistanceNum;
    float maxVelocityChange = 10.0f;
    #endregion

    #region SlowingDownThePlayer
    [SerializeField]
    bool slowPlayerDown;
    float slowDownSpeed;
    float mouseMovementSpeed;
    #endregion

    #endregion

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
        JumpCollider = GameObject.Find("Player/JumpCollider");
        PlayerRigidBody = Player.GetComponent<Rigidbody>();
        PlayerCollider = Player.GetComponent<CapsuleCollider>();
        PlayerStatsScript = Player.GetComponent<PlayerStats>();
        Jump = JumpCollider.GetComponent<JumpingCollide>();
    }

    public void Update()
    {
        GetInput();
        PlayerCamera();
        Falling();
        Jumping();
        Walking();
        Running();
        Crouching();
        SlowDownPlayer();

        Grounded = Jump.Grounded;

        Time.timeScale = 1;
        Vector3 movement = new Vector3(HorizontalInput, 0, VerticalInput) * Speed * 0.0167f;
        movement = Camera.main.transform.TransformDirection(movement);
        movement *= 60;
        
        Vector3 velocity = PlayerRigidBody.velocity;
        Vector3 velocityChange = (movement - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        PlayerRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    #region Input

    void GetInput()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
    }

    #endregion

    #region Movement

    void Walking()
    {
        //Forward And Back
        if (VerticalInput < 0.01)
        {
            Speed = WalkingSpeed;
        }
        else if(VerticalInput > 0.01)
        {
            Speed = WalkingSpeed;
        }
        if(HorizontalInput < 0.01)
        {
            Speed = WalkingSpeed;
        }
        else if(HorizontalInput > 0.01)
        {
            Speed = WalkingSpeed;
        }
        else
        {
            Speed = StopSpeed;
        }
    }
    void Running()
    {
        if (CrouchingTrue == false)
        {
            SprintingTrue = Input.GetButton("Sprint");
            if (SprintingTrue == true && Grounded == true)
            {
                Speed = SprintSpeed;
                JumpSpeed = SprintJumpingSpeed;
            }
            else if (SprintingTrue == false)
            {
                JumpSpeed = WalkingJumpingSpeed;
            }
        }
    }
    void Crouching()
    {
        if (SprintingTrue == false)
        {
            CrouchingTrue = Input.GetButton("Crouching");
            if (CrouchingTrue == true)
            {
                PlayerCollider.height = 1;
                Speed = CrouchingSpeed;
            }
            else if (CrouchingTrue == false)
            {
                PlayerCollider.height = 2;
            }
        }
    }
    void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded == true)
            {
                PlayerRigidBody.velocity = new Vector3(0, JumpSpeed, 0);
            }
        }
    }
    void Falling()
    {
        if (Grounded == false)
        {
            FallingSpeed = PlayerRigidBody.velocity.y;
        }

        if (Grounded == true)
        {
            if (FallingSpeed >= -20)
            {
                FallingSpeed = 0;
            }
            else if (FallingSpeed < -20)
            {
                PlayerStatsScript.SendMessage("FallDamage");
            }
        }
    }

    #endregion

    #region Camera
    void PlayerCamera()
    {
        float RotLeftRight = Input.GetAxis("Mouse X") * MouseSensitivity;
        transform.Rotate(0, RotLeftRight, 0);

        VerticalRotation -= Input.GetAxis("Mouse Y") * MouseSensitivity;

        VerticalRotation = Mathf.Clamp(VerticalRotation, -UpDownRange, UpDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(VerticalRotation, 0, 0);
    }

    #endregion

    void SlowDownPlayer()
    {
        if(slowPlayerDown == true)
        {
            MouseSensitivity = 0.5f;
        }else if(slowPlayerDown == false)
        {
            MouseSensitivity = 5.0f;
        }
    }

    public void SlowDownPlayerTrue()
    {
        slowPlayerDown = true;
    }

    public void SlowDownPlayerFalse()
    {
        slowPlayerDown = false;
    }


    #region Jump

    float CalculateJumpSpeed()
    {
        return Mathf.Sqrt(2 * JumpSpeed * 10f);
    }

    #endregion
}




