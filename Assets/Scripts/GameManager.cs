using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("Level Configs")] [SerializeField]
    private DeviceType deviceType;

    [SerializeField] private int currentLevel = 0;
    [SerializeField] private LevelManager currentLevelManager;
    [SerializeField] private List<Question> questionsToUse = new List<Question>();
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text txtNumCedula;
    [SerializeField] private TMP_Text txtNumCedulaHolder;

    [SerializeField] private string identificationCard;
    [SerializeField] private int points = 0;
    [SerializeField] private float totalTimePlayed = 0;
    [SerializeField] private int totalErrors = 0;
    [SerializeField] private float timeToPlay = 120f;
    [SerializeField] private int levelsCorrectlyCompleted = 0;
    private string playerName = "";
    private bool isFirstLoad = true;
    private TouchScreenKeyboard keyboard;
    private string palabraGuardada;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        // Configurar el TMP_InputField para aceptar solo números enteros
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        inputField.onSelect.AddListener((_) => OnInputFieldSelected());
    }

    private void Update()
    {
        if (deviceType == DeviceType.MOBILE && SceneManager.GetActiveScene().name == "MainMenuMobile")
        {
            CheckForTouchInput();
        }

        // Sincronizar txtNumCedula con el valor del inputField solo si ambos aún existen
        if (txtNumCedula != null && inputField != null)
        {
            txtNumCedula.text = inputField.text;
            txtNumCedula.ForceMeshUpdate(); // Forzar actualización del texto
            Canvas.ForceUpdateCanvases(); // Forzar actualización del canvas
        }
    }

    private void CheckForTouchInput()
    {
        if (keyboard != null && keyboard.active)
        {
            palabraGuardada = keyboard.text;

            if (!string.IsNullOrEmpty(palabraGuardada))
            {
                string sanitizedInput = Regex.Replace(palabraGuardada, "[^0-9]", "");
                inputField.text = sanitizedInput;
                inputField.ForceLabelUpdate(); // Forzar actualización del texto
                Canvas.ForceUpdateCanvases(); // Forzar actualización del canvas
            }

            if (keyboard.status == TouchScreenKeyboard.Status.Done)
            {
                txtNumCedulaHolder.gameObject.SetActive(false);
                keyboard = null; // Detener la revisión una vez que esté hecho
            }
        }
    }

    private void OnInputFieldSelected()
    {
        if (deviceType == DeviceType.MOBILE)
        {
            TouchScreenKeyboard.hideInput = true;
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);

            // Forzar la ocultación del cuadro de entrada
            inputField.readOnly = true;
            StartCoroutine(ReenableInputField());
        }
    }

    private IEnumerator ReenableInputField()
    {
        yield return new WaitForSeconds(0.1f); // Esperar un breve momento para permitir que el teclado se abra
        inputField.readOnly = false;
    }

    public void LoadNextLevel()
    {
        if (isFirstLoad)
        {
            string sanitizedInput = Regex.Replace(txtNumCedula.text, "[^0-9]", "");

            if (long.TryParse(sanitizedInput, out long parsedCedula))
            {
                identificationCard = parsedCedula.ToString();
                if (CheckIdentificationCard(identificationCard))
                {
                    // Cargar la escena basada en el tipo de dispositivo
                    if (deviceType == DeviceType.PC)
                    {
                        SceneManager.LoadScene("Level 1");
                        currentLevel++;
                        isFirstLoad = false;
                    }
                    else if (deviceType == DeviceType.MOBILE)
                    {
                        SceneManager.LoadScene("Level 1 Mobile");
                        currentLevel++;
                        isFirstLoad = false;
                    }
                }
                else
                {
                    // Clean the input field and show an error message
                    Debug.LogError("La cédula ingresada no es válida: " + sanitizedInput);
                    txtNumCedula.text = "";
                }
            }
            else
            {
                Debug.LogError("La conversión de txtNumCedula a long ha fallado después de la limpieza: " +
                               sanitizedInput);
            }
        }

        if (currentLevel < 20 && totalTimePlayed <= timeToPlay)
        {
            currentLevel++;
        }
        else
        {
            // Cargar la escena de ranking
            string sceneName = deviceType == DeviceType.PC ? "RankingScene" : "RankingSceneMobile";
            SceneManager.LoadScene(sceneName);
            PlayerDataManager.Instance.SaveData();
        }
    }

    private bool CheckIdentificationCard(string idCard)
    {
        // Allow the identification card only for lengths of 7 to 10 numbers
        return idCard.Length >= 7 && idCard.Length <= 10;
    }

    public void GetCurrentLevelManager(LevelManager levelManager)
    {
        currentLevelManager = levelManager;
    }

    public void PrepareQuestions(List<Question> questionsList)
    {
        questionsToUse = questionsList;
    }

    public Question RequestQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questionsToUse.Count);
        Question question = questionsToUse[randomQuestionIndex];
        questionsToUse.RemoveAt(randomQuestionIndex);
        return question;
    }

    public void AddError(int errorsToAdd)
    {
        totalErrors += errorsToAdd;
    }

    public int GetTotalErrors()
    {
        return totalErrors;
    }

    public string GetCedula()
    {
        return identificationCard;
    }

    public void AddTimePlayed(float timeToAdd)
    {
        totalTimePlayed += timeToAdd;
    }

    public string GetTotalTimePlayed()
    {
        int minutes = (int)totalTimePlayed / 60;
        int seconds = (int)totalTimePlayed % 60;
        int milliseconds = (int)((totalTimePlayed - (int)totalTimePlayed) * 1000);

        string timeFormatted = $"{minutes:D2}:{seconds:D2}:{milliseconds:D3}";

        return timeFormatted;
    }

    public int GetLevelsCompleted()
    {
        return levelsCorrectlyCompleted;
    }

    public void AddLevelCorrectlyCompleted(int amountToAdd)
    {
        levelsCorrectlyCompleted += amountToAdd;
    }

    public DeviceType GetDeviceType()
    {
        return deviceType;
    }

    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }
}

public enum DeviceType
{
    PC,
    MOBILE
}