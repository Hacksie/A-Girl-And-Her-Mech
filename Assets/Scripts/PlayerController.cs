using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HackedDesign
{
    public class PlayerController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform body;
        [SerializeField] private Transform aimPoint;
        [SerializeField] private new Rigidbody rigidbody;
        [Header("State")]
        [SerializeField] private GameData data;
        [Header("Settings")]
        [SerializeField] private float movementSpeed = 3.0f;
        [SerializeField] private float rotationSpeed = 180.0f;
        [SerializeField] private float orbitSpeed = 180.0f;


        private Vector2 mousePosition;
        private Vector2 movement;
        private float orbit;

        void Awake()
        {
            if (!rigidbody)
            {
                rigidbody = GetComponent<Rigidbody>();
            }

            if (!mainCamera)
            {
                mainCamera = Camera.main;
            }
        }

        void Update()
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(this.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                aimPoint.transform.position = hit.point;
                var rotation = Quaternion.LookRotation(aimPoint.position - this.transform.position, Vector3.up);
                body.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
                //Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.
            }

            this.mainCamera.transform.rotation = Quaternion.Euler(this.mainCamera.transform.rotation.eulerAngles.x, this.mainCamera.transform.rotation.eulerAngles.y + orbit * orbitSpeed * Time.deltaTime, this.mainCamera.transform.rotation.eulerAngles.z);

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rigidbody.MovePosition(this.transform.position + this.transform.forward * movement.y * Time.fixedDeltaTime * data.walkSpeed);
            rigidbody.MoveRotation(Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + movement.x * data.rotateSpeed * Time.fixedDeltaTime, 0));
        }

        public void OnMousePosition(InputValue value)
        {
            this.mousePosition = value.Get<Vector2>();
        }

        public void OnMove(InputValue value)
        {
            this.movement = value.Get<Vector2>();
        }

        public void OnOrbit(InputValue value)
        {
            Debug.Log("Orbit");
            this.orbit = value.Get<float>();
        }


    }
}