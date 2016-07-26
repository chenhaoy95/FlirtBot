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
    [LuisModel(Constants.GenderAppId, Constants.GenderSubscriptionKey)]
    public class GenderDialog : LuisDialog<object>
    {
        private UserInfo UInfo;

        public GenderDialog(UserInfo uinfo)
        {
            UInfo = uinfo;
        }

        [LuisIntent("GenderIntent")]
        public async Task SetGenderAsync(IDialogContext context, LuisResult result)
        {
            var type = result.Entities[0].Type;
            
            if (type == "Male")
            {
                UInfo.Gender = Gender.Male;
            }
            else
            {
                UInfo.Gender = Gender.Female;
            }

            await context.PostAsync($"Gender set to {type}");
            context.Done(0);
        }
    }
}