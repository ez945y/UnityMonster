using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System;

namespace Lib{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Img_Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return string.Format("[Person:Id={0},City={1}, District={2}, Score1={3}, Score2={4},Img_Id={5},Email={6},Password={7},Gender={8},Birthday={9}, Phone={10}]", Id,City, District, Score1, Score2,Img_Id,Email,Password,Gender,Birthday, Phone);
        }
    }


    public class Coupons
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Coup_Name { get; set; }

        public int Store_Id { get; set; } //foreign key

        public string Code { get; set; }

        public string Describe { get; set; }

        public int Type { get; set; }

        public override string ToString()
        {
            return string.Format("[Coupon:Id={0},Coup_Name={1},Store_Id={2},Code={3},Describe={4}, Type={5}]", Id, Coup_Name, Store_Id, Code,Describe, Type);
        }

    }

    public class Stores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Store_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("[Store:Id={0},Store_Name={1},Email={2},Phone={3},Type={4}]", Id, Store_Name, Email, Phone, Type);
        }

    }
    public class Bags
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Coupon_Id { get; set; }
        public int Like { get; set; }
        public override string ToString()
        {
            return string.Format("[Bag:Id={0},User_Id={1},Coupon_Id={2},Like={3}]", Id, User_Id, Coupon_Id, Like);
        }

    }
    public class Only
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Store_Name { get; set; }
        public string Coup_Name { get; set; }
        public string Code { get; set; }
        public string Describe { get; set; }
        
        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("[Store:Id={0},Store_Name={1},Coupon_Name={2},Code={3},Describe,Type={4}]", Id, Store_Name, Coup_Name, Code, Describe, Type);
        }
    }


        public class SqliteBase : MonoBehaviour
    {
        public static SQLiteConnection Connection = new SQLiteConnection(Application.streamingAssetsPath + "/TestDatabase.db", SQLiteOpenFlags.ReadWrite);
        public void Sign_Up(Users newRow)
        {
            //var u = new Users
            //{
            //    Name = "柏賢",
            //    City = "新北市",
            //    District = "板橋區",
            //    Score1 = 100,
            //    Score2 = 30,
            //    Img_Id = 0,
            //    Email = "gg@gmail.com",
            //    Password = "123456",
            //    Gender = "M",
            //    Birthday = DateTime.Parse("2001/12/16"),
            //    Phone = "0965465165",

            //};

            try
            {
                Connection.Insert(newRow);
            }
            catch (Exception e) 
            {
                Debug.Log(e);
            }

        }
        public void InsertData(Stores newRow)
        {
            //new Stores
            //{
            //    Store_Name = "麥當勞",
            //    Email = "MC@gmail.com",
            //    Phone = "0965782459",
            //    Type = "食品"
            //};

            try
            {
                Connection.Insert(newRow);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

        }
        public void InsertData(Coupons newRow)
        {
            //var c = new Coupons
            //{
            //    Coup_Name = "冰炫風",
            //    Store_Id = 1,
            //    Code = "NCTC654",
            //    Describe = "加一元多一件"
            //};

            try
            {
                Connection.Insert(newRow);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

        }
        public void InsertData(Bags newRow)
        {
            //var b = new Bags
            //{
            //    User_Id = 1,
            //    Coupon_Id = 1,
            //    Like = 0
            //};

            try
            {
                Connection.Insert(newRow);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

        }
        public void UpDateData()
        {
            var data = Connection.Table<Users>().Where(_ => _.Name == "博勛").FirstOrDefault();
            data.Gender = "F";
            
            try
            {
                Connection.Update(data);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        public void Select(int User_Id)
        {

            var bag = Connection.Table<Bags>().Where(_ => _.User_Id == User_Id);
            int i = 1;
            foreach (var coupon in bag)
            {
                var c = Connection.Table<Coupons>().Where(_ => _.Id == coupon.Coupon_Id).First();
                var s = Connection.Table<Stores>().Where(_ => _.Id == c.Store_Id).First();
                Debug.Log(i + ". " + s.Store_Name +"("+ s.Type+")\n" + c.Coup_Name + ": " + c.Describe + "\n" + "優惠碼: " + c.Code + "\n");
                i++;
            }
        }

        //佔存
        public void SelectCoupon(SQLite4Unity3d.TableQuery<Lib.Bags> bag)
        {
            foreach (var coupon in bag)
            {
                var c = Connection.Table<Coupons>().Where(_ => _.Id == coupon.Coupon_Id).First();
                var s = Connection.Table<Stores>().Where(_ => _.Id == c.Store_Id).First();
            }
        }
        public SQLite4Unity3d.TableQuery<Lib.Bags> SelectBagAll(int User_Id)
        {
            var bag = Connection.Table<Bags>().Where(_ => _.User_Id == User_Id);
            return bag;
        }
        public SQLite4Unity3d.TableQuery<Lib.Bags> SelectBagLike(int User_Id)
        {
            var bag = Connection.Table<Bags>().Where(_ => _.User_Id == User_Id && _.Like == 1);
 
            return bag;
        }
        public Only SelectBagOne(int Bag_Id)
        {
            var bag = Connection.Table<Bags>().Where(_ => _.Id == Bag_Id).First();
            var c = Connection.Table<Coupons>().Where(_ => _.Id == bag.Coupon_Id).First();
            var s = Connection.Table<Stores>().Where(_ => _.Id == c.Store_Id).First();
            var res = new Only
            {
                Id = c.Id,
                Store_Name = s.Store_Name,
                Coup_Name = c.Coup_Name,
                Code = c.Code,
                Describe = c.Describe,
                Type = s.Type
            };
            return res;
        }

        public void Leaderboard(int User_Id)
        {

            var u = Connection.Table<Users>();
            List<int> scores = new List<int>();

            foreach (var row in u)
            {
                scores.Add(row.Score1);
            }

            scores.Sort();
            scores.Reverse();

           
            if(scores.Count < 5)
            {    
                for (int i = 0; i < scores.Count; i++)
                {
                    Debug.Log(i+1 + ". " + u.Where(_=>_.Score1==scores[i]).First().Name + " : " + scores[i]);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Debug.Log(i+1 + ". " + u.Where(_ => _.Score1 == scores[i]).First().Name + " : " + scores[i]);
                }
            }

            

            Debug.Log("Your score: " + u.Where(_ => _.Id == User_Id).First());
                       

        }


        public void DeleteData()
        {
            var data = Connection.Table<Users>().Where(_ => _.Id == 3 && _.Gender == "F").FirstOrDefault();
            
            try
            {
                Connection.Delete(data);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }


        }

        public void Close()
        {
            Connection.Close();
        }

        public void Create_Table(int table_index)
        {

            string[] tableNames = new string []{ "Users","Coupons","Stores","Bags"};

            if (tableNames[table_index] =="Users")
            {

                Connection.CreateTable<Users>();

            } else if (tableNames[table_index] == "Coupons")
            {
                Connection.CreateTable<Coupons>();

            } else if (tableNames[table_index] == "Stores")
            {
                Connection.CreateTable<Stores>();
            }
            else if (tableNames[table_index] == "Bags")
            {
                Connection.CreateTable<Bags>();

            } else {

                Debug.Log("請輸入0~3");
            }
        }

        public Users user_Information(int user_Id)
        {
            var user = Connection.Table<Users>().Where(_ => _.Id == user_Id).First();

            return user;
        }
        public int log_In(string Email, string PassWord )
        {
            var email = Connection.Table<Users>().Where(_ => _.Email == Email).First();
            int user_id = 777;
            if (email.Password == PassWord)
            {
                user_id = Connection.Table<Users>().Where(_ => _.Email == Email).First().Id;
            }

            return user_id;
        }
        public int Insert_Coupon(int user_Id)
        {
            System.Random rd = new System.Random();
            var num = Connection.Table<Coupons>().Count();
            int ranNum = rd.Next(0, num);
            var b = new Bags
            {
                User_Id = user_Id,
                Coupon_Id = ranNum,
                Like = 0
            };

            try
            {
                Connection.Insert(b);
                return Connection.Table<Coupons>().Where(_ => _.Id == ranNum).First().Type;

            }
            catch (Exception e)
            {
                Debug.Log(e);
                return -999;
            }
        }
        public void User_Change(Users oldRow)
        {

            try
            {
                Connection.Update(oldRow);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

        }

        public void Leaderboard()
        {

            var query = ("SELECT City,District,Name,Score1 FROM Users ORDER BY Score1 DESC");
            var data = new object[] { "City", "District", "Name", "Score1" };
            var cmd = Connection.Query(new TableMapping(typeof(Users)), query, data);
            for (int i = 0; i < 5; i++)
            {
                Debug.Log(cmd[i]);
            }
        }

    }
}