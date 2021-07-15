public interface IBoardMenu
{
    BoardMenuID menuID { get; }
    event System.Action<BoardMenuID> OnRequestingOpenMenu;

    void Initialize();
    void Show();
    void Hide();
}
