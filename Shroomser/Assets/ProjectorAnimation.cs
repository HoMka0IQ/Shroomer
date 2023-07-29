using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ProjectorAnimation : MonoBehaviour
{
    DecalProjector thisDecal;
    float width;
    float height;
    public float maxTimeAnim;
    float timer;
    bool isScalingUp;

    void Start()
    {
        thisDecal = GetComponent<DecalProjector>();
        width = thisDecal.size.x;
        height = thisDecal.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        // Збільшуємо або зменшуємо таймер залежно від того, чи об'єкт зараз збільшується чи зменшується
        timer += (isScalingUp ? 1f : -1f) * Time.deltaTime / maxTimeAnim;

        // Перевіряємо, чи закінчився один пульсаційний цикл, і змінюємо напрямок збільшення або зменшення
        if (timer >= 1f)
        {
            timer = 1f;
            isScalingUp = false;
        }
        else if (timer <= 0f)
        {
            timer = 0f;
            isScalingUp = true;
        }

        // Вираховуємо проміжне значення масштабу між мінімальним і максимальним розміром
        float intermediateScaleX = Mathf.Lerp(width, width + ((width / 100) * 10), timer);
        float intermediateScaleY = Mathf.Lerp(height, height + ((height / 100) * 10), timer);
        // Застосовуємо новий розмір до об'єкта
        thisDecal.size = new Vector3(intermediateScaleX, intermediateScaleY, thisDecal.size.z);

    }
}
