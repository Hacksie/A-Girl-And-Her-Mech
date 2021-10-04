using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

namespace HackedDesign
{
    public class PlayerController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform body;
        [SerializeField] private Transform aimPoint;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private WeaponsController weapons;


        [Header("State")]
        [SerializeField] private GameData data;
        [Header("Settings")]
        [SerializeField] private GameSettings settings;
        //[SerializeField] private float orbitSpeed = 180.0f;
        [SerializeField] private LayerMask aimMask;
        [SerializeField] private LayerMask crosshairMask;

        private Vector2 mousePosition;
        private Vector2 movement;
        private float orbit;
        private bool isFiring = false;

        private RaycastHit[] raycastHits = new RaycastHit[1];


        private Animator animator;

        public GameData Data { get => data; set => data = value; }
        public WeaponsController Weapons { get => weapons; set => weapons = value; }

        void Awake()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }

            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            if (weapons == null)
            {
                weapons = GetComponent<WeaponsController>();
            }

            animator = GetComponent<Animator>();

        }

        public void Reset()
        {
            this.transform.position = GameManager.Instance.GameSettings.startPosition;
            this.transform.rotation = Quaternion.identity;
            this.body.rotation = Quaternion.identity;
            weapons.selectedWeapon = WeaponPosition.LeftArm;
            weapons.leftArmWeapon = WeaponType.Cannon;
            weapons.rightArmWeapon = WeaponType.Claw;
            weapons.leftShoulderWeapon = WeaponType.None;
            weapons.rightShoulderWeapon = WeaponType.None;
            weapons.UpdateWeapons();
        }

        public void Freeze()
        {
            this.movement = Vector3.zero;
            Animate();
        }

        public void UpdateBehaviour()
        {
            this.mainCamera.transform.rotation = Quaternion.Euler(this.mainCamera.transform.rotation.eulerAngles.x, this.mainCamera.transform.rotation.eulerAngles.y + orbit * settings.orbitSpeed * Time.deltaTime, this.mainCamera.transform.rotation.eulerAngles.z);

            Ray ray = mainCamera.ScreenPointToRay(this.mousePosition);

            if (Physics.RaycastNonAlloc(ray, raycastHits, 100, aimMask) > 0)
            {

                var rotation = Quaternion.LookRotation(raycastHits[0].point - this.transform.position, Vector3.up);
                body.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);

            }

            if (isFiring)
            {
                weapons.FireCurrentWeapon();
            }

            Animate();
        }

        public void FixedUpdateBehaviour()
        {
            rigidbody.MovePosition(this.transform.position + this.transform.forward * movement.y * Time.fixedDeltaTime * (settings.walkSpeed + (data.bonusWalkSpeed / 2.0f)));
            rigidbody.MoveRotation(Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + movement.x * settings.rotateSpeed * Time.fixedDeltaTime, 0));
        }

        public void OnMousePosition(InputValue value) => this.mousePosition = value.Get<Vector2>();

        public void OnMove(InputValue value) => this.movement = value.Get<Vector2>();

        public void OnFire(InputValue value) => isFiring = value.isPressed && GameManager.Instance.State.Playing;

        public void OnPause() => GameManager.Instance.State.Start();

        public void OnCoolant()
        {
            if (!GameManager.Instance.State.Playing)
            {
                return;
            }
            GameManager.Instance.UseCoolant();
            AudioManager.Instance.PlayCoolant();
        }

        // public void OnOrbit(InputValue value)
        // {
        //     Debug.Log(value.);
        //     /*
        //     if (value.isPressed)
        //     {
        //         this.orbit = value.Get<float>();
        //     }
        //     else {
        //         this.orbit = 0;
        //     }*/
        // }

        public void OnChangeWeapon(InputValue value)
        {
            var dir = value.Get<float>();

            if (dir > 0)
            {
                weapons.NextWeapon();
            }

            if (dir < 0)
            {
                weapons.PrevWeapon();
            }
        }

        public void OnRightArm()
        {
            if (weapons.rightArmWeapon != WeaponType.None)
            {
                weapons.selectedWeapon = WeaponPosition.RightArm;
            }
        }

        public void OnLeftArm()
        {
            if (weapons.leftArmWeapon != WeaponType.None)
            {
                weapons.selectedWeapon = WeaponPosition.LeftArm;
            }
        }

        public void OnRightShoulder()
        {
            if (weapons.rightShoulderWeapon != WeaponType.None)
            {
                weapons.selectedWeapon = WeaponPosition.RightShoulder;
            }
        }

        public void OnLeftShoulder()
        {
            if (weapons.leftShoulderWeapon != WeaponType.None)
            {
                weapons.selectedWeapon = WeaponPosition.LeftShoulder;
            }
        }

        private void Animate()
        {
            animator.SetFloat("Rotation", this.movement.x);
            animator.SetFloat("Speed", this.movement.y);
        }
    }
}