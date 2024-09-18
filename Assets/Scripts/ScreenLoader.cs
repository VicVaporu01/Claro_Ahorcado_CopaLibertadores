using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    private DeviceType deviceType;
    public static ScreenLoader Instance { get; private set; }

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
        
        // Set the device type
        if (Application.isMobilePlatform)
        {
            deviceType = DeviceType.MOBILE;
        }
        else
        {
            deviceType = DeviceType.PC;
        }
    }

    private void Start()
    {
        // Load the menus based on the device type
        LoadMenuBasedOnDevice();
    }
    
    public void LoadMenuBasedOnDevice()
    {
        if (deviceType == DeviceType.PC)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (deviceType == DeviceType.MOBILE)
        {
            SceneManager.LoadScene("MainMenuMobile");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    public DeviceType GetDeviceType()
    {
        return deviceType;
    }
}
