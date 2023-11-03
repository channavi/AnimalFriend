using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using UnityEngine.UI;
using TMPro;
using System;

public class FirebaseManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nicknameInput;

    private DatabaseReference reference;

    public void Awake()
    {
        AppOptions options = new AppOptions { DatabaseUrl = new Uri("https://animalfreindserver-default-rtdb.firebaseio.com/")};
        FirebaseApp app = FirebaseApp.Create (options);
        reference = FirebaseDatabase.DefaultInstance.GetReference("rank");
    }
    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        });
    }

    public void SetNickname()
    {
        if (reference != null)
        {
            string userId = "����� ���� �ĺ��� (��: Firebase ���� UID)";
            string newNickname = nicknameInput.text;

            reference.Child("users").Child(userId).Child("nickname").SetValueAsync(newNickname).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("�г����� ������Ʈ�Ǿ����ϴ�: " + newNickname);
                }
                else
                {
                    Debug.Log("�г��� ������Ʈ�� �����߽��ϴ�.");
                }
            });
        }
    }

    public void LoadNickname()
    {
        if (reference != null)
        {
            string userId = "����� ���� �ĺ��� (��: Firebase ���� UID)";
            reference.Child("users").Child(userId).Child("nickname").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    string nickname = snapshot.Value.ToString();
                    Debug.Log("�г���: " + nickname);
                }
                else
                {
                    Debug.Log("�г��� �ҷ����⿡ �����߽��ϴ�.");
                }
            });
        }
    }
}