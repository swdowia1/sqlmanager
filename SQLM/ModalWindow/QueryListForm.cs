using SQLM.Klasy;

namespace SQLM.ModalWindow
{
    public partial class QueryListForm : Form
    {
        public HistoryQuery2 _HistoryQuery2 { get; set; }
        private string _pol = "";

        public QueryListForm(HistoryQuery2 HistoryQuery2, string pol)
        {
            InitializeComponent();

            IsMdiContainer = true;

            _HistoryQuery2 = HistoryQuery2;
            _pol = pol;

            CreateTopPanel();

            // 🔥 WAŻNE: układ dopiero po pełnym pokazaniu formy
            if (string.IsNullOrEmpty(_HistoryQuery2.Question))
                this.Shown += (s, e) => LoadAndArrange("");
        }

        private void CreateTopPanel()
        {
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            TextBox txtUserId = new TextBox
            {
                Width = 100,
                Left = 10,
                Top = 12
            };

            Button btnLoad = new Button
            {
                Text = "Run",
                Left = 120,
                Width = 80,
                Top = 10
            };
            btnLoad.Click += (sender, e) => { LoadAndArrange(txtUserId.Text); };

            Button btnCloseAll = new Button
            {
                Text = "zamknij całą aplikacje",
                Left = 220,
                Width = 180,
                Top = 10
            };
            btnCloseAll.Click += (sender, e) => { classFun.ConfirmAndExit(); };

            Label lblQuestion = new Label
            {
                AutoSize = false,
                Width = 500,
                Height = 30,
                Left = 420, // przesunięte za button
                Top = 14,
                Text = _HistoryQuery2.Question
            };
            topPanel.Controls.Add(txtUserId);
            topPanel.Controls.Add(btnLoad);
            topPanel.Controls.Add(lblQuestion);
            topPanel.Controls.Add(btnCloseAll);
            Controls.Add(topPanel);
            topPanel.BringToFront();
        }

        private void LoadAndArrange(string param)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            // 🔥 1. tworzenie okien MDI
            foreach (var q in _HistoryQuery2.Query)
            {
                var child = new QueryForm(q.Text, _pol, param)
                {
                    MdiParent = this,
                    Text = q.Title,
                    WindowState = FormWindowState.Normal
                };

                child.Show();
            }

            // 🔥 2. dopiero po Show() układ
            BeginInvoke(new Action(ArrangeVerticalEqual));
        }

        private void ArrangeVerticalEqual()
        {
            SuspendLayout();

            var mdi = Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdi == null)
            {
                ResumeLayout();
                return;
            }

            var forms = MdiChildren;
            if (forms.Length == 0)
            {
                ResumeLayout();
                return;
            }

            Rectangle area = mdi.ClientRectangle;

            int heightPerForm = area.Height / forms.Length;

            for (int i = 0; i < forms.Length; i++)
            {
                var f = forms[i];

                f.WindowState = FormWindowState.Normal;

                // 🔥 MDI poprawnie liczy się przez Location + Size
                f.Location = new Point(0, i * heightPerForm);
                f.Size = new Size(area.Width, heightPerForm);
            }

            ResumeLayout();
        }
    }
}