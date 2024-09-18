using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cedulaText;
    [SerializeField] private GameObject registerPanel;
    [SerializeField] private GameObject playPanel;

    public string identificationCard;

    public PlayerData playerData = new PlayerData();

    public static PlayerDataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SaveData()
    {
        identificationCard = GameManager.Instance.GetCedula();
        PlayerData playerData = new PlayerData()
        {
            identificationCard = this.identificationCard,
            points = GameManager.Instance.GetPoints().ToString(),
            time = GameManager.Instance.GetTotalTimePlayed(),
            failures = GameManager.Instance.GetTotalErrors().ToString(),
            correct = GameManager.Instance.GetLevelsCompleted().ToString(),
        };

        string json = JsonUtility.ToJson(playerData, true);

        StartCoroutine(SendDataToAPI(json));
    }

    public IEnumerator SendDataToAPI(string json)
    {
        // Deserialize the JSON string to a PlayerData object
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

        // Construct the URL with query parameters Claro
        // string url =
        //     $"https://apirevenge.softsaenz.com.co/api/auth/recordPoints?identificationCard={playerData.identificationCard}&points={playerData.points}&time={playerData.time}&failures={playerData.failures}&correct={playerData.correct}";
        
        //New Client
        string url =
            $"https://apiregister.softsaenz.com.co/api/auth/recordPoints?identificationCard={playerData.identificationCard}&points={playerData.points}&time={playerData.time}&failures={playerData.failures}&correct={playerData.correct}";
        
        using (UnityWebRequest request = new UnityWebRequest(url, "GET"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error al enviar datos: " + request.error);
            }
            else
            {
                // Parse the JSON response to extract the player's name
                string jsonResponse = request.downloadHandler.text;
                ApiResponse apiResponse = JsonUtility.FromJson<ApiResponse>(jsonResponse);

                // Store the player's name
                string playerName = apiResponse.name;
                GameManager.Instance.SetPlayerName(playerName);
            }
        }
    }
}

[Serializable]
public class ApiResponse
{
    public int id;
    public int points;
    public string name;
    public long telephone;
}