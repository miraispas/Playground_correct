using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : NetworkBehaviour
{
    CharacterController characterController;
    Vector3 movement;
    [SerializeField] float speed = 1.0f;

    Material playerMaterial;

    NetworkVariable<Color> characterColor = new NetworkVariable<Color>(new Color(255, 0, 0));

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();  
        playerMaterial = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        movement = new Vector3(1, 0, 1);
    }
    public override void OnNetworkSpawn()
    { 
        characterColor.OnValueChanged += OnColorChange;
        if (IsServer)
        {
            characterColor.Value = RandomColor();
        }
        playerMaterial.color = characterColor.Value;
        //if (IsOwner) ColorClientRPC();
    }
    void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (IsOwner) ColorServerRPC();
    }
    void OnColorChange(Color oldColor, Color newColor)
    {
        print("This was the oldcolor: " + oldColor + " and this was the newColor" + newColor);
        ColorClientRPC(newColor);

    }

    [ClientRpc]
    void ColorClientRPC(Color newColor)
    {
        playerMaterial.color = newColor;
    }

    [ServerRpc]
    void ColorServerRPC()
    {
        //ColorClientRPC(RandomColor());
        if (IsServer) characterColor.Value = RandomColor();
    }
    private void Update()
    {   
        if(IsOwner == false) return;    

        characterController.Move(new Vector3(movement.x, 0.0f, movement.y) * speed * Time.deltaTime);
    }

    Color RandomColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        return new Color(r, g, b);
    }
}
