using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using UnityEngine.UI;
using TMPro;
using System;

public class UserModel
{
    // ����� �⺻����

    public String userName; // ����� �̸�(�г���)
    public String uid; // ���� �����(�α�����)
                       //    public String pushToken;

}

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
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            FirebaseApp app = FirebaseApp.DefaultInstance;

        });
    }

}