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
    GameObject m_bulletSpawn;
    [SerializeField]
    GameObject m_linePrefab; 

    public LayerMask m_objectsAffectedByShotsMask;

    Vector3 m_currentMove;
    Vector3 m_currentRotation;

    void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdateMovement();
    }

    private void UpdateRotation()
    {
        Vector3 currentRot = transform.rotation.eulerAngles;
        Vector3 newRot = new Vector3(currentRot.x - m_currentRotation.y * m_rotationSpeed * Time.deltaTime, currentRot.y + m_currentRotation.x * m_rotationSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.Euler(newRot);
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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 300f, m_objectsAffectedByShotsMask))
        {
            m_linePrefab.GetComponent<LaserShotScript>().UpdateLine(m_bulletSpawn.transform.position, raycastHit.point);
            raycastHit.transform.GetComponent<HealthComponent>()?.ReceiveDamage(GameplayConstants.LaserGunDamage);
        }
        else
        {
            m_linePrefab.GetComponent<LaserShotScript>().UpdateLine(m_bulletSpawn.transform.position, ray.GetPoint(300f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.DamageDealingObject))
        {
            GetComponent<HealthComponent>().ReceiveDamage(20f);
        }
    }
}
