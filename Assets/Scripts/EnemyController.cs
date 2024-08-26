using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; // Швидкість руху моба
    private Vector2 initialPosition; // Початкова позиція моба
    private Vector2 targetPosition; // Цільова позиція моба
    private bool movingForward = true; // Рух вперед або назад

    void Start()
    {
        initialPosition = transform.position;
        SetRandomTargetPosition();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Рух моба до цільової позиції
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Якщо моб досягає цільової позиції, змінюємо напрямок руху
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingForward = !movingForward;
            targetPosition = movingForward ? initialPosition : SetRandomTargetPosition();
        }
    }

    Vector2 SetRandomTargetPosition()
    {
        // Встановлює випадкову цільову позицію в межах лабіринту
        float randomX = initialPosition.x + Random.Range(-5f, 5f);
        float randomY = initialPosition.y + Random.Range(-5f, 5f);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Перезапустити рівень при зіткненні з гравцем
            MazeGenerator mazeGenerator = FindObjectOfType<MazeGenerator>();
            if (mazeGenerator != null)
            {
                mazeGenerator.GenerateAndDrawMaze();
            }
        }
    }
}
