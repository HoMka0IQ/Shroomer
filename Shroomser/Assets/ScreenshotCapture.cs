using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    // ���� ��� ��������� �����
    private string screenshotPath = "Assets/";

    void Update()
    {
        // ����������, �� ���� ��������� ������ H
        if (Input.GetKeyDown(KeyCode.H))
        {
            // �������� ��'� ����� ��� �����
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string screenshotFileName = "Screenshot_" + timestamp + ".png";

            // ������ ����� ������
            ScreenCapture.CaptureScreenshot(screenshotPath + screenshotFileName);

            // �������� ����������� ��� ������ ����������
            Debug.Log("Screenshot saved: " + screenshotPath + screenshotFileName);
        }
    }
}
