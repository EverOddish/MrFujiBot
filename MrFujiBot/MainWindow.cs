using System;
using System.IO;
using Gtk;
using Newtonsoft.Json.Linq;
using MrFujiBot;

public partial class MainWindow : Gtk.Window
{
    TwitchBot bot = null;
    FujiDatabase database = null;
    FujiTextHandler textHandler = null;
    dynamic settings;

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

        PopulateSettings();
        PopulateFields();

        if(null != settings.auto_start)
        {
            if(1 == (int)settings.auto_start)
            {
                StartBot();
            }
        }
    }

    private void PopulateSettings()
    {
        string json;

        try
        {
            json = System.IO.File.ReadAllText("settings.json");
            settings = JObject.Parse(json);
        }
        catch(FileNotFoundException)
        {
            settings = new JObject();
            settings.permitted_users = new JArray();
        }
    }

    private void PersistSettings()
    {
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(settings);
        System.IO.File.WriteAllText("settings.json", json);
    }

    private void PopulateFields()
    {
        if(null != settings.bot_username)
        {
            UsernameEntry.Text = settings.bot_username;
        }

        if(null != settings.channel)
        {
            ChannelEntry.Text = settings.channel;
        }

        if (null != settings.access_token)
        {
            AccessTokenEntry.Text = settings.access_token;
        }

        if(null != settings.permitted_users)
        {
            foreach(string user in settings.permitted_users)
            {
                ((Gtk.ListStore)(this.UserList.Model)).AppendValues(user);
            }
        }

        if(null != settings.generation)
        {
            int gen = (int)settings.generation - 1;
            Gtk.TreeIter iter;
            GenerationBox.Model.IterNthChild(out iter, gen);
            GenerationBox.SetActiveIter(iter);
        }
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnAddUserClick(object sender, EventArgs e)
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

        settings.permitted_users.Add(username);
        PersistSettings();

        dialog.Destroy();
    }

    protected void OnRemoveUserClick(object sender, EventArgs e)
    {
        TreeIter iter;
        this.UserList.Selection.GetSelected(out iter);
        string username = (string)this.UserList.Model.GetValue(iter, 0);
        ((Gtk.ListStore)(this.UserList.Model)).Remove(ref iter);

        JArray children = (JArray)settings.permitted_users;
        foreach(JToken child in children)
        {
            if(child.ToString().Equals(username))
            {
                settings.permitted_users.Remove(child);
                PersistSettings();
                break;
            }
        }
    }

    private void StartBot()
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

                    database = new FujiDatabase();

                    textHandler = new FujiTextHandler(bot,
                                                      database,
                                                      (Gtk.ListStore)(this.UserList.Model));
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }
    }

    protected void OnStartClick(object sender, EventArgs e)
    {
        StartBot();
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

    protected void OnBotUsernameLostFocus(object sender, EventArgs e)
    {
        settings.bot_username = UsernameEntry.Text;
        PersistSettings();
    }

    protected void OnChannelLostFocus(object o, FocusOutEventArgs args)
    {
        settings.channel = ChannelEntry.Text;
        PersistSettings();
    }

    protected void OnAccessTokenLostFocus(object o, FocusOutEventArgs args)
    {
        settings.access_token = AccessTokenEntry.Text;
        PersistSettings();
    }

    protected void OnGenerationChanged(object sender, EventArgs e)
    {
        settings.generation = Int32.Parse(GenerationBox.ActiveText.Split(' ')[1]);
        PersistSettings();
    }

    protected void OnAutoStartToggle(object sender, EventArgs e)
    {
        settings.auto_start = AutoStartCheckbox.Active ? 1 : 0;
        PersistSettings();
    }
}
