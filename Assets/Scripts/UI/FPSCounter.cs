using UnityEngine;

namespace HackedDesign.UI
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Text fpsText;

        void Update()
        {
            if (GameManager.Instance.GameData.showFPS)
            {
                float fps = 1 / Time.unscaledDeltaTime;
                fpsText.text = "" + fps.ToString("N0");
            }
            else if(fpsText.text != "")
            {
                fpsText.text = "";
            }
        }
    }
}