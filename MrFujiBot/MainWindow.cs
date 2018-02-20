using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
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

    protected void onRemoveUserClick(object sender, EventArgs e)
    {
        TreeIter iter;
        this.UserList.Selection.GetSelected(out iter);
        ((Gtk.ListStore)(this.UserList.Model)).Remove(ref iter);
    }
}
