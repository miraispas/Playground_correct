using Unity.Netcode;
using UnityEngine;

public class TriggerCubeInteraction : NetworkBehaviour
{   
    NetworkVariable<Color>cubeColor = new NetworkVariable<Color>(new Color(255, 0, 0));
    Material cubeMaterial;

    private void Awake()
    {
        cubeMaterial = GetComponent<Renderer>().material;
    }

    public override void OnNetworkSpawn()
    {
        cubeColor.OnValueChanged += OnColorChange;
        cubeMaterial.color = cubeColor.Value;   
    }

    void OnColorChange(Color oldColor, Color newColor)
    {
        cubeMaterial.color = newColor;
    }
}
