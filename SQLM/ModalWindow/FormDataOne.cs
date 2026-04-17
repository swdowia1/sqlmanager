using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class FormDataOne : Form
    {
        public FormDataOne(string query)
        {
            InitializeComponent();
            dgData.SetStyle();
            dgData.DataSource = classData.FillData(query, GlobalData.Pol);
        }
    }
}