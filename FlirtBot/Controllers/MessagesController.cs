using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using FlirtBot.Dialogs;
using FlirtBot.Responder;

namespace FlirtBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        UserInfo UInfo = new UserInfo();
        RejectResponder Reject = new RejectResponder();

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            if (activity.Type == ActivityTypes.Message)
            {
                string text = activity.Text.ToLower();
                if (text.StartsWith("//set_intention"))
                {
                    //Luis model to set intentions
                    activity.Text = text.Substring(15);
                    Reject.Respond(activity.Text);
                    await Conversation.SendAsync(activity, () => new IntentionDialog(UInfo));
                }
                else if (text.StartsWith("//set_gender"))
                {
                    activity.Text = text.Substring(12);
                    await Conversation.SendAsync(activity, () => new GenderDialog(ref UInfo));
                    //more stuff
                }
                /*else if (UInfo.Intention == null)
                {
                    //actual messages stuff
                    Activity reply = activity.CreateReply("You haven't told me what your intention with this person is yet. Type in //set_intention followed by either date, friend, hook up, or reject.");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }*/
                else if (UInfo.Gender == 0)
                {
                    Activity reply = activity.CreateReply("You haven't told me what gender the person you're talking to is. Type in //set_gender followed by either male or female.");
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }
            else if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
               // UInfo.Name = activity.From.Name;
               // await Conversation.SendAsync(activity, () => new IntentionDialog(UInfo));

            }
            else
            {
                await connector.Conversations.ReplyToActivityAsync(HandleSystemMessage(activity));
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {

            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
                               
            }

            return null;
        }
    }
}