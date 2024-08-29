using UnityEngine;

public class CameraController : MonoBehaviour
{
      public Transform player;  // Посилання на трансформ гравця
    public float cameraSize = 10f;  // Початковий розмір камери
    public float zoomOutSize = 30f; // Розмір камери при натисканні кнопки
    public KeyCode zoomOutKey = KeyCode.Space; // Клавіша для віддалення камери
    public Vector2 boxSize = new Vector2(5f, 5f); // Розмір боксу
    public float smoothSpeed = 0.125f; // Швидкість плавного переміщення камери

    private Camera mainCamera;
    private Vector3 desiredPosition;


    void Start()
    {
           mainCamera = GetComponent<Camera>();
        mainCamera.orthographicSize = cameraSize;
        desiredPosition = transform.position; // П
    }

  void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.position;
            Vector3 cameraPos = transform.position;

            // Обчислюємо межі боксу
            float leftLimit = cameraPos.x - boxSize.x / 2;
            float rightLimit = cameraPos.x + boxSize.x / 2;
            float bottomLimit = cameraPos.y - boxSize.y / 2;
            float topLimit = cameraPos.y + boxSize.y / 2;

            // Перевіряємо, чи гравець виходить за межі боксу по горизонталі
            if (playerPos.x < leftLimit)
            {
                cameraPos.x = playerPos.x + boxSize.x / 2;
            }
            else if (playerPos.x > rightLimit)
            {
                cameraPos.x = playerPos.x - boxSize.x / 2;
            }

            // Перевіряємо, чи гравець виходить за межі боксу по вертикалі
            if (playerPos.y < bottomLimit)
            {
                cameraPos.y = playerPos.y + boxSize.y / 2;
            }
            else if (playerPos.y > topLimit)
            {
                cameraPos.y = playerPos.y - boxSize.y / 2;
            }

            // Задаємо нову позицію камери
            desiredPosition = cameraPos;

            // Плавний рух камери до нової позиції
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }

        // Зміна розміру камери при натисканні клавіші
        if (Input.GetKey(zoomOutKey))
        {
            mainCamera.orthographicSize = zoomOutSize;
        }
        else
        {
            mainCamera.orthographicSize = cameraSize;
        }
    }
}
