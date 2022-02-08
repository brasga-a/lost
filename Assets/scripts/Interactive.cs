using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactive : MonoBehaviour
{

    private bool m_isColliding = false;
    [SerializeField] private GameObject m_gameObject;
    [SerializeField] private Material m_glowGreen;
    [SerializeField] private Material m_glowRed;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Interactive") 
        {
            m_isColliding = true;
            m_gameObject.GetComponent<Renderer>().material = m_glowGreen;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Interactive")
        {
            m_isColliding = false;
            m_gameObject.GetComponent<Renderer>().material = m_glowRed;
        }
    }

}
