# Alfonso's bot connected with LUIS
### Notes for Alfonso

## The LUIS app
Alfonso created a [LUIS app](https://www.luis.ai/) very simple, with only two intents: "Greet" and "Help".

Just following these instructions: https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/luis-get-started-create-app 

We learned concepts as intents, utterances and entities.

![LUIS app Screenshot](https://github.com/isabelcabezasm/BotAndLUIS/blob/master/sample-luis.png)

Publish de app, and get the URL: 
https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/**app ID**?subscription-key=**suscription key**&verbose=true&timezoneOffset=0&q= 

## Bot
Open Visual Studio, and create a new "Bot project".
![New bot project](https://github.com/isabelcabezasm/BotAndLUIS/blob/master/bot-project-new.PNG)

The template already create a functional bot (a little bit silly) that reply to the user's message with the same message and the number of characters in the user's message.

But... it's a start.

For connecting this bot with LUIS, Alfonso created a file  in "Dialogs" folder: /SimpleSample/SimpleSample/Dialogs/HelpDialog.cs 

There we defined an alternative dialog flow for the bot.

Remember add the line:

~~~
[LuisModel("<YOUR_LUIS_APP_ID>", "YOUR_SUBSCRIPTION_KEY", domain: "westus.api.cognitive.microsoft.com")]
~~~

 over the class.   

 (replace the app id, for the one what was in the URL that you got when you published the LUIS app)


Then, the last thing Alfonso did is open this file:
/SimpleSample/SimpleSample/Controllers/MessagesController.cs

and replace type of dialog it's created when the conversation starts.  The line is:

~~~
await Conversation.SendAsync(activity, () => new Dialogs.HelpDialog());
~~~

## Try the bot

F5.
Get the URL. 
Paste it in the "Bot Framework Channel Emulator" and complete the URL with "/api/messages"

Talk to the bot.

![Bot channel emulator](https://github.com/isabelcabezasm/BotAndLUIS/blob/master/screenshot-simple-sample-bot-with-LUIS.PNG)

If you need more information about the integration of the bot with the LUIS app: 

https://docs.microsoft.com/en-us/azure/cognitive-services/luis/home 

And this tutorial: 
https://github.com/DanyStinson/BigBotTheory 