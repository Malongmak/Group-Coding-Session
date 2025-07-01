using System;
using System.Windows.Forms;
using System.Timers;

namespace StopwatchApp
{
    public partial class Form1 : Form
    {
        private int hours = 0, minutes = 0, seconds = 0;
        private bool isRunning = false;
        private System.Timers.Timer? timer;

        private Label? lblTime;
        private Button? btnStart, btnPause, btnResume, btnReset, btnStop;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
        }
        private void InitializeCustomComponents()
        {
            this.Text = "Stopwatch Application";
            this.Width = 400;
            this.Height = 250;

            lblTime = new Label()
            {
                Text = "00:00:00",
                Font = new System.Drawing.Font("Arial", 24),
                AutoSize = true,
                Location = new System.Drawing.Point(120, 20)
            };
            this.Controls.Add(lblTime);

            btnStart = new Button()
            {
                Text = "Start",
                Location = new System.Drawing.Point(30, 80),
                Width = 60
            };
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);

            btnPause = new Button()
            {
                Text = "Pause",
                Location = new System.Drawing.Point(100, 80),
                Width = 60
            };
            btnPause.Click += BtnPause_Click;
            this.Controls.Add(btnPause);

            btnResume = new Button()
            {
                Text = "Resume",
                Location = new System.Drawing.Point(170, 80),
                Width = 60
            };
            btnResume.Click += BtnResume_Click;
            this.Controls.Add(btnResume);

            btnReset = new Button()
            {
                Text = "Reset",
                Location = new System.Drawing.Point(240, 80),
                Width = 60
            };
            btnReset.Click += BtnReset_Click;
            this.Controls.Add(btnReset);

            btnStop = new Button()
            {
                Text = "Stop",
                Location = new System.Drawing.Point(310, 80),
                Width = 60
            };
            btnStop.Click += BtnStop_Click;
            this.Controls.Add(btnStop);
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isRunning)
            {
                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                    if (minutes == 60)
                    {
                        minutes = 0;
                        hours++;
                    }
                }
                UpdateTimeDisplay();
            }
        }
        private void UpdateTimeDisplay()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateTimeDisplay));
            }
            else
            {
                if (lblTime != null)
                    lblTime.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            }
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            hours = minutes = seconds = 0;
            isRunning = true;
            timer?.Start();
            UpdateTimeDisplay();
        }

        private void BtnPause_Click(object? sender, EventArgs e)
        {
            MessageBox.Show($"Paused at {(lblTime != null ? lblTime.Text : "00:00:00")}");
        }

        private void BtnResume_Click(object? sender, EventArgs e)
        {
            isRunning = true;
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            isRunning = false;
            hours = minutes = seconds = 0;
            UpdateTimeDisplay();
        }

        private void BtnStop_Click(object? sender, EventArgs e)
        {
            isRunning = false;
            timer?.Stop();
            MessageBox.Show($"Stopped at {(lblTime != null ? lblTime.Text : "00:00:00")}");
        }
    }
}
