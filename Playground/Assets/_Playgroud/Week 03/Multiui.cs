using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UIElements;

public class Multiui : MonoBehaviour
{
    UIDocument uiDocument;
    Button disconnectButton;
    TextField ipTextField;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
        Button hostButton = uiDocument.rootVisualElement.Q<Button>("HostButton");
        Button serverButton = uiDocument.rootVisualElement.Q<Button>("ServerButton");
        Button clientButton = uiDocument.rootVisualElement.Q<Button>("ClientButton");
        Button disconnectButton = uiDocument.rootVisualElement.Q<Button>("DisconnectButton");
        ipTextField = uiDocument.rootVisualElement.Q<TextField>("IPAddressTextField");

        hostButton.clicked += OnHostClicked;
        serverButton.clicked += OnServerClicked;
        clientButton.clicked += OnClientClicked;
        disconnectButton.clicked += OnDisconnectClicked;

        //disconnectButton.SetEnabled(false); 
        ipTextField.focusable = true;

    }

    void OnDisconnectClicked()
    {
        ipTextField.focusable = true;
        NetworkManager.Singleton.Shutdown();
    }

    void OnHostClicked()
    {
        ipTextField.focusable = false;
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipTextField.value, 7777);

        NetworkManager.Singleton.StartHost();
        //disconnectButton.SetEnabled(true);
    }

    void OnServerClicked()
    {
        ipTextField.focusable = false;
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipTextField.value, 7777);
        NetworkManager.Singleton.StartServer();
        //disconnectButton.SetEnabled(true);
    }

    void OnClientClicked()
    {
        ipTextField.focusable = false;
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipTextField.value, 7777);
        NetworkManager.Singleton.StartClient();
        //disconnectButton.SetEnabled(true);
    }
}
