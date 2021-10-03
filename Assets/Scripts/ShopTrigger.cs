using UnityEngine;

namespace HackedDesign
{
    public class ShopTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (GameManager.Instance.State.Playing && other.CompareTag("Player"))
            {
                AudioManager.Instance.PlayPickup();
                GameManager.Instance.SetShop();
            }
        }
    }
}