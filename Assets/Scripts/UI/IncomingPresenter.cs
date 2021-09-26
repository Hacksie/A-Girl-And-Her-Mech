using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign.UI
{
    public class IncomingPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Text countdownText; 
        public override void Repaint()
        {
            countdownText.text = Mathf.CeilToInt(GameManager.Instance.GameData.incomingTimer).ToString("N0");
        }
    }
}