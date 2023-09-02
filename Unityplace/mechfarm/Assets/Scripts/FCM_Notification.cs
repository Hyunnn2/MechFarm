using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Messaging;
using UnityEngine;

public class PushNotificationManager : MonoBehaviour
{
    private void Start()
    {
        // Firebase �ʱ�ȭ
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
        });

        // FCM �޽��� ���� �̺�Ʈ �ڵ鷯 ���
        FirebaseMessaging.TokenReceived += OnTokenReceived;
        FirebaseMessaging.MessageReceived += OnMessageReceived;
    }

    // Ǫ�� �˸��� ������ �Լ�
    public void SendPushNotification(string title, string body)
    {
        // Ǫ�� �˸� �޽��� ����
        var message = new Message()
        {
            Notification = new Notification()
            {
                Title = title,
                Body = body
            },
            Token = "����̽� Ǫ�� ��ū" // ����̽��� Ǫ�� ��ū�� ���⿡ �Է�
        };

        // FCM ������ �޽��� ������
        FirebaseMessaging.SendAsync(message);
    }

    // FCM ��ū ���� �̺�Ʈ �ڵ鷯
    private void OnTokenReceived(object sender, TokenReceivedEventArgs tokenArgs)
    {
        string token = tokenArgs.Token;
        Debug.Log("Ǫ�� �˸� ��ū: " + token);
    }

    // FCM �޽��� ���� �̺�Ʈ �ڵ鷯
    private void OnMessageReceived(object sender, MessageReceivedEventArgs messageArgs)
    {
        var notification = messageArgs.Message.Notification;
        Debug.Log("Ǫ�� �˸� ���� - ����: " + notification.Title + ", ����: " + notification.Body);
    }
}

