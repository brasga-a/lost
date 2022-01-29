using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cube;
    Renderer _rend;

    void Start(){
        _rend = cube.gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _rend.material.color = Random.ColorHSV();
        }
    }

    
}
