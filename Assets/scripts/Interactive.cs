using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

    private bool m_isColliding = false;
    [Header("Light Change Object")]
    [SerializeField] private GameObject m_gameObject;
    [SerializeField] private Material m_glowGreen;
    [SerializeField] private Material m_glowRed;

    [Header("Elevator Object")]
    [SerializeField] private float m_timer;
    [SerializeField] private GameObject m_elevator;
    [SerializeField] private GameObject m_turnOff;
    [SerializeField] private GameObject m_turnOn;
    [SerializeField] private Material m_lightGreen;
    [SerializeField] private Material m_lightRed;
    [SerializeField] private Material m_lightOff;
    


    
    public IEnumerator CountdownElevatorUp(float countdownValue)
    {
        float currCountdownValue;
        currCountdownValue = countdownValue;
        while(currCountdownValue > 0)
        {
            Debug.Log("Countdown: "+ currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if(currCountdownValue == 0)
        {
            
            
        }

    }

    float currCountdownValue;
    public IEnumerator CountdownElevator(float countdownValue)
    {
        
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if( currCountdownValue == 0)
        {
            ElevatorLightLogic(m_turnOff, m_lightRed);
            ElevatorLightLogic(m_turnOn, m_lightOff);
            m_elevator.GetComponent<Animator>().Play("Up");
        }


    }




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

    private void OnTriggerStay(Collider other)
    {
        ElevatorController(other);
    }

    private void ElevatorController(Collider col)
    {
        if(col.gameObject.tag == "Elevator" || col.gameObject.tag == "Elevator 2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ElevatorLightLogic(m_turnOn, m_lightGreen);
                ElevatorLightLogic(m_turnOff, m_lightOff);
                StartCoroutine(CountdownElevator(m_timer));
            }
        }
    }

    private void ElevatorLightLogic(GameObject light, Material color)
    {
            light.GetComponent<Renderer>().material = color;
    }

    

    



}
