using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity;

public class DataSave : MonoBehaviour
{
    public class User
    {
        public string username;
        public string email;
        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void OnClickSave()
    {
        writeNewUser("personal information", "googleman", "googli@google.com");
    }
    
    private void writeNewUser(string userId, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);
        reference.Child(userId).SetRawJsonValueAsync(json);
    }
    void Update()
    {
        
    }
}
