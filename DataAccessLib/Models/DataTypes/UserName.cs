﻿using DataAccessLib.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataAccessLib.Models.DataTypes
{
    /// <summary>
    /// 使用者名稱，專門處理任使用者名稱以及相關資訊的Model<br/>
    /// 此model使用ToStringJsonConverter
    /// </summary>
    [JsonConverter(typeof(ToStringJsonConverter))]
    public class UserName
    {
        private readonly string userName;

        public const int MaxLength = 20;

        public const int MinLength = 4;

        private static string regexPattern = @"^[a-zA-Z0-9]+$";

        /// <summary>
        /// 初始化使用者名稱，若格式不合會拋出ArgumentException
        /// </summary>
        /// <param name="userName">使用者名稱</param>
        public UserName(string userName)
        {
            if (!IsValid(userName, out string message))
                throw new ArgumentException(message);

            this.userName = userName;
        }

        /// <summary>
        /// 檢查使用者名稱是否合法
        /// </summary>
        /// <param name="candidate">使用者名稱</param>
        /// <returns></returns>
        public static bool IsValid(string candidate)
        {
            /*if (String.IsNullOrWhiteSpace(candidate))
                return false;
            if (candidate.Length > MaxLength || candidate.Length < MinLength)
                return false;
            Regex regex = new Regex(regexPattern);
            if (!regex.IsMatch(candidate))
                return false;

            return true;*/
            return IsValid(candidate, out string message);
        }

        private static bool IsValid(string candidate, out string message)
        {
            message = String.Empty;
            if (String.IsNullOrWhiteSpace(candidate))
            {
                message = "使用者名稱不可為空";
                return false;
            }
                
            if (candidate.Length > MaxLength || candidate.Length < MinLength)
            {
                message = $"使用者名稱長度需介於{MinLength}~{MaxLength}之間";
                return false;
            }
                
            Regex regex = new Regex(regexPattern);
            if (!regex.IsMatch(candidate))
            {
                message = "使用者名稱只能含有英文字母與數字";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 嘗試將字串轉換成使用者名稱
        /// </summary>
        /// <param name="candidate">要轉換的使用者名稱</param>
        /// <param name="userName">使用者名稱物件</param>
        /// <returns>若轉換成功則回傳true，反之為false</returns>
        public static bool TryParse(string candidate, out UserName userName)
        {
            /*userName = null;
            if (!IsValid(candidate))
                return false;
            userName = new UserName(candidate);
            return true;*/
            return TryParseWithMessage(candidate, out userName, out _);
        }

        /// <summary>
        /// 嘗試將字串轉換成使用者名稱，與TryParse不同的地方在於此method parse失敗會把原因寫在message
        /// </summary>
        /// <param name="candidate">要轉換的使用者名稱</param>
        /// <param name="userName">使用者名稱物件</param>
        /// <param name="message">轉換失敗原因</param>
        /// <returns></returns>
        public static bool TryParseWithMessage(string candidate, out UserName userName, out string message)
        {
            userName = null;
            if (!IsValid(candidate, out message))
                return false;
            userName = new UserName(candidate);
            return true;
        }

        /// <summary>
        /// 轉換成字串的operator(conversion operator)
        /// </summary>
        /// <param name="userName"></param>
        public static implicit operator string(UserName userName)
        {
            return userName.userName;
        }

        public override string ToString()
        {
            return this.userName;
        }

        public override bool Equals(object obj)
        {
            var other = obj as UserName;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.userName, other.userName);
        }

        public override int GetHashCode()
        {
            return this.userName.GetHashCode();
        }
    }
}
