namespace Kursowaya_V
{
    partial class Form1 : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.difficulty4x4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficulty8x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficulty10x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblBestMoves = new System.Windows.Forms.Label();
            this.lblBestTime = new System.Windows.Forms.Label();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.panelGameArea = new System.Windows.Forms.Panel();
            this.tableGrid = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelGameArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.difficulty4x4ToolStripMenuItem,
            this.difficulty8x8ToolStripMenuItem,
            this.difficulty10x10ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "Игра";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "Новая игра";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // difficulty4x4ToolStripMenuItem
            // 
            this.difficulty4x4ToolStripMenuItem.Name = "difficulty4x4ToolStripMenuItem";
            this.difficulty4x4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.difficulty4x4ToolStripMenuItem.Text = "Легко (4x4)";
            // 
            // difficulty8x8ToolStripMenuItem
            // 
            this.difficulty8x8ToolStripMenuItem.Name = "difficulty8x8ToolStripMenuItem";
            this.difficulty8x8ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.difficulty8x8ToolStripMenuItem.Text = "Средне (8x8)";
            // 
            // difficulty10x10ToolStripMenuItem
            // 
            this.difficulty10x10ToolStripMenuItem.Name = "difficulty10x10ToolStripMenuItem";
            this.difficulty10x10ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.difficulty10x10ToolStripMenuItem.Text = "Сложно (10x10)";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.lblBestMoves);
            this.panelStats.Controls.Add(this.lblBestTime);
            this.panelStats.Controls.Add(this.lblMoves);
            this.panelStats.Controls.Add(this.lblTime);
            this.panelStats.Controls.Add(this.lblDifficulty);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 24);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1000, 80);
            this.panelStats.TabIndex = 1;
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoves.Location = new System.Drawing.Point(400, 10);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(80, 17);
            this.lblMoves.TabIndex = 2;
            this.lblMoves.Text = "Ходы: 0";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(600, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(70, 17);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Время: 0";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDifficulty.Location = new System.Drawing.Point(15, 10);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(100, 17);
            this.lblDifficulty.TabIndex = 0;
            this.lblDifficulty.Text = "Режим: 4x4";
            // 
            // lblBestTime
            // 
            this.lblBestTime.AutoSize = true;
            this.lblBestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblBestTime.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBestTime.Location = new System.Drawing.Point(600, 40);
            this.lblBestTime.Name = "lblBestTime";
            this.lblBestTime.Size = new System.Drawing.Size(105, 15);
            this.lblBestTime.TabIndex = 4;
            this.lblBestTime.Text = "Рекорд: -- сек";
            // 
            // lblBestMoves
            // 
            this.lblBestMoves.AutoSize = true;
            this.lblBestMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblBestMoves.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBestMoves.Location = new System.Drawing.Point(400, 40);
            this.lblBestMoves.Name = "lblBestMoves";
            this.lblBestMoves.Size = new System.Drawing.Size(113, 15);
            this.lblBestMoves.TabIndex = 3;
            this.lblBestMoves.Text = "Рекорд: -- ходов";
            // 
            // panelGameArea
            // 
            this.panelGameArea.AutoScroll = true;
            this.panelGameArea.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelGameArea.Controls.Add(this.tableGrid);
            this.panelGameArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGameArea.Location = new System.Drawing.Point(0, 104);
            this.panelGameArea.Name = "panelGameArea";
            this.panelGameArea.Size = new System.Drawing.Size(1000, 596);
            this.panelGameArea.TabIndex = 2;
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnCount = 4;
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.Location = new System.Drawing.Point(50, 50);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.RowCount = 4;
            this.tableGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableGrid.Size = new System.Drawing.Size(400, 400);
            this.tableGrid.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelGameArea);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Memory Game (Emoji)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelGameArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem difficulty4x4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficulty8x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficulty10x10ToolStripMenuItem;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblBestTime;
        private System.Windows.Forms.Label lblBestMoves;
        private System.Windows.Forms.Panel panelGameArea;
        private System.Windows.Forms.TableLayoutPanel tableGrid;
    }
}