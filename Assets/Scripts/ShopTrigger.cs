using UnityEngine;

namespace HackedDesign
{
    public class ShopTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                GameManager.Instance.SetShop();
            }
        }
    }
}