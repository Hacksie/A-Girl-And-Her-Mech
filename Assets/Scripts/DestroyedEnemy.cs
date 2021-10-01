using UnityEngine;

namespace HackedDesign
{
    
    public class DestroyedEnemy : MonoBehaviour
    {
        [SerializeField] public EnemyTypes type;
        [SerializeField] public int scrap;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                GameManager.Instance.IncreaseScrap(scrap);
                this.gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }
}