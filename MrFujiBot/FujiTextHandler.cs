using System;
using System.Collections.Generic;
using Gtk;
using MrFujiBot;
using TwitchLib.Events.Client;

internal class FujiTextHandler
{
    private TwitchBot bot;
    private FujiDatabase database;
    private Gtk.ListStore userList;
    private List<ITextHandler> textHandlers;

    public FujiTextHandler(TwitchBot bot,
                           FujiDatabase database,
                           Gtk.ListStore userList)
    {
        this.Bot = bot;
        this.Bot.client.OnMessageReceived += OnMessageReceived;

        this.Database = database;

        this.userList = userList;

        this.textHandlers = new List<ITextHandler>();

        registerTextHandlers();
    }

    private void registerTextHandlers()
    {
        this.TextHandlers.Add(new PokemonCommand(this));
    }

    internal FujiDatabase Database { get => database; set => database = value; }
    public TwitchBot Bot { get => bot; set => bot = value; }
    internal List<ITextHandler> TextHandlers { get => textHandlers; set => textHandlers = value; }

    private bool UserIsPermitted(string username)
    {
        bool permitted = false;

        this.userList.Foreach(new TreeModelForeachFunc(delegate (TreeModel model, TreePath path, TreeIter iter) {
            string user = (string)model.GetValue(iter, 0);
            if(user.Equals(username))
            {
                permitted = true;
            }
            return permitted;
        }));

        return permitted;
    }

    private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
        if (UserIsPermitted(e.ChatMessage.DisplayName))
        {
            // Call each handler
            foreach (ITextHandler handler in this.TextHandlers)
            {
                if( handler.HandleText(e.ChatMessage.DisplayName,
                                       e.ChatMessage.Message) )
                {
                    // If a handler handled the message, don't call the rest.
                    break;
                }
            }
        }
    }

    public void Output(string message)
    {
        this.Bot.client.SendMessage(message);
    }
}