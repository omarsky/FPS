using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movementWalkSpeed = 1f;
    [SerializeField] float m_movementRunSpeed = 1f;
    [SerializeField] float m_rotationSpeed = 1f;
    [SerializeField] float m_jumpHeight = 2f;
    [SerializeField] float m_gravity = -9.81f;

    bool m_isRunning = false;
    bool m_isWallRunning = false;
    bool m_canWallrun = false;
    bool m_canSetWallrunTimer = false;
    float m_wallrunTimer = 0f; 

    Vector3 m_jumpGravitySpeed;
    Vector3 m_currentMove;
    Vector3 m_currentRotation;
    bool m_scheduleJump;

    CharacterController m_controller;
    [SerializeField] Transform m_armCamera;

    //[SerializeField] GameObject m_throwObjectPrefab; // todo

    /*
     * possibly needed if I will have firearms
    */
    //[SerializeField] LayerMask m_objectsAffectedByShotsMask;


    void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(Tags.WallrunObject) && IsWallrunning())
        {
            float angle = Vector3.Angle(hit.normal, hit.moveDirection);
            if (angle > 80f && angle < 140f)
            {
                transform.Rotate(0f, 0f, Vector3.Angle(hit.normal, transform.right) > 90f ? 20f : -20f);
                if (m_canSetWallrunTimer)
                {
                    m_wallrunTimer = 3f;
                    m_canSetWallrunTimer = false;
                }
            }
            else
            {
                m_canWallrun = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        Vector3 resultMovement = UpdateMovement();
        resultMovement += UpdateJumpingAndGravity();

        m_controller.Move(resultMovement);

        if (!IsWallrunning())
        {
            transform.Rotate(0f, 0f, 0f);
        }

        m_wallrunTimer -= Time.deltaTime;
    }

    private bool IsWallrunning()
    {
        CollisionFlags flags = m_controller.collisionFlags;
        m_isWallRunning = m_canWallrun && !m_controller.isGrounded && (flags & CollisionFlags.Sides) != 0;
        return m_isWallRunning;
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + m_currentRotation.x * m_rotationSpeed * Time.deltaTime, 0);
        
        Vector3 newRot = new Vector3(Camera.main.transform.rotation.eulerAngles.x - m_currentRotation.y * m_rotationSpeed * Time.deltaTime, transform.rotation.eulerAngles.y, 0);
        Quaternion camerasRotation = Quaternion.Euler(newRot);
        Camera.main.transform.rotation = camerasRotation;
        m_armCamera.rotation = camerasRotation;
    }

    private Vector3 UpdateMovement()
    {
        float movementSpeed = m_isRunning ? m_movementRunSpeed : m_movementWalkSpeed;
        Vector3 moveForward = transform.forward * m_currentMove.y * movementSpeed * Time.deltaTime;
        Vector3 moveSideways = transform.right * m_currentMove.x * movementSpeed * Time.deltaTime;
        return moveForward + moveSideways;
    }

    private Vector3 UpdateJumpingAndGravity()
    {
        if (m_scheduleJump)
        {
            m_jumpGravitySpeed.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            m_canWallrun = true;
            m_canSetWallrunTimer = true;
            m_scheduleJump = false;
        }

        if (m_controller.isGrounded && m_jumpGravitySpeed.y < 0)
        {
            m_jumpGravitySpeed.y = -2f;
        }

        if (!IsWallrunning() || m_wallrunTimer < 0f)
        {
            m_jumpGravitySpeed.y += m_gravity * Time.deltaTime;
        }
        else
        {
            m_jumpGravitySpeed.y = 0f;
        }

        return m_jumpGravitySpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        m_currentMove = value.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext value)
    {
        if (value.phase == InputActionPhase.Performed)
        {
            m_isRunning = true;

        }
        else
        {
            m_isRunning = false;
        }
    }

    public void OnRotate(InputAction.CallbackContext value)
    {
        m_currentRotation = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.phase == InputActionPhase.Performed && !m_scheduleJump && (m_controller.isGrounded || m_isWallRunning))
        {
            m_scheduleJump = true;
        }
    }

    public void OnAttack()
    {
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //RaycastHit raycastHit;
        //if (Physics.Raycast(ray, out raycastHit, 300f, m_objectsAffectedByShotsMask))
        //{
        //    raycastHit.transform.GetComponent<HealthComponent>()?.ReceiveDamage(GameplayConstants.LaserGunDamage);
        //}
    }
}