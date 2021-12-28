using DataAccessLib.Models.DataTypes;
using DataAccessLib.SignalR;
using Microsoft.AspNetCore.Http.Connections.Client;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRClient.Enumerations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClient.SignalR
{
    public class SignalRClientHandlerBuilder
    {
        private SignalRClientHandler2 client = new SignalRClientHandler2();

        /// <summary>
        /// 設定目標server的url
        /// </summary>
        /// <param name="url">server的url</param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithUrl(string url)
        {
            client.Url = url;
            return this;
        }

        /// <summary>
        /// 設定連線的帳號密碼
        /// </summary>
        /// <param name="userName">使用者名稱(帳號)</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithUserIdentity(UserName userName, Password password)
        {
            client.UserName = userName;
            client.Password = password;
            return this;
        }

        /// <summary>
        /// 設定登入事件的delegate
        /// </summary>
        /// <param name="onLogin"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithOnLoginDelegate(Action<HttpStatusCode, string> onLogin)
        {
            client.OnLogin = onLogin;
            return this;
        }

        /// <summary>
        /// 設定訂閱事件的delegate
        /// </summary>
        /// <param name="onSubscribe"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithOnSubscribeDelegate(Action<HttpStatusCode, string> onSubscribe)
        {
            client.OnSubscribe = onSubscribe;
            return this;
        }

        /// <summary>
        /// 設定發布事件的delegate
        /// </summary>
        /// <param name="onPublish"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithOnPublishDelegate(Action<HttpStatusCode, string> onPublish)
        {
            client.OnPublish = onPublish;
            return this;
        }

        /// <summary>
        /// 設定離線事件的delegate
        /// </summary>
        /// <param name="onDisconnect"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithOnDisconnectDelegate(Func<Exception?, Task> onDisconnect)
        {
            client.OnDisconnect = onDisconnect;
            return this;
        }

        /// <summary>
        /// 設定錯誤事件的delegate
        /// </summary>
        /// <param name="onError"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithOnErrorDelegate(Action<string> onError)
        {
            client.OnError = onError;
            return this;
        }

        /// <summary>
        /// 設定接收server端訊息的delegate
        /// </summary>
        /// <param name="receiveTopicMessage"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithReceiveTopicMessageDelegate(Action<string, string, string> receiveTopicMessage)
        {
            client.ReceiveTopicMessage = receiveTopicMessage;
            return this;
        }

        /// <summary>
        /// 允許http連線
        /// </summary>
        /// <param name="isAllow"></param>
        /// <returns></returns>
        public SignalRClientHandlerBuilder WithAllowHttp(bool isAllow)
        {
            client.AllowHttp = isAllow;
            return this;
        }

        /// <summary>
        /// 建置SignalRClientHandler
        /// </summary>
        /// <returns></returns>
        public ISignalRClientHandler Build()
        {
            return client;
        }

        private class SignalRClientHandler2 : ISignalRClientHandler
        {

            public UserName UserName { get; set; }

            public Password Password { get; set; }

            public string Url { get; set; }

            public Action<HttpStatusCode, string> OnLogin = null;

            public Action<HttpStatusCode, string> OnSubscribe = null;

            public Action<HttpStatusCode, string> OnPublish = null;

            public Func<Exception?, Task> OnDisconnect = null;

            public Action<string> OnError = null;

            public Action<string, string, string> ReceiveTopicMessage = null;

            public bool AllowHttp { get; set; } = false;

            public SignalRClientHandler2() { }

            private HubConnection connection = null;

            public async Task StartAsync()
            {
                connection = new HubConnectionBuilder()
                    .WithUrl(Url, (opts) => HandleHttps(opts))
                    .WithAutomaticReconnect()
                    .Build();

                connection.On<HttpStatusCode, string>(HubData.LoginResult, (httpStatus, message) => OnLogin(httpStatus, message));
                connection.On<HttpStatusCode, string>(HubData.SubscribeResult, (httpStatus, message) => OnSubscribe(httpStatus, message));
                connection.On<HttpStatusCode, string>(HubData.SendTopicMessageResult, (httpStatus, message) => OnPublish(httpStatus, message));
                connection.On<string, string, string>(HubData.ReceiveTopicMessage, (user, topic, message) => ReceiveTopicMessage(user, topic, message));
                connection.Closed += OnDisconnect;

                try
                {
                    await connection.StartAsync();
                    await connection.InvokeAsync(HubData.Login, UserName.ToString(), Password.ToString());
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }

            public async Task StopAsync()
            {
                try
                {
                    await connection.StopAsync();
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }

            public async Task SubscribeAsync(Topic topic)
            {
                try
                {
                    await connection.InvokeAsync(HubData.Subscribe, UserName.ToString(), topic.ToString());
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }

            public async Task PublishAsync(Topic topic, ChatText chatText)
            {
                try
                {
                    await connection.InvokeAsync(HubData.SendTopicMessage, UserName.ToString(), topic.ToString(), chatText.ToString());
                }
                catch (Exception e)
                {
                    OnError(e.ToString());
                }
            }

            private void HandleHttps(HttpConnectionOptions opts)
            {
                if (AllowHttp)
                {
                    opts.HttpMessageHandlerFactory = (message) =>
                    {
                        if (message is HttpClientHandler clientHandler)
                            // always verify the SSL certificate
                            /*clientHandler.ServerCertificateCustomValidationCallback +=
                                (sender, certificate, chain, sslPolicyErrors) => { return true; };*/
                            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                        return message;
                    };
                }
            }
        }
    }
}
