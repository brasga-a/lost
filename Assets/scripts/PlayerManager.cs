using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Movement Settings
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private float _speed = 5;
        private Vector3 _internalInput;
    #endregion


    private void FixedUpdate(){
        MovementController();
        
    }

    #region Movement
        private void MovementController()
    {
            Vector3 _velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            _rigidBody.MovePosition(transform.position + _velocity * _speed * Time.deltaTime);
        }


    #endregion

    

}

