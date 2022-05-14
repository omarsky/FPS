using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Timers;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float m_movementSpeed = 1f;
    [SerializeField]
    float m_rotationSpeed = 1f;

    CharacterController m_controller;
    [SerializeField]
    Transform m_armCamera;

    [SerializeField]
    GameObject m_bulletSpawn;
    [SerializeField]
    GameObject m_linePrefab; //to delete?
    [SerializeField]
    GameObject m_throwObjectPrefab; // todo

    [SerializeField]
    LayerMask m_objectsAffectedByShotsMask;

    Vector3 m_currentMove;
    Vector3 m_currentRotation;

    [Header("Ground check")]
    [SerializeField]
    Transform m_checkGround;
    [SerializeField]
    float m_checkGroundRadius = 2f;
    [SerializeField]
    float m_gravity = 9.81f;
    Vector3 m_currentSpeed;
    bool m_isGrounded;
    [SerializeField]
    LayerMask m_groundMask;

    void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdateMovement();
        UpdateGravity();
    }

    private void UpdateGravity()
    {
        if (!m_isGrounded)
        {
            m_currentSpeed.y -= (m_gravity / 2) * (Time.deltaTime * Time.deltaTime);
            m_controller.Move(m_currentSpeed);
        }
        if (Physics.CheckSphere(m_checkGround.position, m_checkGroundRadius, m_groundMask))
        {
            m_isGrounded = true;
            m_currentSpeed.y = 0;
        }
        else
        {
            m_isGrounded = false;
        }
    }

    private void UpdateRotation()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + m_currentRotation.x * m_rotationSpeed * Time.deltaTime, 0);
        
        Vector3 newRot = new Vector3(Camera.main.transform.rotation.eulerAngles.x - m_currentRotation.y * m_rotationSpeed * Time.deltaTime, transform.rotation.eulerAngles.y, 0);
        Quaternion camerasRotation = Quaternion.Euler(newRot);
        Camera.main.transform.rotation = camerasRotation;
        m_armCamera.rotation = camerasRotation;
    }

    private void UpdateMovement()
    {
        Vector3 moveForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * m_currentMove.y * m_movementSpeed * Time.deltaTime;
        Vector3 moveSideways = transform.right * m_currentMove.x * m_movementSpeed * Time.deltaTime;
        m_controller.Move(moveForward);
        m_controller.Move(moveSideways);
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        m_currentMove = value.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext value)
    {
        m_currentRotation = value.ReadValue<Vector2>();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(m_checkGround.position, m_checkGroundRadius);
    }
}