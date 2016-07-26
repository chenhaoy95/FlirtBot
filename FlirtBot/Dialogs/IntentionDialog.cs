using FlirtBot.Resources;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using FlirtBot.Domain;

namespace FlirtBot.Dialogs
{
    [Serializable]
    [LuisModel(Constants.AppId, Constants.SubscriptionKey)]
    public class IntentionDialog : IDialog<object>
    {
        private UserInfo UInfo;
        public IntentionDialog(UserInfo uinfo)
        {
            UInfo = uinfo;
        }
        public async Task StartAsync(IDialogContext context)
        {
            //await context.PostAsync("What's your intent?");
            //if ()
            await context.PostAsync("What's your intent?");
            context.Wait(SetIntentionAsync);
            //await context.PostAsync("what's happeninggggg");
            //UserInfo.Name = message.From.Name;
        }

        public async Task SetIntentionAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
=
        }


    }
}