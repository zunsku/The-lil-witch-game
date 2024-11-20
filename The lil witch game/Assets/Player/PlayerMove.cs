using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
public Rigidbody rb;
    public float speed;
    public float rotationSpeedHorizontal;
    public float rotationSpeedVertical;
    private float vertical;
    private float horizontal;
    private float horizontalLook;
    private float verticalLook;
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject Player;
    public KeyCode Restart;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        //cam = Camera.main;
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 2.24f;
    }

    private void FixedUpdate()
    {
        
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = (transform.right * horizontal + transform.forward * vertical) * speed * Time.deltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(Restart))
        {
            Player.transform.position = new Vector3(0, 1, 0);
        }
        
        horizontalLook = Input.GetAxis("Mouse X");
        verticalLook += Input.GetAxis("Mouse Y") * rotationSpeedVertical;

        transform.Rotate((transform.up * horizontalLook) * rotationSpeedHorizontal * Time.deltaTime);
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = (verticalLook);
    }
}
