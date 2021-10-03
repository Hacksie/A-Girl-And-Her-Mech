using UnityEngine;

namespace HackedDesign.UI
{
    public class ShopPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Button radarButton;
        [SerializeField] private UnityEngine.UI.Button turretWButton;
        [SerializeField] private UnityEngine.UI.Button turretEButton;
        [SerializeField] private UnityEngine.UI.Button walkSpeedButton;
        [SerializeField] private UnityEngine.UI.Button heatSinkButton;
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

            walkSpeedButton.interactable = data.bonusWalkSpeed < settings.maxBonusWalkSpeed;
            heatSinkButton.interactable = data.bonusHeatSink < settings.maxBonusHeatSink;
            mechButton.interactable = data.armour < settings.maxArmour;
            baseButton.interactable = data.baseHealth < settings.maxBaseHealth;

            var currentWeapon = GameManager.Instance.Player.Weapons.GetCurrentWeapon();

            cannonButton.interactable = GameManager.Instance.Player.Weapons.selectedWeapon >= WeaponPosition.LeftArm && currentWeapon.type != WeaponType.Cannon;
            gattlingButton.interactable = GameManager.Instance.Player.Weapons.selectedWeapon >= WeaponPosition.LeftArm && currentWeapon.type != WeaponType.GattlingGun;
            gaussButton.interactable = GameManager.Instance.Player.Weapons.selectedWeapon >= WeaponPosition.LeftArm && currentWeapon.type != WeaponType.Gauss;
            laserButton.interactable = GameManager.Instance.Player.Weapons.selectedWeapon >= WeaponPosition.LeftArm && currentWeapon.type != WeaponType.LaserCannon;
            autoButton.interactable = GameManager.Instance.Player.Weapons.selectedWeapon >= WeaponPosition.LeftArm && currentWeapon.type != WeaponType.AutoCannon;
            missileButton.interactable = GameManager.Instance.Player.Weapons.selectedWeapon >= WeaponPosition.RightShoulder && currentWeapon.type != WeaponType.Missiles;
            ammoButton.interactable = currentWeapon.ammoType == AmmoType.Bullet || currentWeapon.ammoType == AmmoType.Missile;
        }

        private void UpdatePrices()
        {
            var settings = GameManager.Instance.GameSettings;
            priceBaseHealText.text = settings.priceBaseHeal.ToString("N0") + "kg";
            priceRepairMechText.text = settings.priceRepairMech.ToString("N0") + "kg";
            priceSpeedIncText.text = settings.priceSpeedInc.ToString("N0") + "kg";
            priceHeatSinkText.text = settings.priceHeatSink.ToString("N0") + "kg";
            priceRepairRadarText.text = settings.priceRepairRadar.ToString("N0") + "kg";
            priceRepairWTurretText.text = settings.priceRepairWTurret.ToString("N0") + "kg";
            priceRepairETurretText.text = settings.priceRepairETurret.ToString("N0") + "kg";

            priceCannonText.text = settings.priceCannon.ToString("N0") + "kg";
            priceGattlingText.text = settings.priceGattling.ToString("N0") + "kg";
            priceGaussText.text = settings.priceGauss.ToString("N0") + "kg";
            priceLaserText.text = settings.priceLaser.ToString("N0") + "kg";
            priceAutoText.text = settings.priceAutoCannon.ToString("N0") + "kg";
            priceMissilesText.text = settings.priceMissiles.ToString("N0") + "kg";
        }

        public void PlayClickEvent()
        {
            GameManager.Instance.SetPlaying();
        }

        public void RepairBaseClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceBaseHeal))
            {
                GameManager.Instance.DamageBase(-1 * GameManager.Instance.GameSettings.repairBaseHealth);
                Buy(GameManager.Instance.GameSettings.priceBaseHeal);
            }
        }

        public void RepairMechClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceRepairMech))
            {
                GameManager.Instance.DamageArmour(-1 * GameManager.Instance.GameSettings.repairMechArmour);
                Buy(GameManager.Instance.GameSettings.priceRepairMech);
            }
        }

        public void IncMechSpeedClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceSpeedInc))
            {
                GameManager.Instance.IncreaseSpeed(1);
                Buy(GameManager.Instance.GameSettings.priceSpeedInc);
            }
        }

        public void IncHeatSinkClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceHeatSink))
            {
                GameManager.Instance.IncreaseHeatSink(1);
                Buy(GameManager.Instance.GameSettings.priceHeatSink);
            }
        }

        public void RepairRadarClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceRepairRadar))
            {
                GameManager.Instance.GameData.radarWorking = true;
                Buy(GameManager.Instance.GameSettings.priceRepairRadar);
            }
        }

        public void RepairETurretClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceRepairETurret))
            {
                GameManager.Instance.GameData.eturretWorking = true;
                Buy(GameManager.Instance.GameSettings.priceRepairETurret);
            }
        }

        public void RepairWTurretClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceRepairWTurret))
            {
                GameManager.Instance.GameData.wturretWorking = true;
                Buy(GameManager.Instance.GameSettings.priceRepairWTurret);
            }
        }

        public void UpgradeCannonClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceCannon) && GameManager.Instance.Player.Weapons.selectedWeapon != 0)
            {
                GameManager.Instance.Player.Weapons.UpgradeWeapon(WeaponType.Cannon);
                Buy(GameManager.Instance.GameSettings.priceCannon);
            }
        }

        public void UpgradeGattlingClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceGattling) && GameManager.Instance.Player.Weapons.selectedWeapon != 0)
            {
                GameManager.Instance.Player.Weapons.UpgradeWeapon(WeaponType.GattlingGun);
                Buy(GameManager.Instance.GameSettings.priceGattling);
            }
        }

        public void UpgradeGaussClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceGauss) && GameManager.Instance.Player.Weapons.selectedWeapon != 0)
            {
                GameManager.Instance.Player.Weapons.UpgradeWeapon(WeaponType.Gauss);
                Buy(GameManager.Instance.GameSettings.priceGauss);
            }
        }

        public void UpgradeLaserClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceLaser) && GameManager.Instance.Player.Weapons.selectedWeapon != 0)
            {
                GameManager.Instance.Player.Weapons.UpgradeWeapon(WeaponType.LaserCannon);
                Buy(GameManager.Instance.GameSettings.priceLaser);
            }
        }

        public void UpgradeAutoCannonClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceAutoCannon) && GameManager.Instance.Player.Weapons.selectedWeapon != 0)
            {
                GameManager.Instance.Player.Weapons.UpgradeWeapon(WeaponType.AutoCannon);
                Buy(GameManager.Instance.GameSettings.priceAutoCannon);
            }
        }

        public void UpgradeMissilesClick()
        {
            if (CanAfford(GameManager.Instance.GameSettings.priceMissiles) && GameManager.Instance.Player.Weapons.selectedWeapon != 0)
            {
                GameManager.Instance.Player.Weapons.UpgradeWeapon(WeaponType.Missiles);
                Buy(GameManager.Instance.GameSettings.priceMissiles);
            }
        }        

        public void WeaponUnhover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.None);
        }

        public void CannonHover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.Cannon);
        }

        public void GattlingGunHover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.GattlingGun);
        }

        public void GaussHover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.Gauss);
        }

        public void LaserHover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.LaserCannon);
        }

        public void AutocannonHover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.AutoCannon);
        }

        public void MissileHover()
        {
            GameManager.Instance.Player.Weapons.SetTempWeapon(WeaponType.Missiles);
        }

        private bool CanAfford(int price) => GameManager.Instance.GameData.scrap >= price;
        private void Buy(int price) => GameManager.Instance.GameData.scrap -= price;

    }
}