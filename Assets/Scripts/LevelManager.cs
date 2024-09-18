using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private TMP_Text txtQuestion;
    [SerializeField] private string answer;

    [Header("Objects")] [SerializeField] private List<TMP_Text> gameTxtLetters;
    [SerializeField] private GameObject[] mistakeGameObjects;
    [SerializeField] private GameObject[] letterSpaces;
    [SerializeField] private Slider timeSlider;

    [Header("Sounds")] [SerializeField] private AudioClip correctAnswerSound;
    [SerializeField] private AudioClip errorAnswerSound;

    [Header("Game Configs")] private int points = 0;
    private int currentMistakes = 0;
    [SerializeField] private float maxTime;
    private float remainingTime;
    private float totalLevelTimePlayed = 0;
    private bool isGameOver = false;
    private bool isProcessingKey = false;
    private TouchScreenKeyboard keyboard;
    private bool isLevelLoaded = false;

    private void Start()
    {
        GameManager.Instance.GetCurrentLevelManager(this);
        isGameOver = false;
        remainingTime = maxTime;
        currentMistakes = 0;
        timeSlider.maxValue = maxTime;
        SetQuestionAndAnswer();
        ActivateNecessaryLetters(answer);
        isLevelLoaded = true;
        ShowKeyboard();
    }

    private void Update()
    {
        if (isLevelLoaded)
        {
            totalLevelTimePlayed += Time.deltaTime;
            // Check win
            if (CheckWin())
            {
                AudioManager.Instance.PlaySoundEffect(correctAnswerSound);
                GameManager.Instance.AddError(currentMistakes);
                GameManager.Instance.AddTimePlayed(totalLevelTimePlayed);
                GameManager.Instance.AddLevelCorrectlyCompleted(1);
                GameManager.Instance.LoadNextLevel();
                GameManager.Instance.AddPoints(points);
                CleanScene();
                LoadNextLevel();
            }

            // To control the timer
            if (remainingTime >= 0)
            {
                remainingTime -= Time.deltaTime;
                timeSlider.value = remainingTime;
            }
            else
            {
                isGameOver = true;
                GameManager.Instance.AddTimePlayed(totalLevelTimePlayed);
                if (currentMistakes == 0)
                {
                    AddEmptyLettersAsMistakes();
                }

                GameManager.Instance.AddError(currentMistakes);
                GameManager.Instance.LoadNextLevel();
                GameManager.Instance.AddPoints(points);
                CleanScene();
                LoadNextLevel();
            }

            // Gaming mode
            if (!isGameOver)
            {
                if (GameManager.Instance.GetDeviceType() == DeviceType.PC)
                {
                    GetPressedLetter();
                }
                else if (GameManager.Instance.GetDeviceType() == DeviceType.MOBILE)
                {
                    CheckForTouchInput();
                }
            }

            if (currentMistakes == 7)
            {
                GameManager.Instance.AddError(currentMistakes);
                GameManager.Instance.AddTimePlayed(totalLevelTimePlayed);
                GameManager.Instance.LoadNextLevel();
                GameManager.Instance.AddPoints(points);
                CleanScene();
                LoadNextLevel();
            }
        }
    }

    private void AddEmptyLettersAsMistakes()
    {
        for (int i = 0; i < answer.Length; i++)
        {
            if (gameTxtLetters[i].gameObject.activeSelf == false)
            {
                currentMistakes += 1;
            }
        }
    }

    private void LoadNextLevel()
    {
        SetQuestionAndAnswer();
        ActivateNecessaryLetters(answer);
    }

    private void ShowKeyboard()
    {
        TouchScreenKeyboard.hideInput = true;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    private void SetQuestionAndAnswer()
    {
        Question question = GameManager.Instance.RequestQuestion();
        txtQuestion.text = question.questionText;
        answer = question.questionAnswer;
    }

    private void GetPressedLetter()
    {
        if (isProcessingKey || !Input.anyKeyDown || string.IsNullOrEmpty(Input.inputString))
        {
            return;
        }

        isProcessingKey = true;

        string letterToLower = Input.inputString.ToLower();
        char pressedLetter = letterToLower[0];
        ProcessLetter(pressedLetter);

        isProcessingKey = false;
    }

    private void ProcessLetter(char pressedLetter)
    {
        if (CheckLetter(pressedLetter))
        {
            FillGameText(pressedLetter);
        }
        else
        {
            currentMistakes += 1;
            AudioManager.Instance.PlaySoundEffect(errorAnswerSound);
            ActivateMistakeImages();
        }
    }

    private bool CheckLetter(char letter)
    {
        string fixedLetter = answer.ToLower();
        return fixedLetter.Contains(letter);
    }

    private void FillGameText(char letterToActive)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            char letterToLower = gameTxtLetters[i].text.ToLower()[0];
            if (letterToLower == letterToActive)
            {
                gameTxtLetters[i].gameObject.SetActive(true);
                points += 5;
            }
        }
    }

    private void ActivateMistakeImages()
    {
        foreach (GameObject mistakeImage in mistakeGameObjects)
        {
            if (!mistakeImage.gameObject.activeSelf)
            {
                mistakeImage.gameObject.SetActive(true);
                return;
            }
        }
    }

    private bool CheckWin()
    {
        for (int i = 0; i < answer.Length; i++)
        {
            if (!gameTxtLetters[i].gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }

    private void CleanScene()
    {
        // Clean the question and hide the letters
        txtQuestion.text = "";
        foreach (TMP_Text txtPro in gameTxtLetters)
        {
            txtPro.text = "";
            txtPro.gameObject.SetActive(false);
        }

        // Hide the mistakes images
        foreach (GameObject mistakeImage in mistakeGameObjects)
        {
            mistakeImage.SetActive(false);
        }

        // Reset the letter spaces
        foreach (GameObject letterSpace in letterSpaces)
        {
            letterSpace.SetActive(false);
        }

        // Reset the timer
        remainingTime = maxTime;
        totalLevelTimePlayed = 0f;
        currentMistakes = 0;
        timeSlider.value = remainingTime;
        isGameOver = false;
        points = 0;
    }

    private void ActivateNecessaryLetters(string levelLetter)
    {
        int amountToActivate = levelLetter.Length;
        
        for (int i = 0; i < amountToActivate; i++)
        {
            if (!letterSpaces[i].activeSelf)
            {
                letterSpaces[i].SetActive(true);

                TMP_Text currentTxt = letterSpaces[i].GetComponent<LetterController>().txt_Letter;
                currentTxt.text = levelLetter[i].ToString().ToUpper();
            }
        }
    }

    private void CheckForTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
        }

        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Visible)
        {
            string inputString = keyboard.text;
            if (!string.IsNullOrEmpty(inputString))
            {
                char pressedLetter = inputString.ToLower()[0]; // Process only the first character
                ProcessLetter(pressedLetter);
                keyboard.text = ""; // Clear the keyboard text after processing
            }
        }
    }
}