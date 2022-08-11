using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    #region Variables
    public float moveSpeed;
    public float rotateSpeed;
    public float turnSpeed;

    private float HorizontalX;
    private float VerticalZ;

    private Quaternion mTankTargetRot;
    private Quaternion mCameraTargetRot;
    private Camera mCamera;
    Vector3 moveVec;

    CharacterController controller;
    #endregion Variables

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        mCamera = Camera.main;
        mTankTargetRot = transform.localRotation;
        //mCameraTargetRot = mCamera.transform.localRotation;
    }

    private void Update()
    {
        float xRot = Input.GetAxis("Mouse X");
        float yRot = Input.GetAxis("Mouse Y");

        mTankTargetRot *= Quaternion.Euler(0f, xRot, 0f);

        //mCameraTargetRot *= Quaternion.Euler(-yRot, 0f, 0f);
        //mCamera.transform.localRotation = mCameraTargetRot;

        HorizontalX = Input.GetAxis("Horizontal1");
        VerticalZ = Input.GetAxis("Vertical1");
        moveVec = new Vector3(0, 0, VerticalZ);
        TankSetMove();
        TankRotate();
        MouseRotation();
    }


    #region Methods

    public void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;

        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;

        float xRotate = transform.eulerAngles.x + xRotateSize;

        //xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }

    public void TankSetMove()
    {
        controller.Move(transform.TransformDirection(moveVec) * moveSpeed * Time.deltaTime);
    }

    public void TankRotate()
    {
        transform.Rotate(transform.rotation * new Vector3(0f, HorizontalX, 0f) * rotateSpeed * Time.deltaTime);
    }

    #endregion Methods
}
