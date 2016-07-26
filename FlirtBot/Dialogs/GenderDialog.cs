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
    [LuisModel(Constants.GenderAppId, Constants.GenderSubscriptionKey)]
    public class GenderDialog : IDialog<object>
    {
        private UserInfo UInfo;
        public GenderDialog(UserInfo uinfo)
        {
            UInfo = uinfo;
        }

        public async Task StartAsync(IDialogContext context)
        {
            //await context.PostAsync("What's your intent?");
            //if ()
            await context.PostAsync("What's your Gender?");
            //await context.PostAsync("what's happeninggggg");
            //UserInfo.Name = message.From.Name;
        }
    }
}