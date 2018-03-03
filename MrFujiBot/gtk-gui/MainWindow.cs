
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;

	private global::Gtk.Label TitleLabel;

	private global::Gtk.Label AccessTokenLabel;

	private global::Gtk.Entry AccessTokenEntry;

	private global::Gtk.Button StartButton;

	private global::Gtk.Button StopButton;

	private global::Gtk.Entry StatusEntry;

	private global::Gtk.Button AddUserButton;

	private global::Gtk.Button RemoveUserButton;

	private global::Gtk.CheckButton AutoStartCheckbox;

	private global::Gtk.ComboBox GenerationBox;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView UserList;

	private global::Gtk.Label UsernameLabel;

	private global::Gtk.Entry UsernameEntry;

	private global::Gtk.Entry ChannelEntry;

	private global::Gtk.Label ChannelLabel;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Mr. Fuji Bot");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.TitleLabel = new global::Gtk.Label();
		this.TitleLabel.Name = "TitleLabel";
		this.TitleLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Mr. Fuji Bot Control Panel");
		this.fixed1.Add(this.TitleLabel);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.TitleLabel]));
		w1.X = 15;
		w1.Y = 15;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.AccessTokenLabel = new global::Gtk.Label();
		this.AccessTokenLabel.Name = "AccessTokenLabel";
		this.AccessTokenLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Access Token:");
		this.fixed1.Add(this.AccessTokenLabel);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.AccessTokenLabel]));
		w2.X = 15;
		w2.Y = 75;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.AccessTokenEntry = new global::Gtk.Entry();
		this.AccessTokenEntry.CanFocus = true;
		this.AccessTokenEntry.Name = "AccessTokenEntry";
		this.AccessTokenEntry.IsEditable = true;
		this.AccessTokenEntry.WidthChars = 17;
		this.AccessTokenEntry.InvisibleChar = '●';
		this.fixed1.Add(this.AccessTokenEntry);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.AccessTokenEntry]));
		w3.X = 155;
		w3.Y = 70;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.StartButton = new global::Gtk.Button();
		this.StartButton.WidthRequest = 100;
		this.StartButton.CanFocus = true;
		this.StartButton.Name = "StartButton";
		this.StartButton.UseUnderline = true;
		this.StartButton.Label = global::Mono.Unix.Catalog.GetString("Start");
		this.fixed1.Add(this.StartButton);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.StartButton]));
		w4.X = 15;
		w4.Y = 105;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.StopButton = new global::Gtk.Button();
		this.StopButton.WidthRequest = 100;
		this.StopButton.CanFocus = true;
		this.StopButton.Name = "StopButton";
		this.StopButton.UseUnderline = true;
		this.StopButton.Label = global::Mono.Unix.Catalog.GetString("Stop");
		this.fixed1.Add(this.StopButton);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.StopButton]));
		w5.X = 120;
		w5.Y = 105;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.StatusEntry = new global::Gtk.Entry();
		this.StatusEntry.CanFocus = true;
		this.StatusEntry.Name = "StatusEntry";
		this.StatusEntry.Text = global::Mono.Unix.Catalog.GetString("Stopped");
		this.StatusEntry.IsEditable = false;
		this.StatusEntry.WidthChars = 15;
		this.StatusEntry.InvisibleChar = '●';
		this.fixed1.Add(this.StatusEntry);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.StatusEntry]));
		w6.X = 265;
		w6.Y = 108;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.AddUserButton = new global::Gtk.Button();
		this.AddUserButton.WidthRequest = 120;
		this.AddUserButton.CanFocus = true;
		this.AddUserButton.Name = "AddUserButton";
		this.AddUserButton.UseUnderline = true;
		this.AddUserButton.Label = global::Mono.Unix.Catalog.GetString("Add User");
		this.fixed1.Add(this.AddUserButton);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.AddUserButton]));
		w7.X = 197;
		w7.Y = 163;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.RemoveUserButton = new global::Gtk.Button();
		this.RemoveUserButton.WidthRequest = 120;
		this.RemoveUserButton.CanFocus = true;
		this.RemoveUserButton.Name = "RemoveUserButton";
		this.RemoveUserButton.UseUnderline = true;
		this.RemoveUserButton.Label = global::Mono.Unix.Catalog.GetString("Remove User");
		this.fixed1.Add(this.RemoveUserButton);
		global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.RemoveUserButton]));
		w8.X = 197;
		w8.Y = 190;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.AutoStartCheckbox = new global::Gtk.CheckButton();
		this.AutoStartCheckbox.CanFocus = true;
		this.AutoStartCheckbox.Name = "AutoStartCheckbox";
		this.AutoStartCheckbox.Label = global::Mono.Unix.Catalog.GetString("Auto-start");
		this.AutoStartCheckbox.DrawIndicator = true;
		this.AutoStartCheckbox.UseUnderline = true;
		this.fixed1.Add(this.AutoStartCheckbox);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.AutoStartCheckbox]));
		w9.X = 400;
		w9.Y = 109;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GenerationBox = global::Gtk.ComboBox.NewText();
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 1"));
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 2"));
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 3"));
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 4"));
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 5"));
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 6"));
		this.GenerationBox.AppendText(global::Mono.Unix.Catalog.GetString("Generation 7"));
		this.GenerationBox.WidthRequest = 125;
		this.GenerationBox.CanDefault = true;
		this.GenerationBox.Name = "GenerationBox";
		this.GenerationBox.Active = 6;
		this.fixed1.Add(this.GenerationBox);
		global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GenerationBox]));
		w10.X = 349;
		w10.Y = 163;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.UserList = new global::Gtk.TreeView();
		this.UserList.WidthRequest = 150;
		this.UserList.CanFocus = true;
		this.UserList.Name = "UserList";
		this.UserList.FixedHeightMode = true;
		this.UserList.HeadersVisible = false;
		this.UserList.Reorderable = true;
		this.GtkScrolledWindow.Add(this.UserList);
		this.fixed1.Add(this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GtkScrolledWindow]));
		w12.X = 25;
		w12.Y = 161;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.UsernameLabel = new global::Gtk.Label();
		this.UsernameLabel.Name = "UsernameLabel";
		this.UsernameLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Twitch Bot Username:");
		this.fixed1.Add(this.UsernameLabel);
		global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.UsernameLabel]));
		w13.X = 15;
		w13.Y = 45;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.UsernameEntry = new global::Gtk.Entry();
		this.UsernameEntry.CanFocus = true;
		this.UsernameEntry.Name = "UsernameEntry";
		this.UsernameEntry.IsEditable = true;
		this.UsernameEntry.WidthChars = 17;
		this.UsernameEntry.InvisibleChar = '●';
		this.fixed1.Add(this.UsernameEntry);
		global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.UsernameEntry]));
		w14.X = 155;
		w14.Y = 40;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.ChannelEntry = new global::Gtk.Entry();
		this.ChannelEntry.CanFocus = true;
		this.ChannelEntry.Name = "ChannelEntry";
		this.ChannelEntry.IsEditable = true;
		this.ChannelEntry.WidthChars = 17;
		this.ChannelEntry.InvisibleChar = '●';
		this.fixed1.Add(this.ChannelEntry);
		global::Gtk.Fixed.FixedChild w15 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.ChannelEntry]));
		w15.X = 410;
		w15.Y = 40;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.ChannelLabel = new global::Gtk.Label();
		this.ChannelLabel.Name = "ChannelLabel";
		this.ChannelLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Twitch Channel:");
		this.fixed1.Add(this.ChannelLabel);
		global::Gtk.Fixed.FixedChild w16 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.ChannelLabel]));
		w16.X = 305;
		w16.Y = 46;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 561;
		this.DefaultHeight = 265;
		this.GenerationBox.HasDefault = true;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.StartButton.Clicked += new global::System.EventHandler(this.OnStartClick);
		this.StopButton.Clicked += new global::System.EventHandler(this.OnStopClick);
		this.AddUserButton.Clicked += new global::System.EventHandler(this.OnAddUserClick);
		this.RemoveUserButton.Clicked += new global::System.EventHandler(this.OnRemoveUserClick);
	}
}
