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
            context.Wait(SetGenderAsync);
        }

        public async Task SetGenderAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            await context.PostAsync(message.Text);
            context.Wait(SetGenderAsync);
        }
    }
}