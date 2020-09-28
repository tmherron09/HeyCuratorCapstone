using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Hubs
{
    public class ChatHub : Hub
    {


        public async Task SendMessage(string user)
        {
            string connectionId = Context.ConnectionId;
            ChatManager.AddUser(user, connectionId);

            string message = $"Hello {user}. Welcome to the service.";

            var dictUsers = ChatManager.GetListOfUsers();


            await Clients.Caller.SendAsync("ReceiveMessage", message);
            await Clients.All.SendAsync("ListOfUsers", dictUsers);
        }

        public async Task RegisterUserId(string userId)
        {
            var connectionId = Context.ConnectionId;

        }

        public async Task GetListOfUsers()
        {
            var dictUsers = ChatManager.GetListOfUsers();

            await Clients.All.SendAsync("ListOfUsers", dictUsers);

            var item = Context.Items["FirstName"].ToString();
            var message = $"The Context item of Firstname is = {item}";

            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        
        public async Task MessageUser(string sender, string recipient, string message)
        {
            var conn = ChatManager.GetUserConnection(recipient);

            message = $"{sender}: {message}";

            

            await Clients.Client(conn).SendAsync("ReceiveMessage", message);
        }

        public async Task GetDateTime()
        {
            var date = DateTime.Now;

            await Clients.All.SendAsync("RecieveTime", date);
        }

        public async Task CheckItemPersistence()
        {
            var user = ChatManager.GetUserName(Context.ConnectionId);
            Context.Items.Add("FirstName", $" This is the context of {user}.");
            var item = Context.Items["FirstName"].ToString();
            var message = $"The Context of item Firstname has been set to = {item}";
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        /// <summary>
        /// Overrides the base disconnection procedure. If a user disconnects, it first checks to make sure the user has fully disconnected before alerting other users.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var disconnectedUser = ChatManager.GetUserName(Context.ConnectionId);

            if(await IsCompletelyDisconnected(disconnectedUser))
            {
                string disconnectedMessage = $"{disconnectedUser} has disConnected";
                await Clients.All.SendAsync("ReceiveMessage", disconnectedMessage);
                ChatManager.RemoveConnection(Context.ConnectionId);
                await base.OnDisconnectedAsync(exception);
            }
            else
            {
                await base.OnDisconnectedAsync(exception);
            }
        }

        /// <summary>
        /// An async method to use a form of "long" pooling to ensure a user didn't just refresh the page or had a short term disconnect.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> IsCompletelyDisconnected(string userName)
        {
            int count = 0;
            while(count < 60)
            {
                var connId = ChatManager.GetUserConnection(userName);
                await Clients.Client(connId).SendAsync("AreYouThere");
                if (ChatManager.DidUserCheckIn(userName))
                {
                    return true;
                }
                await Task.Delay(2000);
            }
            return true;
        }

        /// <summary>
        /// Is a user is still logged in, their name goes into a list in the manager. That list is the checked to see if the user is still available.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task UserHere(string userName)
        {
            ChatManager.UserCheckingIn(userName);
        }

        public async Task ControllerMessage()
        {

            var msg = "This is a message from the Controller";
            await Clients.All.SendAsync("ControllerMessage", msg);
            
        }

        public async Task TestToast()
        {

            await Clients.All.SendAsync("PopToasts", "The Title", "The really long message that Denee has updated Dolls Count.");

        }
        public async Task CustomToast(string title, string msg, string color, string icon)
        {
            await Clients.All.SendAsync("PopCustomToast", title, msg, color, icon);
        }


        public async Task CustomToastTest()
        {

            await Clients.All.SendAsync("PopCustomToast", "Title", "This is the message part of the toast.", "red", "fa-bell");

        }

        public async Task ChatToUser(string sender, string reciever, string msg)
        {
            if (reciever == "everyone")
            {
                await Clients.All.SendAsync("ChatMessageUser", sender, reciever, msg);
            }
            else
            {

                var other = ChatManager.GetUserConnection(reciever);

                await Clients.Caller.SendAsync("ChatMessageUser", sender, reciever, msg);
                await Clients.Client(other).SendAsync("ChatMessageUser", sender, reciever, msg);
            }
        }
    }
}


// Get the UserId of of the Connection.
//  var messageIdentity = $"{Context.UserIdentifier} = is the Identity of {user}";
