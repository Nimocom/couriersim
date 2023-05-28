using System;
using UnityEngine;

namespace TDLN.CameraControllers
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance;

        [SerializeField] GameObject target;
        [SerializeField] float distance = 10.0f;

        [SerializeField] float xSpeed = 250.0f;
        [SerializeField] float ySpeed = 120.0f;

        [SerializeField] float yMinLimit = -20;
        [SerializeField] float yMaxLimit = 80;

        float x = 0.0f;
        float y = 0.0f;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            var angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;
        }

        float prevDistance;

        void LateUpdate()
        {
            if (distance < 2) distance = 2;

            var pos = Input.mousePosition;

            if (!Phone.Instance.IsActive)
            {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            }

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;

            transform.rotation = rotation;
            transform.position = position;


            if (Math.Abs(prevDistance - distance) > 0.001f)
            {
                prevDistance = distance;

                var rot = Quaternion.Euler(y, x, 0);
                var po = rot * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;

                transform.rotation = rot;
                transform.position = po;
            }
        }

        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }
}