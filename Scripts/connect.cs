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

        //var b = new Bags
        //{
        //    User_Id = 1,
        //    Coupon_Id = 2,
        //};

        //sb.SelectBag(1);

        var u = new Users
        {
            Name = "柏賢",
            City = "新北市",   
            District = "板橋區",
            Score1 = 100,
            Score2 = 30,
            Img_Id =0,
            Email ="gg@gmail.com",
            Password = "123456",
            Gender = "M",
            Birthday = DateTime.Parse("2001/12/16"),
            Phone = "0965465165",
            
        };


        
        sb.InsertData(u);
        sb.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
