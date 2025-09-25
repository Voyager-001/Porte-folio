using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class SimpleHostClientUI : MonoBehaviour
{
    public Button hostBtn, clientBtn;

    void Start()
    {
        if (hostBtn)
            hostBtn.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        if (clientBtn)
            clientBtn.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }
}