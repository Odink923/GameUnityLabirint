using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator; // Додайте це поле
   public bool isDead = false;
    void Start()
    {
        animator = GetComponent<Animator>(); // Ініціалізуйте компонент Animator
    }

  void Update()
{
    
    // Отримання вводу від користувача
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    // Рух вправо-вліво по глобальній осі X
    Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
    transform.Translate(movement * speed * Time.deltaTime, Space.World);
animator.SetFloat("Speed", movement.magnitude);
    // Інверсія анімації при русі вліво/вправо
    if (moveHorizontal < 0)
    {
        transform.localScale = new Vector3(-0.08f, 0.08f, 1); // Повертаємо персонажа вліво
    }
    else if (moveHorizontal > 0)
    {
        transform.localScale = new Vector3(0.08f, 0.08f, 1); // Повертаємо персонажа вправо
    }
}
  public void Die()
    {
     if (!isDead) // Переконайтесь, що це перевіряється
    {
      
        isDead = true;
        animator.SetTrigger("Die");
        DeathCounter deathCounter = FindObjectOfType<DeathCounter>();
        if (deathCounter != null)
        {
            deathCounter.IncrementDeathCount();
        }
        Invoke("RestartLevel", 0.7f);
        
    }
    }

void RestartLevel()
{
    Debug.Log("Restarting level...");
    isDead = false;
    animator.ResetTrigger("Die");
    animator.Play("Culm");
    animator.SetFloat("Speed", 0);
    MazeGenerator mazeGenerator = FindObjectOfType<MazeGenerator>();
    if (mazeGenerator != null)
    {
        mazeGenerator.GenerateAndDrawMaze();
    }
    Debug.Log("Level restarted successfully.");
}




}
