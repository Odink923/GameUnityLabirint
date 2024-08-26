using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Отримання вводу від користувача
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Рух вправо-вліво по глобальній осі X
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        // Застосування руху у глобальних координатах
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
