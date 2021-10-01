using UnityEngine;

namespace HackedDesign.UI
{
    public class ShopPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Button radarButton;
        [SerializeField] private UnityEngine.UI.Button turretWButton;
        [SerializeField] private UnityEngine.UI.Button turretEButton;
        [SerializeField] private UnityEngine.UI.Button walkSpeedButton;
        [SerializeField] private UnityEngine.UI.Button mechButton;
        [SerializeField] private UnityEngine.UI.Button baseButton;
        [SerializeField] private UnityEngine.UI.Button cannonButton;
        [SerializeField] private UnityEngine.UI.Button gattlingButton;
        [SerializeField] private UnityEngine.UI.Button gaussButton;
        [SerializeField] private UnityEngine.UI.Button laserButton;
        [SerializeField] private UnityEngine.UI.Button autoButton;
        [SerializeField] private UnityEngine.UI.Button missileButton;
        [SerializeField] private UnityEngine.UI.Button ammoButton;

        [Header("Prices")]
        [SerializeField] private UnityEngine.UI.Text priceBaseHealText;
        [SerializeField] private UnityEngine.UI.Text priceRepairMechText;
        [SerializeField] private UnityEngine.UI.Text priceSpeedIncText;
        [SerializeField] private UnityEngine.UI.Text priceHeatSinkText;
        [SerializeField] private UnityEngine.UI.Text priceRepairRadarText;
        [SerializeField] private UnityEngine.UI.Text priceRepairWTurretText;
        [SerializeField] private UnityEngine.UI.Text priceRepairETurretText;

        [SerializeField] private UnityEngine.UI.Text priceCannonText;
        [SerializeField] private UnityEngine.UI.Text priceGattlingText;
        [SerializeField] private UnityEngine.UI.Text priceGaussText;
        [SerializeField] private UnityEngine.UI.Text priceLaserText;
        [SerializeField] private UnityEngine.UI.Text priceAutoText;
        [SerializeField] private UnityEngine.UI.Text priceMissilesText;
        [SerializeField] private UnityEngine.UI.Text priceAmmoText;

        public override void Repaint()
        {
            UpdateInteractablity();
            UpdatePrices();
        }

        private void UpdateInteractablity()
        {
            var data = GameManager.Instance.GameData;
            var settings = GameManager.Instance.GameSettings;
            radarButton.interactable = !data.radarWorking;
            turretWButton.interactable = !data.wturretWorking;
            turretEButton.interactable = !data.eturretWorking;

            turretEButton.interactable = data.bonusWalkSpeed < settings.maxBonusWalkSpeed;
            mechButton.interactable = data.armour < settings.maxArmour;
            baseButton.interactable = data.baseHealth < settings.maxBaseHealth;

            var currentWeapon = GameManager.Instance.Weapons.GetCurrentWeapon();

            cannonButton.interactable = data.selectedWeapon >= 1 && currentWeapon.type != WeaponType.Cannon;
            gattlingButton.interactable = data.selectedWeapon >= 1 && currentWeapon.type != WeaponType.GattlingGun;
            gaussButton.interactable = data.selectedWeapon >= 1 && currentWeapon.type != WeaponType.Gauss;
            laserButton.interactable = data.selectedWeapon >= 1 && currentWeapon.type != WeaponType.LaserCannon;
            autoButton.interactable = data.selectedWeapon >= 1 && currentWeapon.type != WeaponType.AutoCannon;
            missileButton.interactable = data.selectedWeapon >= 2 && currentWeapon.type != WeaponType.Missiles;
            ammoButton.interactable = currentWeapon.ammoType == AmmoType.Bullet || currentWeapon.ammoType == AmmoType.Missile;
        }

        private void UpdatePrices()
        {
            var settings = GameManager.Instance.GameSettings;
            priceBaseHealText.text = settings.priceBaseHeal.ToString("N0");
            priceRepairMechText.text = settings.priceRepairMech.ToString("N0");
            priceSpeedIncText.text = settings.priceSpeedInc.ToString("N0");
            priceHeatSinkText.text = settings.priceHeatSink.ToString("N0");
            priceRepairRadarText.text = settings.priceRepairRadar.ToString("N0");
            priceRepairWTurretText.text = settings.priceRepairWTurret.ToString("N0");
            priceRepairETurretText.text = settings.priceRepairETurret.ToString("N0");

            priceCannonText.text = settings.priceCannon.ToString("N0");
            priceGattlingText.text = settings.priceGattling.ToString("N0");
            priceGaussText.text = settings.priceGauss.ToString("N0");
            priceLaserText.text = settings.priceLaser.ToString("N0");
            priceAutoText.text = settings.priceAutoCannon.ToString("N0");
            priceMissilesText.text = settings.priceMissiles.ToString("N0");
        }

        public void PlayClickEvent()
        {
            GameManager.Instance.SetPlaying();
        }

        public void RepairBaseClick()
        {
            if (GameManager.Instance.GameData.scrap >= GameManager.Instance.GameSettings.priceBaseHeal)
            {
                GameManager.Instance.DamageBase(-1 * GameManager.Instance.GameSettings.repairBaseHealth);
                GameManager.Instance.GameData.scrap -= GameManager.Instance.GameSettings.priceBaseHeal;
            }
        }

        public void RepairMechClick()
        {
            if (GameManager.Instance.GameData.scrap >= GameManager.Instance.GameSettings.priceRepairMech)
            {
                GameManager.Instance.DamageArmour(-1 * GameManager.Instance.GameSettings.repairMechArmour);
                GameManager.Instance.GameData.scrap -= GameManager.Instance.GameSettings.priceRepairMech;
            }
        }

        public void WeaponUnhover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.None);
        }

        public void CannonHover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.Cannon);
        }

        public void GattlingGunHover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.GattlingGun);
        }

        public void GaussHover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.Gauss);
        }

        public void LaserHover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.LaserCannon);
        }

        public void AutocannonHover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.AutoCannon);
        }

        public void MissileHover()
        {
            GameManager.Instance.Weapons.SetTempWeapon(WeaponType.Missiles);
        }
    }
}