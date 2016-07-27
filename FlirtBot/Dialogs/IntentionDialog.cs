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
        private UserInfo UInfo;

        public IntentionDialog(UserInfo uinfo)
        {
            UInfo = uinfo;
        }

        [LuisIntent("SetIntention")]
        public async Task SetIntentionAsync(IDialogContext context, LuisResult result)
        {

            var intention = result.Entities[0].Type;
            if (intention == "IntentionHookUp")
            {
                UInfo.Intention = Intention.HookUp;
            }
            else if (intention == "IntentionReject")
            {
                UInfo.Intention = Intention.Reject;
            }
            else if (intention == "IntentionFriend")
            {
                UInfo.Intention = Intention.Friend;
            }
            
            //UInfo.Intention = intention;
            await context.PostAsync(intention);
            context.Done(0);
        }

    }
}