using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public float hydrationLevel = 100.0f; // �ʱ� ���� ����
    public float hydrationThreshold = 30.0f; // ���� ���� �Ӱ�ġ
    public float hydrationDecreaseRate = 1.0f; // ���� ���� �ӵ� (��: �ʴ� 1�� ����)

    private PushNotificationManager notificationManager;

    private void Start()
    {
        notificationManager = GetComponent<PushNotificationManager>();
        InvokeRepeating("DecreaseHydration", 1.0f, 1.0f); // 1�ʸ��� ���� ����
    }

    private void DecreaseHydration()
    {
        // ������ �ֱ������� ���ҽ�Ŵ
        hydrationLevel -= hydrationDecreaseRate;

        // ������ ������ ��� Ǫ�� �˸��� ����
        if (hydrationLevel < hydrationThreshold)
        {
            SendHydrationNotification();
        }
    }

    private void SendHydrationNotification()
    {
        string title = "����: ���� ����!";
        string body = "ĳ������ ������ �����մϴ�. ���� �����ּ���.";

        // Ǫ�� �˸��� ����
        notificationManager.SendPushNotification(title, body);
    }
}

