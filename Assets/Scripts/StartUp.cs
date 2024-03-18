using TowerConfig;
using Towers;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    public static StartUp Instance;

    public ModelConfig modelConfig;
    public GameplayConfig GameplayConfig;

    //    public TowersController TowersController = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        WindowController.Instance.OpenWindow(Windows.MainWindow);
    }
}