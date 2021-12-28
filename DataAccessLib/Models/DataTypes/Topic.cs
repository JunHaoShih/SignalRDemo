using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataAccessLib.Models.DataTypes
{
    /// <summary>
    /// 聊天室話題
    /// </summary>
    public class Topic
    {
        private readonly string topic;

        public const int MaxLength = 10;

        public const int MinLength = 4;

        private static string regexPattern = @"^[a-zA-Z0-9]+$";

        public Topic(string topic)
        {
            if (!IsValid(topic, out string errorMessage))
                throw new ArgumentException(errorMessage);

            this.topic = topic;
        }

        /// <summary>
        /// 檢查聊天室話題是否合法
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
            return IsValid(candidate, out _);
        }

        private static bool IsValid(string candidate, out string message)
        {
            message = string.Empty;
            if (String.IsNullOrWhiteSpace(candidate))
            {
                message = "Topic不可為空";
                return false;
            }
            if (candidate.Length > MaxLength || candidate.Length < MinLength)
            {
                message = $"Topic長度需介於{MinLength}~{MaxLength}之間";
                return false;
            }
            Regex regex = new Regex(regexPattern);
            if (!regex.IsMatch(candidate))
            {
                message = "Topic只能含有英文字母與數字";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 嘗試將字串轉換成聊天室話題
        /// </summary>
        /// <param name="candidate">要轉換的字串</param>
        /// <param name="topicObj">聊天室話題物件</param>
        /// <returns></returns>
        public static bool TryParse(string candidate, out Topic topicObj)
        {
            /*topicObj = null;
            if (!IsValid(candidate))
                return false;

            topicObj = new Topic(candidate);
            return true;*/
            return TryParseWithMessage(candidate, out topicObj, out _);
        }

        /// <summary>
        /// 嘗試將字串轉換成Topic，與TryParse不同的地方在於此method parse失敗會把原因寫在message
        /// </summary>
        /// <param name="candidate">要轉換的字串</param>
        /// <param name="topicObj">聊天室話題物件</param>
        /// <param name="message">轉換失敗原因</param>
        /// <returns></returns>
        public static bool TryParseWithMessage(string candidate, out Topic topicObj, out string message)
        {
            topicObj = null;
            if (!IsValid(candidate, out message))
                return false;

            topicObj = new Topic(candidate);
            return true;
        }

        /// <summary>
        /// 轉換成字串的operator(conversion operator)
        /// </summary>
        /// <param name="topicObj"></param>
        public static implicit operator string(Topic topicObj)
        {
            return topicObj.topic;
        }

        public override string ToString()
        {
            return this.topic;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Topic;
            if (other == null)
                return base.Equals(obj);

            return object.Equals(this.topic, other.topic);
        }

        public override int GetHashCode()
        {
            return this.topic.GetHashCode();
        }
    }
}
