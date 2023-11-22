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
            string userId = "사용자 고유 식별자 (예: Firebase 인증 UID)";
            string newNickname = nicknameInput.text;

            reference.Child("users").Child(userId).Child("nickname").SetValueAsync(newNickname).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("닉네임이 업데이트되었습니다: " + newNickname);
                }
                else
                {
                    Debug.Log("닉네임 업데이트에 실패했습니다.");
                }
            });
        }
    }

    public void LoadNickname()
    {
        if (reference != null)
        {
            string userId = "사용자 고유 식별자 (예: Firebase 인증 UID)";
            reference.Child("users").Child(userId).Child("nickname").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    string nickname = snapshot.Value.ToString();
                    Debug.Log("닉네임: " + nickname);
                }
                else
                {
                    Debug.Log("닉네임 불러오기에 실패했습니다.");
                }
            });
        }
    }
}