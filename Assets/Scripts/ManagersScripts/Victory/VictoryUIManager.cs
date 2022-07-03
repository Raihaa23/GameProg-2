using TMPro;
using UnityEngine;

namespace ManagersScripts.Victory
{
    public class VictoryUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject victoryScreen;
        [SerializeField] private TextMeshProUGUI victoryMessage;

        public void SetVictoryScreen(string victoryText) // sets the text value in the Victory UI
        {
            victoryScreen.SetActive(true);
            victoryMessage.text = victoryText;
        }
    }
}