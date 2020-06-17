using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace お花屋さん始めました_
{
    class Class1 : Form
    {
        Rectangle Rect1  = new Rectangle(0, 540, 330, 60);
        Rectangle Rect1a = new Rectangle(330, 540, 150, 60);
        Rectangle Rect2  = new Rectangle(0, 475, 330, 60);
        Rectangle Rect2a = new Rectangle(330, 475, 150, 60);
        Rectangle Rect3  = new Rectangle(0, 410, 330, 60);
        Rectangle Rect3a = new Rectangle(330, 410, 150, 60);
        Rectangle Rect4  = new Rectangle(0, 0, 300, 80);
        Rectangle Rect5  = new Rectangle(0, 300, 500, 100);
        Rectangle Rect6  = new Rectangle(505, 505, 200, 175);
        Rectangle Rect7  = new Rectangle(500, 425, 200, 175);
        Bitmap Fbm;
        Bitmap Bbm;
        Random Radm1 = new Random();
        Timer tm   = new Timer();
        Timer tmM  = new Timer();
        TextBox tb = new TextBox();
        Label[] lb = new Label[9];
        Label lba = new Label();
        Label lba1 = new Label();
        //List<string> lines;
        string buy        = "花を入荷する";
        string debt       = "借金をする";
        string debtreturn = "借金を返す";
        int flower    = 0;   //花の在庫
        int floweryen = 100; //花の入荷額
        int debtyen   = 100; //借金額
        int fy        = 250; //花の販売定価額（floweryenの略）
        int dy        = 0;   //借金の額（debtyenの略）
        int money     = 2000;//所持金
        int k         = 0;   //lbの描画時の調査の使用する値
        int Research1  = 0;
        int Ok = 0;
        int s1 = 255;
        int s2 = 0;
        int s3 = 0;
        int sGo = 0;
        int sOpen = 0;
        int sClose = 255;
        int r1;
        int r2;
        int r3;

        Font F18b = new Font("BIZ UDB ゴシック", 18);
        Font F28b = new Font("BIZ UDB ゴシック", 28);
        Font F38b = new Font("BIZ UDB ゴシック", 38);
        Font F54b = new Font("BIZ UDB ゴシック", 54);
        Font F64b = new Font("BIZ UDB ゴシック", 64);

        SolidBrush sbGreen = new SolidBrush(Color.Green);
        SolidBrush sbYello = new SolidBrush(Color.Yellow);
        SolidBrush sbBlack = new SolidBrush(Color.Black);
        SolidBrush sbArgb1 = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
        SolidBrush sbArgb2 = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        SolidBrush sbArgb3 = new SolidBrush(Color.FromArgb(255, 150, 150, 0));

        public Class1()
        {
            ClientSize = new Size(1000, 600);
            DoubleBuffered = true;
            while(Ok < 1)
            {
                MessageBox.Show("このゲームは借金をすることは許されますが、所持金が0未満になることは許されません！", "ルール！！");
                MessageBox.Show("このゲームでは、お店を維持するためのお金として毎秒100円減ります！（ゲーム内通貨です。）", "ルール！！");
                DialogResult dr = MessageBox.Show("ルールをちゃんと読んで理解しましたか？", "注意！！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    Ok = 1;
                }
            }
            

            for (int i = 0; i < lb.Length; i++)
            {
                lb[i] = new Label();
                lb[i].ForeColor = Color.White;
                lb[i].Left = 700;
                lb[i].Width = 300;
                lb[i].Height += 40;
                lb[i].Top = lb[i].Height * i + 5;
                lb[i].Font = F18b;
                lb[i].BackColor = Color.Transparent;
                lb[i].Parent = this;
            }


            tb.Left = 700;
            tb.Width = 300;
            tb.Height = 600;

            tb.Multiline = true;

            //lines = new List<string>(tb.Lines);
            //lines.RemoveAt(1); // 2行目削除
            //tb.Text = String.Join("\r\n", lines);

            //tb.Parent = this;

            tm.Interval = 900;
            tmM.Interval = 1000;

            tmM.Start();

            tm.Tick += timer;
            tmM.Tick += timerM;
            MouseDown += mouse;
        }

        public void timer(object sender, EventArgs e)
        {
            switch (Research1)
            {
                case 0:

                    r1 = Radm1.Next(0, 2);
                    if(r1 == 0)
                    {
                        lba.Text = "・・・";
                        k = 1;
                        log();
                    }
                    if (r1 > 0)
                    {
                        r2 = Radm1.Next(1, 6);
                        Console.WriteLine(r2);
                        lba.Text = "お客様が" + r2 + "人入店しました！";
                        k = 1;
                        log();
                        if(flower == 0)
                        {
                            lba.Text = "しかし、商品の在庫がないため帰りました。";
                            k = 1;
                            log();
                        }
                        Research1 = 1;
                    }

                    break;


                case 1:

                    if (flower > 0)
                    {
                        r3 = Radm1.Next(1, r2 + 2);
                        flower -= r3;
                        if(flower < 0)
                        {
                            while(flower < 0)
                            {
                                flower++;
                                r3--;
                            }
                        }
                        money += fy * r3;
                        lba.Text = "花を合計" + r3 + "つ購入していきました。";
                        lba1.Text = "所持金：" + money;
                        k = 2;
                        log();                //lines.RemoveAt(0);
                                              //tb.Text = String.Join("\r\n", lines);
                        if (flower == 0)
                        {
                            lba.Text = "花の在庫が無くなりました！！";
                            k = 1;
                            log();
                        }
                    }
                    Research1 = 0;

                    break;
            }

            Invalidate();
        }

        public void timerM(object sender, EventArgs e)
        {
            money -= 100;
            Invalidate();
            if(money < 0)
            {
                GameOver();
            }
        }

        public void mouse(object sender, MouseEventArgs e)
        {
            if(Rect1.Contains(e.X, e.Y) && money >= 0)
            {
                if (s1 == 255)
                {
                    flower++;
                    money -= floweryen;
                    lba.Text = "花を入荷しました";
                    k = 1;
                }
                else if(s1 == 0)
                {
                    lba.Text = "開店中は入荷できません!!!";
                    k = 1;
                }
                
                log();
            }
            if(Rect2.Contains(e.X, e.Y) && money >= 0)
            {
                money += 100;
                dy += 100;
                if(dy > 0)
                {
                    s3 = 255;
                }
            }
            if(Rect3.Contains(e.X, e.Y) && money >= 0 && s3 == 255)
            {
                money -= 100;
                dy -= 100;
                if(dy <= 0)
                {
                    s3 = 0;
                }
            }
            if(Rect4.Contains(e.X, e.Y) && money >= 0)
            {
                switch (s1)
                {
                    case 255:

                        lba.Text = "お店を開店しました。";
                        s1 = 0;
                        s2 = 255;
                        sOpen = 255;
                        sClose = 0;
                        tm.Start();

                        break;

                    case 0:

                        lba.Text = "お店を閉店しました。";
                        s1 = 255;
                        s2 = 0;
                        sOpen = 0;
                        sClose = 255;
                        tm.Stop();

                        break;
                }

                k = 1;
                log();
            }

            if (money < 0)
            {
                GameOver();
            }

            Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            var bmf = new Bitmap("flower.png");
            Fbm = bmf;

            var bmb = new Bitmap("board.png");
            Bbm = bmb;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush sbArgbs1     = new SolidBrush(Color.FromArgb(s1, 255, 255, 255));
            SolidBrush sbArgbs2     = new SolidBrush(Color.FromArgb(s2, 255, 255, 255));
            SolidBrush sbArgbs3     = new SolidBrush(Color.FromArgb(s3, 150, 150, 0));
            SolidBrush sbArgbs4     = new SolidBrush(Color.FromArgb(s3, 255, 255, 0));
            SolidBrush sbArgbs5     = new SolidBrush(Color.FromArgb(s3, 0, 0, 0));
            SolidBrush sbArgbsGo    = new SolidBrush(Color.FromArgb(sGo, 255, 0, 0));
            SolidBrush sbArgbsOpen  = new SolidBrush(Color.FromArgb(sOpen, 0, 0, 0));
            SolidBrush sbArgbsClose = new SolidBrush(Color.FromArgb(sClose, 0, 0, 0));




            g.FillRectangle(sbGreen, 0, 0, 1000, 600);
            g.FillRectangle(sbArgb1, 700, 0, 300, 600);
            g.FillRectangle(sbArgb2, Rect4);
            //g.FillRectangle(sbArgb2, Rect3);
            g.FillRectangle(sbYello, Rect1);
            g.FillRectangle(sbYello, Rect2);
            g.FillRectangle(sbArgbs4, Rect3);
            g.FillRectangle(sbArgb3, Rect1a);
            g.FillRectangle(sbArgb3, Rect2a);
            g.FillRectangle(sbArgbs3, Rect3a);
            //g.FillRectangle(sbYello, 0, 0, 320, 80);
            g.DrawString(buy, F38b, sbBlack, Rect1);
            g.DrawString(debt, F38b, sbBlack, Rect2);
            g.DrawString(debtreturn, F38b, sbArgbs5, Rect3);
            g.DrawString(floweryen + "円", F38b, sbBlack, 330, 540);
            g.DrawString(debtyen + "円", F38b, sbBlack, 330, 475);
            g.DrawString(debtyen + "円", F38b, sbArgbs5, 330, 410);
            g.DrawString(" × " + flower, F64b, sbBlack, 100, 100);
            g.DrawString("所持金:" + money + "円", F64b, sbBlack, 0, 200);
            g.DrawString("   開店", F54b, sbArgbs1, Rect4);
            g.DrawString("   閉店", F54b, sbArgbs2, Rect4);
            g.DrawString("借金 : " + dy + "円", F54b, sbArgbs5, 0, 300);
            g.DrawString("ＧＡＭＥ　ＯＶＥＲ", F64b, sbArgbsGo, 0, 0);

            g.DrawImage(Fbm, 0, 100, 100, 100);
            g.DrawImage(Bbm, Rect7);

            g.DrawString("開店中", F38b, sbArgbsOpen, Rect6);
            g.DrawString("閉店中", F38b, sbArgbsClose, Rect6);
        }

        public static void Main()
        {
            Application.Run(new Class1());
        }

        void GameOver()
        {
            sGo = 255;
            tm.Stop();
            tmM.Stop();
            MessageBox.Show("あなたはお金を使いすぎました。", "残念です。", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void log()
        {
            if(k == 1)
            {
                for(int i =  1; i < lb.Length; i++)
                {
                    lb[i - 1].Text = lb[i].Text;
                }
                lb[8].Text = lba.Text;
                k = 0;
            }
            else if(k == 2)
            {
                while (k > 0)
                {
                    for (int i = 1; i < lb.Length; i++)
                    {
                        lb[i - 1].Text = lb[i].Text;
                    }
                    lb[8].Text = lba.Text;
                    lba.Text = lba1.Text;
                    k--;
                }
            }
            Invalidate();
        }
    }
}
