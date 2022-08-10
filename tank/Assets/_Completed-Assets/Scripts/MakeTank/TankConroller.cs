using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tank
{


    public class TankConroller : MonoBehaviour
    {
        #region Variables
        private float VAxis;
        private float HAxis;
        private float moveSpeed = 10.0f;
        private float rotateSpeed = 150.0f;

        public int playerNum = 1;
        string mvAxisName;
        string roAxisName;

        Rigidbody rigid;

        #endregion Variables

        #region Methods

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            mvAxisName = "Vertical" + playerNum;
            roAxisName = "Horizontal" + playerNum;
        }

        private void Update()
        {
            VAxis = Input.GetAxis(mvAxisName) * moveSpeed * Time.deltaTime;
            HAxis = Input.GetAxis(roAxisName) * rotateSpeed * Time.deltaTime;

            transform.Translate(0, 0, VAxis);

            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0f, HAxis, 0f));
        }

        private void LateUpdate()
        {
          
        }

        private void Move()
        {
           
        }

        private void Turn()
        {
            float turn = HAxis * rotateSpeed * Time.deltaTime;

            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0f, turn, 0f));
           
        }


        #endregion Methods
    }
}
