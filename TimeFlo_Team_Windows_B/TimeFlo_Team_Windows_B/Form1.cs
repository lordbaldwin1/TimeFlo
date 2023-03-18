using System.Media;
namespace TimeFlo_Team_Windows_B
{
    public partial class Form1 : Form
    {
        private int totalSecondsWork;
        private int totalSecondsBreak;
        private bool paused;
        private int workSessions;
        private int loopflag;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            loopflag = 0;

            if (paused == true)
            {
                this.timer1.Enabled = true;
                paused = false;
            }
            else
            {
                int minutes = int.Parse(this.numericUpDown1.Value.ToString());
                totalSecondsWork = minutes * 60;
                int breakmin = int.Parse(this.numericUpDown2.Value.ToString());
                totalSecondsBreak = breakmin * 60;

                this.timer1.Enabled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 60;
            numericUpDown1.Minimum = 10;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = 60;
            numericUpDown2.Minimum = 5;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button1.Enabled = true;

            this.timer1.Enabled = false;
            paused = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.label1.Text = "00:00";
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            paused = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (loopflag == 3)
            {
                totalSecondsBreak = totalSecondsBreak + 600;
                ++loopflag;
            }
                if (totalSecondsWork > 0)
                {
                    totalSecondsWork--;
                    int minutes = totalSecondsWork / 60;
                    int seconds = totalSecondsWork - (minutes * 60);
                    //this.label1.Text = minutes.ToString() + ":" + seconds.ToString();
                    if (minutes < 10 && seconds < 10)
                        this.label1.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
                    else if (minutes < 10 && seconds > 10)
                        this.label1.Text = "0" + minutes.ToString() + ":" + seconds.ToString();
                    else if (minutes > 10 && seconds < 10)
                        this.label1.Text = minutes.ToString() + ":0" + seconds.ToString();
                    else
                        this.label1.Text = minutes.ToString() + ":" + seconds.ToString();

                }
                else if (totalSecondsWork == 0)
                {
                    SystemSounds.Beep.Play();
                    totalSecondsWork = -1;
                }
                else if (totalSecondsBreak > 0)
                {
                    totalSecondsBreak--;
                    int breakmin = totalSecondsBreak / 60;
                    int breaksec = totalSecondsBreak - (breakmin * 60);
                    //this.label1.Text = breakmin.ToString() + ":" + breaksec.ToString();
                    if (breakmin < 10 && breaksec < 10)
                        this.label1.Text = "0" + breakmin.ToString() + ":0" + breaksec.ToString();
                    else if (breakmin < 10 && breaksec > 10)
                        this.label1.Text = "0" + breakmin.ToString() + ":" + breaksec.ToString();
                    else if (breakmin > 10 && breaksec < 10)
                        this.label1.Text = breakmin.ToString() + ":0" + breaksec.ToString();
                    else
                        this.label1.Text = breakmin.ToString() + ":" + breaksec.ToString();

                }
                else if (totalSecondsBreak == 0)
                {
                    SystemSounds.Beep.Play();
                    totalSecondsBreak = -1;
                }
                else
                {
                    if (loopflag < 4)
                    {
                        ++loopflag;
                        int minutes = int.Parse(this.numericUpDown1.Value.ToString());
                        totalSecondsWork = minutes * 60;
                        int breakmin = int.Parse(this.numericUpDown2.Value.ToString());
                        totalSecondsBreak = breakmin * 60;

                }
                    else
                    {
                        this.timer1.Stop();
                        this.button1.Enabled = true;

                        paused = false;

                        ++workSessions;
                        this.label5.Text = workSessions.ToString();
                    }
                }
            
        }
    }
}