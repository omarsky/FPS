using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotScript : MonoBehaviour
{
    LineRenderer m_lineRenderer;

    private float m_widthMultiplier;

    void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_widthMultiplier = m_lineRenderer.widthMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_lineRenderer.widthMultiplier > 0)
        {
            m_lineRenderer.widthMultiplier -= 0.001f;
        }
        else if(m_lineRenderer.enabled)
        {
            m_lineRenderer.enabled = false;
        }
    }

    public void UpdateLine(Vector3 startPoint, Vector3 endPoint)
    {
        m_lineRenderer.widthMultiplier = m_widthMultiplier;
        m_lineRenderer.enabled = true;

        m_lineRenderer.SetPosition(0, startPoint);
        m_lineRenderer.SetPosition(1, endPoint);
    }
}
