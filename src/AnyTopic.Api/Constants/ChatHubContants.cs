namespace AnyTopic.Api.Constants
{
    public static class ChatHubContants
    {
        public static class Client
        {
            public const string OnError = "onError";

            public static class User
            {
                public const string ReceiveMessage = "receiveMessage";
            }

            public static class Room
            {
                public const string Join = "joinRoom";
                public const string Add = "addRoom";
                public const string AddUser = "addUser";
                public const string RemoveUser = "removeUser";
            }
        }
    }
}
