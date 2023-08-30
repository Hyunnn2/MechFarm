using UnityEngine;
using System;
using Assets.SimpleAndroidNotifications;

public class NotifyManager : MonoBehaviour
{
    private int tempValue;  // �µ� �����κ��� �޴� �� (����)

    private void OnApplicationPause(bool isPause)
    {


        // Remove all registered notifications
        NotificationManager.CancelAll();
        TimeSpan delay = TimeSpan.FromSeconds(5);
        if (isPause)
        {
            Debug.LogWarning("call NotificationManager");

            // Check if the temperature value exceeds 50
            if (tempValue > 50)
            {
                // Send a notification about high temperature
                NotificationManager.SendWithAppIcon(delay,
                    "�µ��� �ʹ� ���ƿ�",  // Title: �µ��� �ʹ� ���ƿ�
                    "�µ��� ���� 50�� �ʰ��Ͽ����ϴ�.",  // Message: �µ��� ���� 50�� �ʰ��Ͽ����ϴ�.
                    Color.red,  // Color: ������
                    NotificationIcon.Heart  // Icon: ��Ʈ ������
                );
            }
        }
    }
}
