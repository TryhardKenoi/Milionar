using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Milionar
{
    public partial class Form1 : Form
    {
        private int stupen = 0;
        private Otazka aktualniOtazka;
        private Random random = new Random();
        private List<Otazka> otazky = new List<Otazka>();
        SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\znelka.wav");
        ImageList photoList = new ImageList();

        public Form1()
        {
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup0.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup1.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup2.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup3.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup4.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup5.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup6.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup7.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup8.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup9.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\postup10.jpg"));
            photoList.Images.Add(Image.FromFile(@"C:\Users\kenoi\source\repos\Milionar\Milionar\Resources\background.jpg"));

            InitializeComponent();

            otazky.Add(new Otazka(
                0,
                "Jaké je hlavní město Thajska?",
                new string[4] { "Bangkok", "Tokyo", "Sapporo", "Singapur" },
                0
            ));

            otazky.Add(new Otazka(
                0,
                "Jak se máš?",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));

            otazky.Add(new Otazka(
                1,
                "Jak se máš?2",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));

            otazky.Add(new Otazka(
                2,
                "Jsi piča",
                new string[4] { "jo", "jasně", "jojjo", "tak určitě" },
                0
            ));
            otazky.Add(new Otazka(
                3,
                "Jak se máš?22aa",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));
            otazky.Add(new Otazka(
                3,
                "Jak se máš?22sdasdsadasdsadassadasdasdsadasdasaa",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));
            otazky.Add(new Otazka(
                4,
                "Jak se máš?22asddasdadsaxexeexea",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));
            otazky.Add(new Otazka(
                4,
                "Jak se máš?22aasdada",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));
            otazky.Add(new Otazka(
                5,
                "Jak se máš?22aa¨dsadasda",
                new string[4] { "Nejlíp na druhou", "Dobře", "Skvěle", "Nejlíp" },
                0
            ));

            zobrazOtazku();
        }

        private void zobrazOtazku()
        {
            Otazka otazka = ziskejOtazkuPodleStupne(stupen);
            if (otazka == null)
            {
                Console.WriteLine("Chyba. nebyla nalezena zadna otazka stupne MAX BYL ZDE");
                MessageBox.Show("Vyhrál jsi dicku");
                return;

            }

            List<String> list = new List<String>(otazka.odpovedi);

            string[] odpovedi = new string[4];
            Boolean naslo = false;
            for (int i = 0; i < 4; i++)
            {
                int randomCislo = random.Next(list.Count);
                string odpoved = list[randomCislo];
                if (otazka.odpovedi[otazka.spravnaOdpoved].Equals(odpoved) && !naslo)
                {
                    otazka.spravnaOdpoved = i;
                    naslo = true;
                }
                odpovedi[i] = odpoved;
                list.Remove(odpoved);
            }
            otazka.odpovedi = odpovedi;
            Console.WriteLine(otazka.odpovedi);

            //string[] odpovedi = otazka.odpovedi.OrderBy(x => random.Next()).ToArray();
            label1.Text = otazka.otazka;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button1.Text = "A) " + odpovedi[0];
            button2.Text = "B) " + odpovedi[1];
            button3.Text = "C) " + odpovedi[2];
            button4.Text = "D) " + odpovedi[3];
        }

        private Otazka ziskejOtazkuPodleStupne(int stupen)
        {
            List<Otazka> stupenOtazky = new List<Otazka>();

            foreach (Otazka otazka in otazky) {
                if (otazka.stupen == stupen)
                {
                    stupenOtazky.Add(otazka);
                }
            }

            if (stupenOtazky.Count > 0)
            {
                return aktualniOtazka = stupenOtazky[random.Next(stupenOtazky.Count)];
            }

            return null;
        }

        private void zkontrolujOdpoved(int odpovedId)
        {
            if (aktualniOtazka.spravnaOdpoved == odpovedId)
            {
                stupen += 1;
                //Console.WriteLine(+stupen);
                zobrazOtazku();
            }
            else
            {
                Console.WriteLine("Nespravna odpoved - " + odpovedId + "  - spravna " + aktualniOtazka.spravnaOdpoved);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            simpleSound.Play();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            zkontrolujOdpoved(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            zkontrolujOdpoved(1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            zkontrolujOdpoved(2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            zkontrolujOdpoved(3);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;  
            button2.Enabled = false;
        }

        private void panel3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
          private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*if (stupen == 0) {
                panel1.BackgroundImage = photoList.Images[0];
            }
            if (stupen == 1)
            {
                panel1.BackgroundImage = photoList.Images[1];
            }
            if (stupen == 2)
            {
                panel1.BackgroundImage = photoList.Images[2];
            }
            if (stupen == 3)
            {
                panel1.BackgroundImage = photoList.Images[3];
            }
            if (stupen == 4)
            {
                panel1.BackgroundImage = photoList.Images[4];
            }
            if (stupen == 5)
            {
                panel1.BackgroundImage = photoList.Images[5];
            }
            if (stupen == 6)
            {
                panel1.BackgroundImage = photoList.Images[6];
            }
            if (stupen == 7)
            {
                panel1.BackgroundImage = photoList.Images[7];
            }
            if (stupen == 8)
            {
                panel1.BackgroundImage = photoList.Images[8];
            }
            if (stupen == 9)
            {
                panel1.BackgroundImage = photoList.Images[9];
            }
            if (stupen == 10)
            {
                panel1.BackgroundImage = photoList.Images[10];
                MessageBox.Show("Vyhrál jsi 1000 kč.");
            }*/

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = photoList.Images[0];
            /*if (stupen == 0) {
                pictureBox1.BackgroundImage = photoList.Images[0];
            }
            if (stupen == 1)
            {
                pictureBox1.BackgroundImage = photoList.Images[1];
            }
            if (stupen == 2)
            {
                pictureBox1.BackgroundImage = photoList.Images[2];
            }
            if (stupen == 3)
            {
                pictureBox1.BackgroundImage = photoList.Images[3];
            }
            if (stupen == 4)
            {
                pictureBox1.BackgroundImage = photoList.Images[4];
            }
            if (stupen == 5)
            {
                pictureBox1.BackgroundImage = photoList.Images[5];
            }
            if (stupen == 6)
            {
                pictureBox1.BackgroundImage = photoList.Images[6];
            }
            if (stupen == 7)
            {
                pictureBox1.BackgroundImage = photoList.Images[7];
            }
            if (stupen == 8)
            {
                pictureBox1.BackgroundImage = photoList.Images[8];
            }
            if (stupen == 9)
            {
                pictureBox1.BackgroundImage = photoList.Images[9];
            }
            if (stupen == 10)
            {
                pictureBox1.BackgroundImage = photoList.Images[10];
                MessageBox.Show("Vyhrál jsi 1000 kč.");
            }
            
        }*/
    }
    }
}


    