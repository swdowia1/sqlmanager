namespace SQLM.Klasy
{
    internal class classMessage
    {
        //public static void PopUp(string tresc, int wielkosc = 100)
        //{
        //    PopupNotifier popup = new PopupNotifier();
        //    popup.TitleText = "Informacja";
        //    popup.ContentText = tresc;
        //    popup.Popup(); // show
        //}
        internal static bool Question(string question)
        {
            DialogResult dialogResult = MessageBox.Show(question, "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        internal static void Show(string value)
        {
            MessageBox.Show(value, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void ShowError(string value, string Title = "Error")
        {

            MessageBox.Show(value, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
