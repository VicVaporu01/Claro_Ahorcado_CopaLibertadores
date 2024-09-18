using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private PlayerBoxController playerBoxPrefab;

    private void Start()
    {
        playerBoxPrefab.txtPlayerName.text = GameManager.Instance.GetPlayerName();
        playerBoxPrefab.txtPlayerPosition.text = "";
        playerBoxPrefab.txtPlayerStatistics.text =
            "Ahorcados Acertados: " + GameManager.Instance.GetLevelsCompleted().ToString()
                                    + "\nTiempo: " + GameManager.Instance.GetTotalTimePlayed()
                                    + "\nErrores: " + GameManager.Instance.GetTotalErrors().ToString();
        playerBoxPrefab.txtPlayerScore.text = GameManager.Instance.GetPoints().ToString() + " pts";
    }
}