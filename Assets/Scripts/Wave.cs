using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    [CreateAssetMenu(fileName = "Wave", menuName = "State/Wave")]
    public class Wave : ScriptableObject
    {
        public List<Enemy> enemies;
    }
}