using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public CinemachineVirtualCamera VirtualCamera;
    [SerializeField] public GameObject Player;

    [Header("Is Grounded?")]
    [SerializeField] float groundDistance = 0.08f;
    [SerializeField] LayerMask groundLayers;

    [Header("Movement settings")]
    [SerializeField] public float speed;
    [SerializeField] public float rotationSpeedHorizontal;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    [Header("Camera settings")]
    [SerializeField] public float rotationSpeedVertical;
    [SerializeField] private float horizontalLook;
    [SerializeField] private float verticalLook;
    
    [Header("Jump settings")]
    [SerializeField] public float jumpDuration = 0.5f;
    [SerializeField] public float jumpCooldown = 0f;
    [SerializeField] public float gravityMultiplier = 3f;
    [SerializeField] public float jumpForce;

    [Header("Dash settings")]
    public float dashForce;

    const float ZeroF = 0f;
    float jumpVelocity;
    float jumpTimer = 0;
    float jumpCooldownTimer;
    public bool IsGrounded;

    
    //public KeyCode Restart;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //cam = Camera.main;
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 1f;
        
    }

    public void stopcharacter(){
        vertical = 0;
        horizontal = 0;
        rb.velocity = (transform.right * horizontal + transform.forward * vertical) * speed * Time.deltaTime;
        print("HALT! YOU'VE VIOLATED THE LAW!");
        this.enabled = false;
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics.SphereCast(transform.position, groundDistance, Vector3.down, out _, groundDistance, groundLayers);
        if (IsGrounded) {
            Physics.gravity=new Vector3(0,0,0);
            /*if(Input.GetKeyDown(KeyCode.Space)){
                //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }*/
        }
        else {
            Physics.gravity=new Vector3(0,-200,0);
        }
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = (transform.right * horizontal + transform.forward * vertical) * speed * Time.deltaTime;
    }

    void Update()
    {
        horizontalLook = Input.GetAxis("Mouse X");
        verticalLook += Input.GetAxis("Mouse Y") * rotationSpeedVertical;
        if (verticalLook < -1){
            verticalLook = -1;
        }
        else if (verticalLook < 0.5f){
            verticalLook = 0.5f;
        }

        transform.Rotate((transform.up * horizontalLook) * rotationSpeedHorizontal * Time.deltaTime);
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = (verticalLook);

        if (vertical<0){
            print("Moving Backwards");
        }
        else if (vertical>0){
            print("Moving Forwards");
        }
        if (horizontal<0){
            print("Moving Left");
        }
        else if (horizontal>0){
            print("Moving Right");
        }
            
    }

}
