using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    // Шлях для зберігання знімків
    private string screenshotPath = "Assets/";

    void Update()
    {
        // Перевіряємо, чи була натиснута клавіша H
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Генеруємо ім'я файлу для знімка
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string screenshotFileName = "Screenshot_" + timestamp + ".png";

            // Знімаємо знімок екрана
            ScreenCapture.CaptureScreenshot(screenshotPath + screenshotFileName);

            // Виводимо повідомлення про успішне збереження
            Debug.Log("Screenshot saved: " + screenshotPath + screenshotFileName);
        }
    }
}
