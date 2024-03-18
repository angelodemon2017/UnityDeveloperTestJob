using UnityEngine;

public class WindowController : MonoBehaviour
{
    public static WindowController Instance;

    [SerializeField] private Transform _parentWindow;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenWindow(Windows type)
    {
        _parentWindow.DestroyChildrens();

        Instantiate(StartUp.Instance.modelConfig.GetWindow(type), _parentWindow);
    }
}