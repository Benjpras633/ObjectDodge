namespace GameTemplate
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Yellow;
            this.playButton.Enabled = false;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.playButton.FlatAppearance.BorderSize = 3;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.playButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.playButton.Location = new System.Drawing.Point(325, 250);
            this.playButton.Margin = new System.Windows.Forms.Padding(0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(150, 50);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play Again";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Visible = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Yellow;
            this.menuButton.Enabled = false;
            this.menuButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.menuButton.FlatAppearance.BorderSize = 3;
            this.menuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menuButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.menuButton.Location = new System.Drawing.Point(325, 325);
            this.menuButton.Margin = new System.Windows.Forms.Padding(0);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(150, 50);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Main Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Visible = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Enabled = false;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(200, 165);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(400, 44);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.messageLabel.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Black;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.scoreLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.scoreLabel.Location = new System.Drawing.Point(0, 400);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(800, 100);
            this.scoreLabel.TabIndex = 4;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.playButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 500);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}
