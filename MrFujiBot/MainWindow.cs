using System;
using Gtk;
using MrFujiBot;

public partial class MainWindow : Gtk.Window
{
    TwitchBot bot = null;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        var column = new TreeViewColumn();
        column.Title = "Usernames";
        column.Sizing = TreeViewColumnSizing.Fixed;
        column.Clickable = true;

        var renderer = new CellRendererText();
        column.PackStart(renderer, true);
        column.AddAttribute(renderer, "text", 0);

        this.UserList.Model = new Gtk.ListStore(typeof(string));
        this.UserList.AppendColumn(column);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void onAddUserClick(object sender, EventArgs e)
    {
        Dialog dialog = new Dialog("Add User",
                                   this,
                                   DialogFlags.DestroyWithParent |
                                       DialogFlags.Modal,
                                   ResponseType.Ok);
        
        dialog.VBox.Add(new Label("Please enter a Twitch username:"));

        Entry userEntry = new Entry();
        dialog.VBox.Add(userEntry);

        Button addButton = new Button("Add");
        addButton.Clicked += delegate { dialog.Hide(); };
        dialog.VBox.Add(addButton);

        dialog.ShowAll();
        dialog.Run();

        string username = userEntry.Text;
        ((Gtk.ListStore) (this.UserList.Model)).AppendValues(username);

        dialog.Destroy();
    }

    protected void OnRemoveUserClick(object sender, EventArgs e)
    {
        TreeIter iter;
        this.UserList.Selection.GetSelected(out iter);
        ((Gtk.ListStore)(this.UserList.Model)).Remove(ref iter);
    }

    protected void OnStartClick(object sender, EventArgs e)
    {
        if (null == bot)
        {
            if (UsernameEntry.Text.Length > 0 &&
                AccessTokenEntry.Text.Length > 0 &&
                ChannelEntry.Text.Length > 0)
            {
                try
                {
                    bot = new TwitchBot(UsernameEntry.Text,
                                        AccessTokenEntry.Text,
                                        ChannelEntry.Text);
                    bot.StatusEvent += new TwitchBot.StatusHandler(OnTwitchBotStatus);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }
    }

    protected void OnStopClick(object sender, EventArgs e)
    {
        if (null != bot)
        {
            bot.Disconnect();
        }
    }

    private void OnTwitchBotStatus(object sender, TwitchBot.StatusArgs status)
    {
        if (TwitchBot.StatusArgs.TwitchBotStatus.Connected == status.Status)
        {
            this.StatusEntry.Text = "Running";
        }
        else if (TwitchBot.StatusArgs.TwitchBotStatus.Disconnected == status.Status)
        {
            this.StatusEntry.Text = "Stopped";
        }
        else if (TwitchBot.StatusArgs.TwitchBotStatus.ConnectionError == status.Status)
        {
            this.StatusEntry.Text = "Connection Error";
        }
        else if (TwitchBot.StatusArgs.TwitchBotStatus.IncorrectLogin == status.Status)
        {
            this.StatusEntry.Text = "Incorrect Login";
        }
    }
}
