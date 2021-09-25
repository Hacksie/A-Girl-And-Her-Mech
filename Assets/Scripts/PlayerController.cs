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
        [SerializeField] private WeaponsController weaponsController;
        [Header("State")]
        [SerializeField] private GameData data;
        [Header("Settings")]
        [SerializeField] private GameSettings settings;
        //[SerializeField] private float orbitSpeed = 180.0f;
        [SerializeField] private LayerMask aimMask;


        private Vector2 mousePosition;
        private Vector2 movement;
        private float orbit;

        private Animator animator;

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

            animator = GetComponent<Animator>();
        }

        public void Freeze()
        {
            this.movement = Vector3.zero;
            Animate();
        }

        public void UpdateBehaviour()
        {
            this.mainCamera.transform.rotation = Quaternion.Euler(this.mainCamera.transform.rotation.eulerAngles.x, this.mainCamera.transform.rotation.eulerAngles.y + orbit * settings.orbitSpeed * Time.deltaTime, this.mainCamera.transform.rotation.eulerAngles.z);

            Animate();
        }

        public void FixedUpdateBehaviour()
        {
            rigidbody.MovePosition(this.transform.position + this.transform.forward * movement.y * Time.fixedDeltaTime * (settings.walkSpeed + data.bonusWalkSpeed));
            rigidbody.MoveRotation(Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + movement.x * settings.rotateSpeed * Time.fixedDeltaTime, 0));

            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(this.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, aimMask))
            {
                //aimPoint.transform.position = hit.point;
                var rotation = Quaternion.LookRotation(hit.point - this.transform.position, Vector3.up);
                body.rotation = rotation; //Quaternion.Euler(0, rotation.eulerAngles.y, 0);
                //Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.
            }
        }

        public void OnMousePosition(InputValue value)
        {
            this.mousePosition = value.Get<Vector2>();
        }

        public void OnMove(InputValue value)
        {
            this.movement = value.Get<Vector2>();
        }

        public void OnFire()
        {
            if (GameManager.Instance.State.Playing)
            {
                weaponsController.FireCurrentWeapon();
            }
        }

        public void OnCoolant()
        {
            if (GameManager.Instance.State.Playing)
            {
                data.UseCoolant();
            }
        }

        public void OnOrbit(InputValue value)
        {
            Debug.Log("Orbit");
            this.orbit = value.Get<float>();
        }

        public void OnChangeWeapon(InputValue value)
        {
            var dir = value.Get<float>();

            if (dir != 0)
            {
                
                 data.selectedWeapon += dir != 0 ? 1 : -1;

                    if (data.selectedWeapon > 3)
                    {
                        data.selectedWeapon = 0;
                    }

                    if (data.selectedWeapon < 0)
                    {
                        data.selectedWeapon = 3;
                    }


                // for (int i = 0; i < 4; i++)
                // {
                //     data.selectedWeapon += dir != 0 ? 1 : -1;

                //     if (data.selectedWeapon > 3)
                //     {
                //         data.selectedWeapon = 0;
                //     }

                //     if (data.selectedWeapon < 0)
                //     {
                //         data.selectedWeapon = 3;
                //     }

                //     // if(weaponsController.GetCurrentWeapon().type != WeaponType.None)
                //     // {
                //     //     break;
                //     // }

                // }

            }





        }

        public void OnRightArm()
        {
            if (data.rightArmWeapon != WeaponType.None)
            {
                data.selectedWeapon = 0;
            }
        }

        public void OnLeftArm()
        {
            if (data.leftArmWeapon != WeaponType.None)
            {
                data.selectedWeapon = 1;
            }
        }

        public void OnRightShoulder()
        {
            if (data.rightShoulderWeapon != WeaponType.None)
            {
                data.selectedWeapon = 2;
            }
        }

        public void OnLeftShoulder()
        {
            if (data.leftShoulderWeapon != WeaponType.None)
            {
                data.selectedWeapon = 3;
            }
        }

        private void Animate()
        {
            animator.SetFloat("Speed", this.movement.y);
        }




    }
}