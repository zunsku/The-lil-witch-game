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
    [SerializeField] public Vector3 jump;
    [SerializeField] public float jumpForce;

    [Header("Dash settings")]
    public float dashForce;
    //public KeyCode Restart;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //cam = Camera.main;
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 1f;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = (transform.right * horizontal + transform.forward * vertical) * speed * Time.deltaTime;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(Restart))
        {
            Player.transform.position = new Vector3(0, 1, 0);
        }*/

        if(Input.GetKeyDown(KeyCode.Space)){

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        
        horizontalLook = Input.GetAxis("Mouse X");
        verticalLook += Input.GetAxis("Mouse Y") * rotationSpeedVertical;

        transform.Rotate((transform.up * horizontalLook) * rotationSpeedHorizontal * Time.deltaTime);
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = (verticalLook);
    }
}
