using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Movement Settings
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 5;
        private Vector3 _internalInput;
    #endregion

    #region Camera Settings
        [Range(0, 100)]
        [SerializeField] private float _mouseSens = 100f;
        [SerializeField] private float _Acceleration = 1;
        [SerializeField] private Transform _camera;
        float _xRotation = 0f;
        float _mouseX;
        float _mouseY;
    #endregion

    [SerializeField] private bool gameStart = true;
    [SerializeField] private bool cursorEnable = false;

    private void Update(){
        GatherInput();

        if(gameStart)
        {
            MovementController();
            CameraController();
            
            if(!cursorEnable)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = !enabled;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = enabled;
            }
        }
    }

    #region Movement
        private void MovementController(){
            Vector3 _dir = transform.right * _internalInput.x + transform.forward * _internalInput.z;
            _characterController.Move(_dir * _speed * Time.deltaTime);
        }

        private void GatherInput(){
            _internalInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _mouseX = Input.GetAxisRaw("Mouse X") * (_mouseSens * _Acceleration) * Time.deltaTime;
            _mouseY = Input.GetAxisRaw("Mouse Y") * (_mouseSens * _Acceleration) * Time.deltaTime;
        }
    #endregion

    #region Camera
        void CameraController(){
            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * _mouseX);
        }
    #endregion

}

