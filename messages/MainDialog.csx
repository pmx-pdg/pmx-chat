using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

/// This dialog is the main bot dialog, which will call the Form Dialog and handle the results
[Serializable]
public class MainDialog : IDialog<object>
{
    private string newLine = Environment.NewLine + Environment.NewLine;

    public MainDialog()
    {
    }

    public Task StartAsync(IDialogContext context)
    {
        context.Wait(MessageReceivedAsync);
        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var activity = await result as Activity;

        string input = activity.Text.ToLower();

        await context.PostAsync("PdG 20170710 Going back to the main menu." + newLine + input);
        context.Wait(MessageReceivedAsync);
    }   
}