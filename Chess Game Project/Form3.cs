using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Net.NetworkInformation;

namespace Chess_Game_Project
{
    public partial class Form3 : Form
    {
        List<Move> piece_moves;
        Piece source, destination;
        Piece[,] grid = new Piece[8, 8];
        PictureBox from;
        //  int m = 0;
        bool kingmove;
        string[] players = new string[2];
        string currentPlayer;
        Piece black_king, white_king;
        // bool king_checked = false;
        PictureBox bking, wking;
        Timer black_timer, white_timer;
        int b_min, b_sec, b_msec;
        int w_min, w_sec, w_msec;
        public Form3()
        {
            InitializeComponent();
        }
        TcpClient tcpClient;
        BinaryFormatter bf;
        NetworkStream ns;
        bool isMyTurn;
        string symbol, opsymbol;
        public Form3(TcpClient cl, string player)
        {
            symbol = player;
            tcpClient = cl;
            ns = tcpClient.GetStream();
            bf = new BinaryFormatter();
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            box00.Image = Properties.Resources.b_rook_1x;
            box01.Image = Properties.Resources.b_knight_1x;
            box02.Image = Properties.Resources.b_bishop_1x;
            box03.Image = Properties.Resources.b_queen_1x;
            box04.Image = Properties.Resources.b_king_1x;
            box05.Image = Properties.Resources.b_bishop_1x;
            box06.Image = Properties.Resources.b_knight_1x;
            box07.Image = Properties.Resources.b_rook_1x;
            box10.Image = Properties.Resources.b_pawn_1x;
            box11.Image = Properties.Resources.b_pawn_1x;
            box12.Image = Properties.Resources.b_pawn_1x;
            box13.Image = Properties.Resources.b_pawn_1x;
            box14.Image = Properties.Resources.b_pawn_1x;
            box15.Image = Properties.Resources.b_pawn_1x;
            box16.Image = Properties.Resources.b_pawn_1x;
            box17.Image = Properties.Resources.b_pawn_1x;
            box70.Image = Properties.Resources.w_rook_1x;
            box71.Image = Properties.Resources.w_knight_1x;
            box72.Image = Properties.Resources.w_bishop_1x;
            box73.Image = Properties.Resources.w_queen_1x;
            box74.Image = Properties.Resources.w_king_1x;
            box75.Image = Properties.Resources.w_bishop_1x;
            box76.Image = Properties.Resources.w_knight_1x;
            box77.Image = Properties.Resources.w_rook_1x;
            box60.Image = Properties.Resources.w_pawn_1x;
            box61.Image = Properties.Resources.w_pawn_1x;
            box62.Image = Properties.Resources.w_pawn_1x;
            box63.Image = Properties.Resources.w_pawn_1x;
            box64.Image = Properties.Resources.w_pawn_1x;
            box65.Image = Properties.Resources.w_pawn_1x;
            box66.Image = Properties.Resources.w_pawn_1x;
            box67.Image = Properties.Resources.w_pawn_1x;

            //Black Pieces
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j += 7)
                {
                    grid[i, j] = new Rook(Properties.Resources.b_rook_1x, i, j, Piece.PieceType.Rook, Piece.PieceColor.Black);
                }
            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 1; j < 8; j += 5)
                {
                    grid[i, j] = new Knight(Properties.Resources.b_knight_1x, i, j, Piece.PieceType.Knight, Piece.PieceColor.Black);
                }
            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 2; j < 8; j += 3)
                {
                    grid[i, j] = new Bishop(Properties.Resources.b_bishop_1x, i, j, Piece.PieceType.Bishop, Piece.PieceColor.Black);
                }
            }

            for (int i = 1; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j] = new Pawn(Properties.Resources.b_pawn_1x, i, j, Piece.PieceType.Pawn, Piece.PieceColor.Black);
                }
            }
            grid[0, 3] = new Queen(Properties.Resources.b_queen_1x, 0, 3, Piece.PieceType.Queen, Piece.PieceColor.Black);
            grid[0, 4] = new King(Properties.Resources.b_king_1x, 0, 4, Piece.PieceType.King, Piece.PieceColor.Black);

            //White Pieces
            for (int i = 7; i < 8; i++)
            {
                for (int j = 0; j < 8; j += 7)
                {
                    grid[i, j] = new Rook(Properties.Resources.w_rook_1x, i, j, Piece.PieceType.Rook, Piece.PieceColor.White);
                }
            }

            for (int i = 7; i < 8; i++)
            {
                for (int j = 1; j < 8; j += 5)
                {
                    grid[i, j] = new Knight(Properties.Resources.w_knight_1x, i, j, Piece.PieceType.Knight, Piece.PieceColor.White);
                }
            }

            for (int i = 7; i < 8; i++)
            {
                for (int j = 2; j < 8; j += 3)
                {
                    grid[i, j] = new Bishop(Properties.Resources.w_bishop_1x, i, j, Piece.PieceType.Bishop, Piece.PieceColor.White);
                }
            }

            for (int i = 6; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j] = new Pawn(Properties.Resources.w_pawn_1x, i, j, Piece.PieceType.Pawn, Piece.PieceColor.White);
                }
            }
            grid[7, 3] = new Queen(Properties.Resources.w_queen_1x, 7, 3, Piece.PieceType.Queen, Piece.PieceColor.White);
            grid[7, 4] = new King(Properties.Resources.w_king_1x, 7, 4, Piece.PieceType.King, Piece.PieceColor.White);

            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j] = new EmptyPiece(null, i, j, Piece.PieceType.Empty, Piece.PieceColor.None);
                }
            }

            players[0] = "White";
            players[1] = "Black";
            currentPlayer = "White";

            black_king = grid[0, 4];
            white_king = grid[7, 4];

            if (symbol == "White")
            {
                isMyTurn = true;
                opsymbol = "Black";
                lblturn.Text = "White Turn";
            }
            else
            {
                opsymbol = "White";
                new Thread(Listen).Start();
            }

            // Players Timer
            black_timer = new Timer();
            white_timer = new Timer();
            b_min = w_min = 5;
            b_sec = w_sec = 0;
            b_msec = w_msec = 100;
            lbltimeblack.Text = "05:00:00";
            lbltimerwhite.Text = "05:00:00";
            black_timer.Interval = 1;
            black_timer.Elapsed += OnTimeEventBlack;
            white_timer.Interval = 1;
            white_timer.Elapsed += OnTimeEventWhite;
            HandleTime();
            // Checking Time of Players
            new Thread(CheckTime).Start();
            blackkills.Controls.Clear();
            whitekills.Controls.Clear();
        }
        private void CheckTime()
        {
            bool valid = true;
            while (valid)
            {
                if (b_min == 0)
                {
                    MessageBox.Show("Black Time Up! You Win.");
                    valid = false;
                }
                if (w_min == 0)
                {
                    MessageBox.Show("White Time Up! You Win.");
                    valid = false;
                }
            }
        }
        void HandleTime()
        {
            if (currentPlayer == Piece.PieceColor.White.ToString())
            {
                white_timer.Start();
                black_timer.Stop();
            }
            if (currentPlayer == Piece.PieceColor.Black.ToString())
            {
                white_timer.Stop();
                black_timer.Start();
            }
        }

        private void OnTimeEventBlack(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                b_msec -= 1;
                if (b_msec == 0)
                {
                    b_msec = 100;
                    b_sec -= 1;
                }
                if (b_sec == 0)
                {
                    b_sec = 60;
                    b_min -= 1;
                }
                if (b_min == 0)
                {
                    black_timer.Stop();
                }
                lbltimeblack.Text = string.Format("{0}:{1}:{2}", b_min.ToString(), b_sec.ToString(), b_msec.ToString());
            }));
        }
        private void OnTimeEventWhite(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                w_msec -= 1;
                if (w_msec == 0)
                {
                    w_msec = 100;
                    w_sec -= 1;
                }
                if (w_sec == 0)
                {
                    w_sec = 60;
                    w_min -= 1;
                }
                if (w_min == 0)
                {
                    white_timer.Stop();
                }
                lbltimerwhite.Text = string.Format("{0}:{1}:{2}", w_min.ToString(), w_sec.ToString(), w_msec.ToString());
            }));
        }
        private void btnleft_Click(object sender, EventArgs e)
        {
            Main_Form f = new Main_Form();
            f.Show();
            this.Hide();
        }

        private void box00_Click(object sender, EventArgs e)
        {
            Selection(0, 0, box00);
        }

        private void box01_Click(object sender, EventArgs e)
        {
            Selection(0, 1, box01);
        }

        private void box02_Click(object sender, EventArgs e)
        {
            Selection(0, 2, box02);
        }

        private void box03_Click(object sender, EventArgs e)
        {
            Selection(0, 3, box03);
        }

        private void box04_Click(object sender, EventArgs e)
        {
            Selection(0, 4, box04);
        }

        private void box05_Click(object sender, EventArgs e)
        {
            Selection(0, 5, box05);
        }

        private void box06_Click(object sender, EventArgs e)
        {
            Selection(0, 6, box06);
        }

        private void box07_Click(object sender, EventArgs e)
        {
            Selection(0, 7, box07);
        }

        private void box10_Click(object sender, EventArgs e)
        {
            Selection(1, 0, box10);
        }

        private void box11_Click(object sender, EventArgs e)
        {
            Selection(1, 1, box11);
        }

        private void box12_Click(object sender, EventArgs e)
        {
            Selection(1, 2, box12);
        }

        private void box13_Click(object sender, EventArgs e)
        {
            Selection(1, 3, box13);
        }

        private void box14_Click(object sender, EventArgs e)
        {
            Selection(1, 4, box14);
        }

        private void box15_Click(object sender, EventArgs e)
        {
            Selection(1, 5, box15);
        }

        private void box16_Click(object sender, EventArgs e)
        {
            Selection(1, 6, box16);
        }

        private void box17_Click(object sender, EventArgs e)
        {
            Selection(1, 7, box17);
        }

        private void box20_Click(object sender, EventArgs e)
        {
            Selection(2, 0, box20);
        }

        private void box21_Click(object sender, EventArgs e)
        {
            Selection(2, 1, box21);
        }

        private void box22_Click(object sender, EventArgs e)
        {
            Selection(2, 2, box22);
        }

        private void box23_Click(object sender, EventArgs e)
        {
            Selection(2, 3, box23);
        }

        private void box24_Click(object sender, EventArgs e)
        {
            Selection(2, 4, box24);
        }

        private void box25_Click(object sender, EventArgs e)
        {
            Selection(2, 5, box25);
        }

        private void box26_Click(object sender, EventArgs e)
        {
            Selection(2, 6, box26);
        }

        private void box27_Click(object sender, EventArgs e)
        {
            Selection(2, 7, box27);
        }

        private void box30_Click(object sender, EventArgs e)
        {
            Selection(3, 0, box30);
        }

        private void box31_Click(object sender, EventArgs e)
        {
            Selection(3, 1, box31);
        }

        private void box32_Click(object sender, EventArgs e)
        {
            Selection(3, 2, box32);
        }

        private void box33_Click(object sender, EventArgs e)
        {
            Selection(3, 3, box33);
        }

        private void box34_Click(object sender, EventArgs e)
        {
            Selection(3, 4, box34);
        }

        private void box35_Click(object sender, EventArgs e)
        {
            Selection(3, 5, box35);
        }

        private void box36_Click(object sender, EventArgs e)
        {
            Selection(3, 6, box36);
        }

        private void box37_Click(object sender, EventArgs e)
        {
            Selection(3, 7, box37);
        }

        private void box40_Click(object sender, EventArgs e)
        {
            Selection(4, 0, box40);
        }

        private void box41_Click(object sender, EventArgs e)
        {
            Selection(4, 1, box41);
        }

        private void box42_Click(object sender, EventArgs e)
        {
            Selection(4, 2, box42);
        }

        private void box43_Click(object sender, EventArgs e)
        {
            Selection(4, 3, box43);
        }

        private void box44_Click(object sender, EventArgs e)
        {
            Selection(4, 4, box44);
        }

        private void box45_Click(object sender, EventArgs e)
        {
            Selection(4, 5, box45);
        }

        private void box46_Click(object sender, EventArgs e)
        {
            Selection(4, 6, box46);
        }

        private void box47_Click(object sender, EventArgs e)
        {
            Selection(4, 7, box47);
        }

        private void box50_Click(object sender, EventArgs e)
        {
            Selection(5, 0, box50);
        }

        private void box51_Click(object sender, EventArgs e)
        {
            Selection(5, 1, box51);
        }

        private void box52_Click(object sender, EventArgs e)
        {
            Selection(5, 2, box52);
        }

        private void box53_Click(object sender, EventArgs e)
        {
            Selection(5, 3, box53);
        }

        private void box54_Click(object sender, EventArgs e)
        {
            Selection(5, 4, box54);
        }

        private void box55_Click(object sender, EventArgs e)
        {
            Selection(5, 5, box55);
        }

        private void box56_Click(object sender, EventArgs e)
        {
            Selection(5, 6, box56);
        }

        private void box57_Click(object sender, EventArgs e)
        {
            Selection(5, 7, box57);
        }

        private void box60_Click(object sender, EventArgs e)
        {
            Selection(6, 0, box60);
        }

        private void box61_Click(object sender, EventArgs e)
        {
            Selection(6, 1, box61);
        }

        private void box62_Click(object sender, EventArgs e)
        {
            Selection(6, 2, box62);
        }

        private void box63_Click(object sender, EventArgs e)
        {
            Selection(6, 3, box63);
        }

        private void box64_Click(object sender, EventArgs e)
        {
            Selection(6, 4, box64);
        }

        private void box65_Click(object sender, EventArgs e)
        {
            Selection(6, 5, box65);
        }

        private void box66_Click(object sender, EventArgs e)
        {
            Selection(6, 6, box66);
        }

        private void box67_Click(object sender, EventArgs e)
        {
            Selection(7, 7, box67);
        }

        private void box70_Click(object sender, EventArgs e)
        {
            Selection(7, 0, box70);
        }

        private void box71_Click(object sender, EventArgs e)
        {
            Selection(7, 1, box71);
        }

        private void box72_Click(object sender, EventArgs e)
        {
            Selection(7, 2, box72);
        }

        private void box73_Click(object sender, EventArgs e)
        {
            Selection(7, 3, box73);
        }

        private void box74_Click(object sender, EventArgs e)
        {
            Selection(7, 4, box74);
        }

        private void box75_Click(object sender, EventArgs e)
        {
            Selection(7, 5, box75);
        }

        private void box76_Click(object sender, EventArgs e)
        {
            Selection(7, 6, box76);
        }

        private void box77_Click(object sender, EventArgs e)
        {
            Selection(7, 7, box77);
        }
        //Movement fucntion
        private bool Move(Piece sour, Piece des)
        {
            bool valid = true;
            if (sour.IsKing && sour.color == Piece.PieceColor.Black)
                black_king = sour;
            else if (sour.IsKing && sour.color == Piece.PieceColor.White)
                white_king = sour;
            int row, col;
            Piece destination_copy = des;
            Piece souce_copy = sour;
            row = sour.row;
            col = sour.column;
            sour.row = des.row;
            sour.column = des.column;
            grid[des.row, des.column] = sour;
            grid[row, col] = new EmptyPiece(null, row, col, Piece.PieceType.Empty, Piece.PieceColor.None);

            // Undo Move if King Check
            if (IsCheck())
            {
                souce_copy.row = row;
                souce_copy.column = col;
                grid[row, col] = souce_copy;
                grid[destination_copy.row, destination_copy.column] = destination_copy;
                valid = false;
            }
            sour = des = destination_copy = souce_copy = null;
            // Change Users Turn 
            if (valid)
            {
                if (!destination.IsEmpty)
                    Invoke(new Action(() => AddKillsPieces(destination)));
                currentPlayer = currentPlayer == players[0] ? players[1] : players[0];
                lblturn.Text = lblturn.Text == "White Turn" ? "Black Turn" : "White Turn";
                HandleTime();
            }
            return valid;
        }
        int bc = 0, br = 0;
        int wc = 0, wr = 0;
        private void AddKillsPieces(Piece obj)
        {
            if (obj.color == Piece.PieceColor.Black)
            {
                blackkills.Controls.Add(new PictureBox()
                {
                    Image = obj.image,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill,
                    Width = 20,
                    Height = 20
                }, bc, br);
                bc++;
                if (bc == 8)
                {
                    bc = 0;
                    br = 1;
                }
            }
            else if (obj.color == Piece.PieceColor.White)
            {
                whitekills.Controls.Add(new PictureBox()
                {
                    Image = obj.image,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill,
                    Width = 20,
                    Height = 20
                }, wc, wr);
                wc++;
                if (wc == 8)
                {
                    wc = 0;
                    wr = 1;
                }
            }
        }

        private void Listen()
        {
            isMyTurn = false;
            string msg = (string)bf.Deserialize(ns);
            if (msg != String.Empty)
            {
                string[] locations = msg.Split(':');
                string[] sour = locations[0].Split(',');
                int sour_row = int.Parse(sour[0]);
                int sour_col = int.Parse(sour[1]);
                string[] des = locations[1].Split(',');
                int des_row = int.Parse(des[0]);
                int des_col = int.Parse(des[1]);
                source = grid[sour_row, sour_col];
                destination = grid[des_row, des_col];
                Move(source, destination);
                PictureBox sourcebox = (PictureBox)this.Controls.Find("box" + sour_row + "" + sour_col, true)[0];
                PictureBox destinationbox = (PictureBox)this.Controls.Find("box" + des_row + "" + des_col, true)[0];
                destinationbox.Image = sourcebox.Image;
                sourcebox.Image = null;
                ChangeColor();
                if (IsCheck())
                    IsSafeKing();
                isMyTurn = true;
            }
        }

        private void btnleft_Click_1(object sender, EventArgs e)
        {
            white_timer.Stop();
            black_timer.Stop();
            Main_Form f = new Main_Form();
            f.Show();
            this.Hide();
        }

        void Selection(int row, int col, PictureBox pic)
        {
            if (grid[row, col].color.ToString() == currentPlayer && currentPlayer == symbol && b_min != 0 && w_min != 0)
            {
                if (IsCheck())
                {
                    IsSafeKing();
                    /*bool ischecked = IsSafeKing();
                    if (!grid[row, col].IsKing)
                        return;*/
                }
                if (from != null)
                    from.BackgroundImage = null;
                from = pic;
                from.BackgroundImage = Properties.Resources._2880x1800_light_green_solid_colo;
                source = grid[row, col];
                piece_moves = source.GetAllMoves();
            }
            else if (source != null)
            {
                var cell = piece_moves.Where(p => p.rownumber == row && p.columnnumber == col).FirstOrDefault();
                destination = grid[row, col];
                bool valid = false;
                if (cell != null && source.color != destination.color)
                {
                    if (source.IsRook)
                    {
                        valid = RookAvailable(source, destination);
                    }
                    else if (source.IsBishop)
                    {
                        valid = BishopAvailable(source, destination);
                    }
                    else if (source.IsPawn)
                    {
                        valid = PawnAvailable(source, destination);
                    }
                    else if (source.IsQueen)
                    {
                        valid = QueenAvailable(source, destination);
                    }
                    else if (source.IsKing)
                    {
                        kingmove = true;
                        valid = KingAvailable(destination);
                        kingmove = false;
                    }
                    else if (source.IsKnight)
                    {
                        valid = true;
                    }
                    if (valid)
                    {
                        string msg = source.row + "," + source.column + ":" + destination.row + "," + destination.column;
                        if (Move(source, destination))
                        {
                            pic.Image = from.Image;
                            from.Image = null;
                            from.BackgroundImage = null;
                            ChangeColor();
                            if (IsCheck())
                                IsSafeKing();
                            bf.Serialize(ns, msg);
                            new Thread(Listen).Start();
                        }
                    }
                }
            }
        }

        private void ChangeColor()
        {
            string black = "box" + black_king.row + "" + black_king.column;
            string white = "box" + white_king.row + "" + white_king.column;
            bking = (PictureBox)this.Controls.Find(black, true)[0];
            wking = (PictureBox)this.Controls.Find(white, true)[0];
            if (IsCheck() && currentPlayer == Piece.PieceColor.Black.ToString())
            {
                bking.BackgroundImage = Properties.Resources.move_color;
            }
            else if (IsCheck() && currentPlayer == Piece.PieceColor.White.ToString())
            {
                wking.BackgroundImage = Properties.Resources.move_color;
            }
            if (!IsCheck())
            {
                bking.BackgroundImage = null;
                wking.BackgroundImage = null;
            }
        }
        private bool KingAvailable(Piece t_destination)
        {
            bool valid = true;
            for (int rowindex = 0; rowindex < 8; rowindex++)
            {
                for (int colindex = 0; colindex < 8; colindex++)
                {
                    List<Move> temp_moves = new List<Move>();
                    if (grid[rowindex, colindex].color.ToString() != currentPlayer && !grid[rowindex, colindex].IsEmpty)
                    {
                        Piece temp_source = grid[rowindex, colindex];
                        temp_moves = temp_source.GetAllMoves();
                        var have_move = temp_moves.Where(n => n.rownumber == t_destination.row && n.columnnumber == t_destination.column).FirstOrDefault();
                        if (have_move != null)
                        {
                            if (temp_source.IsPawn)
                            {
                                if (temp_source.color == Piece.PieceColor.Black && t_destination.row > temp_source.row && t_destination.column != temp_source.column) return false;
                                else if (temp_source.color == Piece.PieceColor.White && t_destination.row < temp_source.row && t_destination.column != temp_source.column) return false;
                            }
                            else if (temp_source.IsRook)
                            {
                                if (RookAvailable(temp_source, t_destination)) return false;
                            }
                            else if (temp_source.IsBishop)
                            {
                                if (BishopAvailable(temp_source, t_destination)) return false;
                            }
                            else if (temp_source.IsKnight) return false;
                            else if (temp_source.IsQueen)
                            {
                                if (QueenAvailable(temp_source, t_destination)) return false;
                            }
                        }
                    }
                }
            }
            return valid;
        }
        private bool IsSafeKing()
        {
            List<Move> bking_moves = black_king.GetAllMoves();
            List<Move> wking_moves = white_king.GetAllMoves();
            int b, w;
            b = w = 0;
            foreach (Move move in bking_moves)
            {
                if (move.rownumber >= 0 && move.rownumber < 8 && move.columnnumber >= 0 && move.columnnumber < 8)
                {
                    if (grid[move.rownumber, move.columnnumber].color.ToString() == currentPlayer) b++;
                    else if (!KingAvailable(grid[move.rownumber, move.columnnumber])) b++;
                }
                else b++;
            }
            foreach (Move move in wking_moves)
            {
                if (move.rownumber >= 0 && move.rownumber < 8 && move.columnnumber >= 0 && move.columnnumber < 8)
                {
                    if (grid[move.rownumber, move.columnnumber].color.ToString() == currentPlayer) w++;
                    else if (!KingAvailable(grid[move.rownumber, move.columnnumber])) w++;
                }
                else w++;
            }
            if (b == 8)
            {
                MessageBox.Show("Game End! Black Lose " + b);
                return true;
            }
            if (w == 8)
            {
                MessageBox.Show("Game End! White Lose " + w);
                return true;
            }
            return false;
        }
        private bool IsCheck()
        {
            bool valid = false;
            if (Piece.PieceColor.Black.ToString() == currentPlayer)
            {
                valid = KingAvailable(black_king) ? false : true;
            }
            else if (Piece.PieceColor.White.ToString() == currentPlayer)
            {
                valid = KingAvailable(white_king) ? false : true;
            }
            return valid;
        }

        private bool QueenAvailable(Piece temp_source, Piece temp_destination)
        {
            bool valid = false;
            if (kingmove && (BishopAvailable(temp_source, temp_destination) || RookAvailable(temp_source, temp_destination)))
                valid = true;
            if (!kingmove)
            {
                valid = BishopAvailable(temp_source, temp_destination);
                valid = valid == true ? RookAvailable(temp_source, temp_destination) : valid;
            }
            return valid;
        }

        private bool PawnAvailable(Piece temp_source, Piece temp_destination)
        {
            bool valid = false;
            // white kill move
            if (!destination.IsEmpty && destination.column != source.column && source.color == Piece.PieceColor.White && destination.row < source.row)
            {
                valid = true;
            }
            // black kill move
            else if (!destination.IsEmpty && destination.column != source.column && source.color == Piece.PieceColor.Black && destination.row > source.row)
            {
                valid = true;
            }
            // single row of white
            else if (source.color == Piece.PieceColor.White && destination.row < source.row && destination.column == source.column && destination.IsEmpty && source.row - destination.row != 2)
            {
                valid = true;
            }
            // single row of black
            else if (source.color == Piece.PieceColor.Black && destination.row > source.row && destination.column == source.column && destination.IsEmpty && destination.row - source.row != 2)
            {
                valid = true;
            }
            // double row of white
            else if (source.color == Piece.PieceColor.White && source.row == 6 && destination.row == 4 && destination.row < source.row && destination.column == source.column && destination.IsEmpty)
            {
                valid = true;
            }
            // double row of black
            else if (source.color == Piece.PieceColor.Black && source.row == 1 && destination.row == 3 && destination.row > source.row && destination.column == source.column && destination.IsEmpty)
            {
                valid = true;
            }

            return valid;
        }

        private bool BishopAvailable(Piece temp_source, Piece temp_destination)
        {
            bool valid = true;
            int sind = temp_source.row;
            int eind = temp_destination.row;
            if (temp_destination.row > temp_source.row && temp_destination.column > temp_source.column)
            {
                int i = temp_source.row + 1;
                int j = temp_source.column + 1;
                while (temp_destination.row > i)
                {
                    if (grid[i, j].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                    i++; j++;
                }
            }
            else if (temp_destination.row > temp_source.row && temp_destination.column < temp_source.column)
            {
                int j = temp_source.column - 1;
                for (int i = sind + 1; i < eind; i++)
                {
                    if (grid[i, j].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                    j--;
                }
            }
            else if (temp_destination.column > temp_source.column && temp_destination.row < temp_source.row)
            {
                int j = temp_source.column + 1;
                for (int i = sind - 1; i > eind; i--)
                {
                    if (grid[i, j].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                    j++;
                }
            }
            else if (temp_destination.column < temp_source.column && temp_destination.row < temp_source.row)
            {
                int j = temp_source.column - 1;
                for (int i = sind - 1; i > eind; i--)
                {
                    if (grid[i, j].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                    j--;
                }
            }
            else if (kingmove) return false;
            return valid;
        }

        private bool RookAvailable(Piece temp_source, Piece temp_destination)
        {
            bool valid = true;
            int sind = temp_source.row;
            int eind = temp_destination.row;
            if (temp_destination.row > temp_source.row && temp_destination.column == temp_source.column)
            {
                for (int i = sind + 1; i < eind; i++)
                {
                    if (grid[i, temp_destination.column].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            else if (temp_destination.row < temp_source.row && temp_destination.column == temp_source.column)
            {
                for (int i = sind - 1; i > eind; i--)
                {
                    if (grid[i, temp_destination.column].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            else if (temp_destination.column > temp_source.column && temp_destination.row == temp_source.row)
            {
                int i = temp_source.column;
                int j = temp_destination.column;
                for (i = i + 1; i < j; i++)
                {
                    if (grid[temp_destination.row, i].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            else if (temp_destination.column < temp_source.column && temp_destination.row == temp_source.row)
            {
                int i = temp_source.column;
                int j = temp_destination.column;
                for (i = i - 1; i > j; i--)
                {
                    if (grid[temp_destination.row, i].piece != Piece.PieceType.Empty)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            else if (kingmove) return false;
            return valid;
        }
    }
}
