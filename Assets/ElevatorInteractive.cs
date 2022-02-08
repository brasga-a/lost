using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInteractive : MonoBehaviour
{
    [Header("Elevator Settings")]
    [SerializeField] private float m_timer;
    [Space]
    [SerializeField] private GameObject m_elevator;
    [SerializeField] private GameObject m_turnOff;
    [SerializeField] private GameObject m_turnOn;
    [Space]
    [SerializeField] private Material m_lightGreen;
    [SerializeField] private Material m_lightRed;
    [SerializeField] private Material m_lightOff;

    bool m_isUp;

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
        if (currCountdownValue == 0)
        {
            ElevatorLightLogic(m_turnOff, m_lightRed);
            ElevatorLightLogic(m_turnOn, m_lightOff);
            m_elevator.GetComponent<Animator>().Play("Up");
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ElevatorLightLogic(m_turnOn, m_lightGreen);
                ElevatorLightLogic(m_turnOff, m_lightOff);
                StartCoroutine(CountdownElevator(m_timer));
            }
        }
    }

    private void ElevatorController(Collider col)
    {
        if (col.gameObject.tag == "Player")
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
