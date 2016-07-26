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
using Microsoft.Bot.Builder.Luis.Models;

namespace FlirtBot.Dialogs
{
    [Serializable]
    [LuisModel(Constants.IntentionAppId, Constants.IntentionSubscriptionKey)]
    public class IntentionDialog : LuisDialog<object>
    {

        [LuisIntent("SetIntention")]
        public async Task SetIntentionAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(result.Entities[0].Type);
            context.Done(0);
            //context.Wait(SetIntentionAsync);
        }

    }
}