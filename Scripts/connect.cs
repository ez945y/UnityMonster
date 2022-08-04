using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System;
using Lib;


public class connect : MonoBehaviour
{
    public SQLiteConnection Connection;
    public SqliteBase sb;
    // Start is called before the first frame update
    void Start()
    {
        //Connection = new SQLitedConnection(Application.streamingAssetsPath + "/TestDatabase.db", SQLiteOpenFlags.ReadWrite);
        
        sb = new SqliteBase();

        var s = new Stores
        {
            Store_Name = "³Á·í³Ò",
            Email = "MC@gmail.com",
            Phone = "0965782459",
            Type = "­¹«~"
        };


        sb.Create_Table(2);
        sb.InsertData(s);
        sb.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
