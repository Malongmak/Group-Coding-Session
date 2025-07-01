using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace StopwatchApp
{
    public partial class Form1 : Form
    {
        private int hours = 0, minutes = 0, seconds = 0, milliseconds = 0;
        private bool isRunning = false;
        private bool isPaused = false;
        private System.Timers.Timer? timer;

        private Label? lblTime;
        private Label? lblTitle;
        private Button? btnStartStop, btnPauseResume, btnReset;
        private Panel? panelMain, panelButtons;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(10);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Digital Stopwatch";
            this.Size = new Size(450, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 48);

            panelMain = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(45, 45, 48),
                Padding = new Padding(20, 20, 20, 20) // Fixed: Padding requires 4 arguments
            };
            this.Controls.Add(panelMain);

            lblTitle = new Label()
            {
                Text = "STOPWATCH",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 220, 220),
                AutoSize = true,
                Location = new Point(150, 30)
            };
            panelMain.Controls.Add(lblTitle);

            lblTime = new Label()
            {
                Text = "00:00:00.00",
                Font = new Font("Consolas", 32, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 200, 255),
                AutoSize = true,
                Location = new Point(65, 80),
                BackColor = Color.FromArgb(30, 30, 32),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15, 10, 15, 10) // Fixed: Padding requires 4 arguments
            };
            panelMain.Controls.Add(lblTime);

            panelButtons = new Panel()
            {
                Location = new Point(50, 170),
                Size = new Size(350, 70),
                BackColor = Color.Transparent
            };
            panelMain.Controls.Add(panelButtons);

            btnStartStop = new Button()
            {
                Text = "START",
                Size = new Size(100, 50),
                Location = new Point(0, 10),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnStartStop.FlatAppearance.BorderSize = 0;
            btnStartStop.FlatAppearance.MouseOverBackColor = Color.FromArgb(102, 187, 106);
            btnStartStop.Click += BtnStartStop_Click;
            panelButtons.Controls.Add(btnStartStop);

            btnPauseResume = new Button()
            {
                Text = "PAUSE",
                Size = new Size(100, 50),
                Location = new Point(125, 10),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 152, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnPauseResume.FlatAppearance.BorderSize = 0;
            btnPauseResume.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 167, 38);
            btnPauseResume.Click += BtnPauseResume_Click;
            panelButtons.Controls.Add(btnPauseResume);

            btnReset = new Button()
            {
                Text = "RESET",
                Size = new Size(100, 50),
                Location = new Point(250, 10),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 83, 80);
            btnReset.Click += BtnReset_Click;
            panelButtons.Controls.Add(btnReset);

            CenterLabel(lblTitle, panelMain.Width);
        }

        private void CenterLabel(Label label, int containerWidth)
        {
            label.Location = new Point((containerWidth - label.Width) / 2, label.Location.Y);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isRunning && !isPaused)
            {
                milliseconds++;
                if (milliseconds == 100)
                {
                    milliseconds = 0;
                    seconds++;
                    if (seconds == 60)
                    {
                        seconds = 0;
                        minutes++;
                        if (minutes == 60)
                        {
                            minutes = 0;
                            hours++;
                            if (hours == 100)
                            {
                                StopTimer();
                                return;
                            }
                        }
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
                {
                    lblTime.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}.{milliseconds:D2}";
                }
            }
        }

        private void BtnStartStop_Click(object? sender, EventArgs e)
        {
            if (!isRunning)
            {
                StartTimer();
            }
            else
            {
                StopTimer();
            }
        }

        private void StartTimer()
        {
            isRunning = true;
            isPaused = false;
            timer?.Start();
            
            if (btnStartStop != null)
            {
                btnStartStop.Text = "STOP";
                btnStartStop.BackColor = Color.FromArgb(244, 67, 54);
                btnStartStop.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 83, 80);
            }
            
            if (btnPauseResume != null)
            {
                btnPauseResume.Enabled = true;
                btnPauseResume.Text = "PAUSE";
            }
        }

        private void StopTimer()
        {
            isRunning = false;
            isPaused = false;
            timer?.Stop();
            
            hours = minutes = seconds = milliseconds = 0;
            UpdateTimeDisplay();
            
            if (btnStartStop != null)
            {
                btnStartStop.Text = "START";
                btnStartStop.BackColor = Color.FromArgb(76, 175, 80);
                btnStartStop.FlatAppearance.MouseOverBackColor = Color.FromArgb(102, 187, 106);
            }
            
            if (btnPauseResume != null)
            {
                btnPauseResume.Enabled = false;
                btnPauseResume.Text = "PAUSE";
            }
        }

        private void BtnPauseResume_Click(object? sender, EventArgs e)
        {
            if (!isPaused)
            {
                isPaused = true;
                if (btnPauseResume != null)
                {
                    btnPauseResume.Text = "RESUME";
                    btnPauseResume.BackColor = Color.FromArgb(76, 175, 80);
                    btnPauseResume.FlatAppearance.MouseOverBackColor = Color.FromArgb(102, 187, 106);
                }
            }
            else
            {
                isPaused = false;
                if (btnPauseResume != null)
                {
                    btnPauseResume.Text = "PAUSE";
                    btnPauseResume.BackColor = Color.FromArgb(255, 152, 0);
                    btnPauseResume.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 167, 38);
                }
            }
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            hours = minutes = seconds = milliseconds = 0;
            UpdateTimeDisplay();
            
            FlashButton(btnReset);
        }

        private async void FlashButton(Button? button)
        {
            if (button == null) return;
            
            Color originalColor = button.BackColor;
            button.BackColor = Color.FromArgb(255, 255, 255);
            await System.Threading.Tasks.Task.Delay(100);
            button.BackColor = originalColor;
        }

    }
}