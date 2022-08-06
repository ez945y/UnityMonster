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

        //sb.Create_Table(0);
        //for (int i = 1; i <= 6; i++)
        //{
        //    var u = new Users
        //    {
        //        Name = "柏賢" + i,
        //        City = "新北市" + i,
        //        District = "板橋區" + i,
        //        Score1 = 100+i*10,
        //        Score2 = 30+i*10,
        //        Img_Id = 0,
        //        Email = "gg@gmail.com+i",
        //        Password = "123456",
        //        Gender = "M",
        //        Birthday = DateTime.Parse("2001/12/16"),
        //        Phone = "0965465165",

        //    };
        //    sb.Sign_Up(u);
        //}

        sb.Leaderboard();
        sb.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
