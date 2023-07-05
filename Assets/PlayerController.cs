using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed = 1.0f;
    Camera _mainCamera;

    private void Initialize()
    {
        _mainCamera = Camera.main;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialize();
    }

    void Update()
    {
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mouseToWorld = _mainCamera.ScreenToWorldPoint(mouseScreenPos);
        transform.position = Vector3.MoveTowards(transform.position, mouseToWorld, Time.deltaTime * speed);
    }
}
