using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleSample.Dialogs
{

    [LuisModel("<YOUR_LUIS_APP_ID>", "YOUR_SUBSCRIPTION_KEY", domain: "westus.api.cognitive.microsoft.com")]
    [Serializable]
    public class HelpDialog : LuisDialog<object>
    {

        [LuisIntent("Greet")]
        public async Task Greet(IDialogContext context, LuisResult result)
        {
            string message = $"Hello";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            string message = $"So... You need help... aham... .";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"I'm the NotAlone bot. I can understand requests to help. \n\n Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }


        public HelpDialog()
        {

        }

        public HelpDialog(ILuisService service)
                : base(service)
        {
        }
    }
}