using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Movement Settings
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private float _speed = 5;
        private Vector3 _input;
        [SerializeField] private float _turnSpeed = 360;
    #endregion


    private void FixedUpdate(){
        MovementController();
        Look();
    }

    #region Movement
        private void MovementController()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            _rigidBody.MovePosition(transform.position + _input * _speed * Time.deltaTime);
        }

        private void Look()
    {
        if(_input != Vector3.zero)
        {
            var relative = (transform.position + _input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }


    #endregion

    

}

