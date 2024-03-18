using TowerConfig;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public static StartUp Instance;

    public ModelConfig modelConfig;
    public GameplayConfig GameplayConfig;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        WindowController.Instance.OpenWindow(Windows.MainWindow);
    }
}