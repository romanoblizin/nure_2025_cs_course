namespace Course.Forms
{
    public partial class TimeDeltaForm : Form
    {
        private MenuForm menuForm;

        public TimeDeltaForm(MenuForm menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(nudSeconds.Value));
            timeSpan = timeSpan.Add(TimeSpan.FromMinutes(Convert.ToInt32(nudMinutes.Value)));
            timeSpan = timeSpan.Add(TimeSpan.FromHours(Convert.ToInt32(nudHours.Value)));
            timeSpan = timeSpan.Add(TimeSpan.FromDays(Convert.ToInt32(nudDays.Value)));

            nudSeconds.Value = 0;
            nudMinutes.Value = 0;
            nudHours.Value = 0;
            nudDays.Value = 0;

            menuForm.TimeDelta += timeSpan;
            this.Close();
        }
    }
}
