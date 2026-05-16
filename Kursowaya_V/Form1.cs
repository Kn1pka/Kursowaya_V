using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Kursowaya_V
{
    public partial class Form1 : Form
    {
        // База эмодзи (50 штук, без пропусков)
private readonly string[] Emojis = {
            "🐶", "🐱", "🐭", "🍎", "🐰", "🦊", "🐻", "🍊", "🐨", "🐯",
            "🦁", "🍋", "🐷", "🐸", "🐵", "🍌", "🍉", "🐦", "🐤", "🦆",
            "🦅", "🦉", "🦇", "🍇", "🐗", "🐴", "🦄", "🍒", "🐛", "🦋",
            "🐌", "🐞", "🐜", "🍓", "🦗", "🕷", "🦂", "🍑", "🐍", "🦎",
            "🦖", "🦕", "🐙", "❤️", "💔", "🦞", "🦀", "🐡", "🐠", "🍍"
        };

        // Public accessor for tests
        public string[] GetEmojis() => Emojis;

        // Public accessors for unit tests
        [System.ComponentModel.Browsable(false)]
        public int MoveCount { get => moveCount; set => moveCount = value; }
        [System.ComponentModel.Browsable(false)]
        public int Seconds { get => seconds; set => seconds = value; }
        [System.ComponentModel.Browsable(false)]
        public int GridSize => gridSize;

        private int gridSize = 4; // Текущий размер сетки (4, 8 или 10)
        private int moveCount = 0; // Счётчик ходов
        private int seconds = 0; // Счётчик секунд
        private Timer? gameTimer; // Таймер игры
        private List<Button> flippedCards = new List<Button>(); // Список открытых карт
        private int matchedPairs = 0; // Количество найденных пар
        private bool isPaused = false; // Флаг паузы

        // Переменные для рекордов (public для тестов)
        public int bestTime = 0;    // 0 = рекорд ещё не установлен
        public int bestMoves = 0;   // 0 = рекорд ещё не установлен

        public Form1()
        {
            InitializeComponent();

            // Добавляем кнопку "Пауза" программно в меню
            ToolStripMenuItem pauseItem = new ToolStripMenuItem("⏸ Пауза");
            pauseItem.Name = "pauseToolStripMenuItem";
            pauseItem.Click += PauseGame;
            fileToolStripMenuItem.DropDownItems.Insert(2, pauseItem);

            // Настройка таймера
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 секунда
            gameTimer.Tick += GameTimer_Tick;

            // Привязка событий меню
            newGameToolStripMenuItem.Click += (s, e) => StartGame(gridSize);
            difficulty4x4ToolStripMenuItem.Click += (s, e) => { gridSize = 4; StartGame(4); };
            difficulty8x8ToolStripMenuItem.Click += (s, e) => { gridSize = 8; StartGame(8); };
            difficulty10x10ToolStripMenuItem.Click += (s, e) => { gridSize = 10; StartGame(10); };

            StartGame(4); // Запуск с уровнем 4x4 по умолчанию
        }

        // Метод запуска/перезапуска игры
        public void StartGame(int size)
        {
            gridSize = size;
            matchedPairs = 0;
            moveCount = 0;
            seconds = 0;
            isPaused = false;
            flippedCards.Clear();

            // Сброс интерфейса
            lblMoves.Text = "Ходы: 0";
            lblTime.Text = "Время: 00";
            lblDifficulty.Text = $"Режим: {size}x{size}";

            // Сброс кнопки паузы
            ToolStripItem? pauseBtn = fileToolStripMenuItem.DropDownItems["pauseToolStripMenuItem"];
            if (pauseBtn != null) pauseBtn.Text = "⏸ Пауза";

            // Перезапуск таймера
            gameTimer?.Stop();
            gameTimer?.Start();

            BuildGrid(size); // Построение игрового поля
            ToggleFieldLock(false); // Разблокировка поля
        }

        // Метод построения игрового поля
        private void BuildGrid(int size)
        {
            // Очистка старой сетки
            tableGrid.Controls.Clear();
            tableGrid.ColumnStyles.Clear();
            tableGrid.RowStyles.Clear();

            // Настройка количества строк и столбцов
            tableGrid.ColumnCount = size;
            tableGrid.RowCount = size;

            // Расчёт размера ячейки (уменьшаем для больших сеток)
            int cellSize = size == 4 ? 100 : (size == 8 ? 70 : 60);

            // Добавление стилей для равномерного распределения (Percent вместо Absolute!)
            for (int i = 0; i < size; i++)
            {
                tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / size));
                tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / size));
            }

            // УБРАНО +50 — теперь размер ТОЧНО равен size * cellSize (квадраты не растягиваются)
            tableGrid.Size = new Size(size * cellSize, size * cellSize);

            // Центрирование поля в панели
            int startX = (panelGameArea.Width - tableGrid.Width) / 2;
            int startY = (panelGameArea.Height - tableGrid.Height) / 2;

            if (startX < 10) startX = 10;
            if (startY < 10) startY = 10;

            tableGrid.Location = new Point(startX, startY);

            // Генерация пар карт
            int totalCards = size * size;
            int pairsNeeded = totalCards / 2;

            List<string> cardValues = new List<string>();
            for (int i = 0; i < pairsNeeded; i++)
            {
                string emoji = Emojis[i % Emojis.Length]; // Зацикливаем, если эмодзи не хватит
                cardValues.Add(emoji);
                cardValues.Add(emoji);
            }

            // Перемешивание карт (алгоритм Фишера-Йейтса)
            Shuffle(cardValues);

            // Создание кнопок-карт
            foreach (string emoji in cardValues)
            {
                Button btn = new Button();
                btn.Text = ""; // Изначально карта скрыта
                btn.Tag = emoji; // В Tag храним эмодзи

                // УМЕНЬШЕН шрифт: было cellSize/2, стало cellSize/2.5f (эмодзи помещаются)
                float fontSize = cellSize / 2.5f;
                btn.Font = new Font("Segoe UI Emoji", fontSize, FontStyle.Bold);

                btn.BackColor = Color.WhiteSmoke;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Dock = DockStyle.Fill;
                btn.Margin = new Padding(3); // Чуть больше отступ между картами
                btn.Padding = new Padding(0); // Убираем внутренний отступ
                btn.TextAlign = ContentAlignment.MiddleCenter; // Центрируем эмодзи
                btn.UseVisualStyleBackColor = false; // Важно для корректного отображения цвета

                btn.Click += Card_Click; // Подписка на клик
                tableGrid.Controls.Add(btn); // Добавление в сетку
            }
        }

        // Обработчик клика по карте (async для неблокирующей паузы)
        private async void Card_Click(object? sender, EventArgs e)
        {
            if (sender is not Button clickedCard) return;
            if (isPaused) return; // Если пауза — игнорируем клик

            // Игнорируем, если карта уже открыта или найдена
            if (clickedCard.Text != "" || flippedCards.Contains(clickedCard)) return;

            // Открываем карту: показываем эмодзи
            clickedCard.Text = clickedCard.Tag?.ToString() ?? "";
            clickedCard.BackColor = Color.LightYellow;
            flippedCards.Add(clickedCard);

            // Если открыты 2 карты — проверяем совпадение
            if (flippedCards.Count == 2)
            {
                moveCount++;
                lblMoves.Text = $"Ходы: {moveCount}";

                if (flippedCards[0].Tag?.ToString() == flippedCards[1].Tag?.ToString())
                {
                    // СОВПАДЕНИЕ! Оставляем карты открытыми
                    flippedCards[0].BackColor = Color.LightGreen;
                    flippedCards[1].BackColor = Color.LightGreen;
                    flippedCards.Clear();
                    matchedPairs++;

                    // Проверка победы
                    if (matchedPairs == (gridSize * gridSize) / 2)
                    {
                        gameTimer?.Stop();
                        CheckRecords(); // Проверка рекордов
                        MessageBox.Show(
                            $"Победа!\nХодов: {moveCount}\nВремя: {seconds} сек.",
                            "Поздравляем!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // НЕ СОВПАЛИ — закрываем через паузу
                    Button first = flippedCards[0];
                    Button second = flippedCards[1];
                    flippedCards.Clear();

                    // Блокируем поле на время анимации
                    ToggleFieldLock(true);

                    // НЕблокирующая задержка (таймер продолжает идти!)
                    await Task.Delay(700);

                    // Закрываем карты
                    first.Text = "";
                    first.BackColor = Color.WhiteSmoke;
                    second.Text = "";
                    second.BackColor = Color.WhiteSmoke;

                    // Разблокируем поле
                    ToggleFieldLock(false);
                }
            }
        }

        // Проверка и обновление рекордов (PUBLIC для тестов!)
        public void CheckRecords()
        {
            // Проверка времени
            if (bestTime == 0 || seconds < bestTime)
            {
                bestTime = seconds;
                lblBestTime.Text = $"Рекорд: {bestTime} сек";
            }

            // Проверка ходов
            if (bestMoves == 0 || moveCount < bestMoves)
            {
                bestMoves = moveCount;
                lblBestMoves.Text = $"Рекорд: {bestMoves} ходов";
            }
        }

        // Обработчик кнопки "Пауза"
        private void PauseGame(object? sender, EventArgs e)
        {
            ToolStripMenuItem? item = sender as ToolStripMenuItem;
            if (item == null) return;

            if (isPaused)
            {
                // ВОЗОБНОВИТЬ
                isPaused = false;
                gameTimer?.Start();
                item.Text = "⏸ Пауза";
                ToggleFieldLock(false);
            }
            else
            {
                // ПРИОСТАНОВИТЬ
                isPaused = true;
                gameTimer?.Stop();
                item.Text = "▶ Продолжить";
                ToggleFieldLock(true);
            }
        }

        // Вспомогательный метод: блокировка/разблокировка поля
        private void ToggleFieldLock(bool isLocked)
        {
            foreach (Control c in tableGrid.Controls)
            {
                if (c is Button b) b.Enabled = !isLocked;
            }
        }

        // Обработчик тика таймера
        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            seconds++;
            lblTime.Text = $"Время: {seconds}";
        }

        // Перемешивание списка (алгоритм Фишера-Йейтса) — PUBLIC для тестов!
        public void Shuffle(List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}