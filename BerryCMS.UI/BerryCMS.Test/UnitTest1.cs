using System;
using System.Collections.Generic;
using System.Diagnostics;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Code;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Service;
using BerryCMS.Service.BaseManage;
using BerryCMS.Utils;
using BerryCMS.Utils.Stopwatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerryCMS.Test
{
    [TestClass]
    public class UnitTest1 : BaseStopwatch
    {
        //private UserService userService = new UserService();
        private UserBLL UserBll = new UserBLL();

        [TestMethod]
        public void Run()
        {
            //InsertListTest();

            Console.WriteLine("====================================================");

            InsertTest();

            //QueryTest();

            //UserEntity user = userService.CheckLogin("dashixiong2", "123456", out JsonObjectStatus status);
            //Console.WriteLine(user.NickName);
        }

        private void InsertTest()
        {
            string time = Stopwatch(() =>
            {
                for (int i = 1; i < 5; i++)
                {
                    string time2 = Stopwatch(() =>
                    {
                        string key = Guid.NewGuid().ToString().Replace("-", "");

                        string md5 = Md5Helper.Md5("123456");

                        string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(md5, key));
                        
                        UserEntity user = new UserEntity
                        {
                            UserId = Guid.NewGuid().ToString().Replace("-", ""),
                            Account = "dashixiong" + i,
                            NickName = "大师兄" + i,
                            Birthday = DateTime.Now.AddDays(-1000),
                            Secretkey = key,
                            Password = realPassword
                        };
                        user.Create();

                        bool res = UserBll.AddUser(user);
                    });

                    Console.WriteLine("开始测试" + i + "，耗时：" + time2);
                }
            });

            Console.WriteLine("执行结束，耗时：" + time);
        }

        private void InsertListTest()
        {
            List<UserEntity> list = new List<UserEntity>();
            for (int i = 1; i < 5000; i++)
            {
                string key = Guid.NewGuid().ToString().Replace("-", "");

                string md5 = Md5Helper.Md5("123456");

                string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(md5, key));

                UserEntity user = new UserEntity
                {
                    UserId = Guid.NewGuid().ToString().Replace("-", ""),
                    Account = "dashixiong" + i,
                    NickName = "大师兄" + i,
                    Birthday = DateTime.Now.AddDays(-1000),
                    Secretkey = key,
                    Password = realPassword
                };
                user.Create();

                list.Add(user);
            }

            string time = Stopwatch(() =>
            {
                UserBll.AddUser(list);
            });

            Console.WriteLine("执行结束，耗时：" + time);
        }

        private void QueryTest()
        {
            string time = Stopwatch(() =>
            {
                List<UserEntity> res = UserBll.QueryUserList(u => u.DeleteMark == false);

                Console.WriteLine("共得到数据：" + res.Count + "条");
            });

            Console.WriteLine("执行结束，耗时：" + time);
        }
    }
}
