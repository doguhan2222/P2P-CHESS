using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace _180316014_Doguhan_Ay_Player2
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Enabled = false;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerSayac--;
            Oyuncu2KalanZaman.Text = timerSayac.ToString();
            if (timerSayac == 0)
            {
                timer.Enabled = false;
                string stringData = "TIME" + "0";
                byte[] zamanMesaj = Encoding.ASCII.GetBytes(stringData);
                client.BeginSend(zamanMesaj, 0, zamanMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                DialogResult result1 = MessageBox.Show(" Player_2 Sure bitti", "Oyun Tamamlandı", MessageBoxButtons.OK);
                if (result1 == DialogResult.OK)
                {
                    this.Close();

                }


            }
        }
        int sayac = 0;
        int timerSayac = 180;
        PictureBox geciciBoxDegeri;
        PictureBox hedefBoxDegeri;
        String geciciBoxDegeriString;
        String hedefBoxDegeriString;
        private Socket client;
        private byte[] data = new byte[1024];
        private int size = 1024;


        private void Form1_Load(object sender, EventArgs se)
        {

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            devreDisi();
            mesajGonder.Enabled = false;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("NAME", 100);
            listView1.Columns.Add("MESSAGE", 220);

        }
        public void devreDisi()
        {
            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            A4.Enabled = false;
            A5.Enabled = false;
            A6.Enabled = false;
            A7.Enabled = false;
            A8.Enabled = false;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            B4.Enabled = false;
            B5.Enabled = false;
            B6.Enabled = false;
            B7.Enabled = false;
            B8.Enabled = false;
            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;
            C4.Enabled = false;
            C5.Enabled = false;
            C6.Enabled = false;
            C7.Enabled = false;
            C8.Enabled = false;
            D1.Enabled = false;
            D2.Enabled = false;
            D3.Enabled = false;
            D4.Enabled = false;
            D5.Enabled = false;
            D6.Enabled = false;
            D7.Enabled = false;
            D8.Enabled = false;
            E1.Enabled = false;
            E2.Enabled = false;
            E3.Enabled = false;
            E4.Enabled = false;
            E5.Enabled = false;
            E6.Enabled = false;
            E7.Enabled = false;
            E8.Enabled = false;
            F1.Enabled = false;
            F2.Enabled = false;
            F3.Enabled = false;
            F4.Enabled = false;
            F5.Enabled = false;
            F6.Enabled = false;
            F7.Enabled = false;
            F8.Enabled = false;
            G1.Enabled = false;
            G2.Enabled = false;
            G3.Enabled = false;
            G4.Enabled = false;
            G5.Enabled = false;
            G6.Enabled = false;
            G7.Enabled = false;
            G8.Enabled = false;
            H1.Enabled = false;
            H2.Enabled = false;
            H3.Enabled = false;
            H4.Enabled = false;
            H5.Enabled = false;
            H6.Enabled = false;
            H7.Enabled = false;
            H8.Enabled = false;

        }
        public void aktiflestir()
        {
            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            A4.Enabled = true;
            A5.Enabled = true;
            A6.Enabled = true;
            A7.Enabled = true;
            A8.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            B4.Enabled = true;
            B5.Enabled = true;
            B6.Enabled = true;
            B7.Enabled = true;
            B8.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;
            C4.Enabled = true;
            C5.Enabled = true;
            C6.Enabled = true;
            C7.Enabled = true;
            C8.Enabled = true;
            D1.Enabled = true;
            D2.Enabled = true;
            D3.Enabled = true;
            D4.Enabled = true;
            D5.Enabled = true;
            D6.Enabled = true;
            D7.Enabled = true;
            D8.Enabled = true;
            E1.Enabled = true;
            E2.Enabled = true;
            E3.Enabled = true;
            E4.Enabled = true;
            E5.Enabled = true;
            E6.Enabled = true;
            E7.Enabled = true;
            E8.Enabled = true;
            F1.Enabled = true;
            F2.Enabled = true;
            F3.Enabled = true;
            F4.Enabled = true;
            F5.Enabled = true;
            F6.Enabled = true;
            F7.Enabled = true;
            F8.Enabled = true;
            G1.Enabled = true;
            G2.Enabled = true;
            G3.Enabled = true;
            G4.Enabled = true;
            G5.Enabled = true;
            G6.Enabled = true;
            G7.Enabled = true;
            G8.Enabled = true;
            H1.Enabled = true;
            H2.Enabled = true;
            H3.Enabled = true;
            H4.Enabled = true;
            H5.Enabled = true;
            H6.Enabled = true;
            H7.Enabled = true;
            H8.Enabled = true;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            socketOlustur();
        }
        public void socketOlustur()
        {
            label8.Text = "Connecting...";
            Socket newsock = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);
        }
        void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                label8.Text = "Connected to: " + client.RemoteEndPoint.ToString();
                label3.Text = "Game and Player_1 time started.";
                client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
                button1.Enabled = false;
                mesajGonder.Enabled = true;


            }
            catch (SocketException)
            {
                label8.Text = "Error connecting";
            }
        }

        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            if (stringData.Substring(0, 2).Equals("PM"))
            {
                String gonderenIsmi = stringData.Substring(2, 8);
                String gelenMesaj2 = stringData.Substring(10);

                string[] row = { gonderenIsmi, gelenMesaj2 };
                var satir = new ListViewItem(row);
                listView1.Items.Add(satir);
                remote.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
            }
            else if (stringData.Substring(0, 4).Equals("TIME"))
            {
                String rakipSuresiBitti = stringData.Substring(4);
                Oyuncu2KalanZaman.Text = rakipSuresiBitti;
                DialogResult result1 = MessageBox.Show(" Player_1 Sure bitti", "Oyun Tamamlandı", MessageBoxButtons.OK);
                if (result1 == DialogResult.OK)
                {
                    this.Close();

                }

            }
            else if (stringData.Substring(0, 6).Equals("SAHMAT"))
            {
                String bir = stringData.Substring(6, 2);
                String iki = stringData.Substring(8, 2);
                String rakibinZamani = stringData.Substring(10);
                Oyuncu1KalanZaman.Text = rakibinZamani;


                switch (bir)
                {
                    case "A1":
                        //geciciBoxDegeri = A8;
                        geciciBoxDegeri = H8;
                        label1.Text = "A1";
                        break;
                    case "A2":
                        geciciBoxDegeri = H7;
                        label1.Text = "A2";
                        break;
                    case "A3":
                        geciciBoxDegeri = H6;
                        label1.Text = "A3";
                        break;
                    case "A4":
                        geciciBoxDegeri = H5;
                        label1.Text = "A4";
                        break;
                    case "A5":
                        geciciBoxDegeri = H4;
                        label1.Text = "A5";
                        break;
                    case "A6":
                        geciciBoxDegeri = H3;
                        label1.Text = "A6";
                        break;
                    // harfleri değiştir
                    case "A7":
                        geciciBoxDegeri = H2;
                        label1.Text = "A7";
                        break;
                    case "A8":
                        geciciBoxDegeri = H1;
                        label1.Text = "A8";
                        break;
                    case "B1":
                        geciciBoxDegeri = G8;
                        label1.Text = "B1";
                        break;
                    case "B2":
                        geciciBoxDegeri = G7;
                        label1.Text = "B2";
                        break;
                    case "B3":
                        geciciBoxDegeri = G6;
                        label1.Text = "B3";
                        break;
                    case "B4":
                        geciciBoxDegeri = G5;
                        label1.Text = "B4";
                        break;
                    case "B5":
                        geciciBoxDegeri = G4;
                        label1.Text = "B5";
                        break;
                    case "B6":
                        geciciBoxDegeri = G3;
                        label1.Text = "B6";
                        break;
                    case "B7":
                        geciciBoxDegeri = G2;
                        label1.Text = "B7";
                        break;
                    case "B8":
                        geciciBoxDegeri = G1;
                        label1.Text = "B8";
                        break;
                    case "C1":
                        geciciBoxDegeri = F8;
                        label1.Text = "C1";
                        break;
                    case "C2":
                        geciciBoxDegeri = F7;
                        label1.Text = "C2";
                        break;
                    case "C3":
                        geciciBoxDegeri = F6;
                        label1.Text = "C3";
                        break;
                    case "C4":
                        geciciBoxDegeri = F5;
                        label1.Text = "C4";
                        break;
                    case "C5":
                        geciciBoxDegeri = F4;
                        label1.Text = "C5";
                        break;
                    case "C6":
                        geciciBoxDegeri = F3;
                        label1.Text = "C6";
                        break;
                    case "C7":
                        geciciBoxDegeri = F2;
                        label1.Text = "C7";
                        break;
                    case "C8":
                        geciciBoxDegeri = F1;
                        label1.Text = "C8";
                        break;
                    case "D1":
                        geciciBoxDegeri = E8;
                        label1.Text = "D1";
                        break;
                    case "D2":
                        geciciBoxDegeri = E7;
                        label1.Text = "D2";
                        break;
                    case "D3":
                        geciciBoxDegeri = E6;
                        label1.Text = "D3";
                        break;
                    case "D4":
                        geciciBoxDegeri = E5;
                        label1.Text = "D4";
                        break;
                    case "D5":
                        geciciBoxDegeri = E4;
                        label1.Text = "D5";
                        break;
                    case "D6":
                        geciciBoxDegeri = E3;
                        label1.Text = "D6";
                        break;
                    case "D7":
                        geciciBoxDegeri = E2;
                        label1.Text = "D7";
                        break;
                    case "D8":
                        geciciBoxDegeri = E1;
                        label1.Text = "D8";
                        break;
                    case "E1":
                        geciciBoxDegeri = D8;
                        label1.Text = "E1";
                        break;
                    case "E2":
                        geciciBoxDegeri = D7;
                        label1.Text = "E2";
                        break;
                    case "E3":
                        geciciBoxDegeri = D6;
                        label1.Text = "E3";
                        break;
                    case "E4":
                        geciciBoxDegeri = D5;
                        label1.Text = "E4";
                        break;
                    case "E5":
                        geciciBoxDegeri = D4;
                        label1.Text = "E5";
                        break;
                    case "E6":
                        geciciBoxDegeri = D3;
                        label1.Text = "E6";
                        break;
                    case "E7":
                        geciciBoxDegeri = D2;
                        label1.Text = "E7";
                        break;
                    case "E8":
                        geciciBoxDegeri = D1;
                        label1.Text = "E8";
                        break;
                    case "F1":
                        geciciBoxDegeri = C8;
                        label1.Text = "F1";
                        break;
                    case "F2":
                        geciciBoxDegeri = C7;
                        label1.Text = "F2";
                        break;
                    case "F3":
                        geciciBoxDegeri = C6;
                        label1.Text = "F3";
                        break;
                    case "F4":
                        geciciBoxDegeri = C5;
                        label1.Text = "F4";
                        break;
                    case "F5":
                        geciciBoxDegeri = C4;
                        label1.Text = "F5";
                        break;
                    case "F6":
                        geciciBoxDegeri = C3;
                        label1.Text = "F6";
                        break;
                    case "F7":
                        geciciBoxDegeri = C2;
                        label1.Text = "F7";
                        break;
                    case "F8":
                        geciciBoxDegeri = C1;
                        label1.Text = "F8";
                        break;
                    case "G1":
                        geciciBoxDegeri = B8;
                        label1.Text = "G1";
                        break;
                    case "G2":
                        geciciBoxDegeri = B7;
                        label1.Text = "G2";
                        break;
                    case "G3":
                        geciciBoxDegeri = B6;
                        label1.Text = "G3";
                        break;
                    case "G4":
                        geciciBoxDegeri = B5;
                        label1.Text = "G4";
                        break;
                    case "G5":
                        geciciBoxDegeri = B4;
                        label1.Text = "G5";
                        break;
                    case "G6":
                        geciciBoxDegeri = B3;
                        label1.Text = "G6";
                        break;
                    case "G7":
                        geciciBoxDegeri = B2;
                        label1.Text = "G7";
                        break;
                    case "G8":
                        geciciBoxDegeri = B1;
                        label1.Text = "G8";
                        break;
                    case "H1":
                        geciciBoxDegeri = A8;
                        label1.Text = "H1";
                        break;
                    case "H2":
                        geciciBoxDegeri = A7;
                        label1.Text = "H2";
                        break;
                    case "H3":
                        geciciBoxDegeri = A6;
                        label1.Text = "H3";
                        break;
                    case "H4":
                        geciciBoxDegeri = A5;
                        label1.Text = "H4";
                        break;
                    case "H5":
                        geciciBoxDegeri = A4;
                        label1.Text = "H5";
                        break;
                    case "H6":
                        geciciBoxDegeri = A3;
                        label1.Text = "H6";
                        break;
                    case "H7":
                        geciciBoxDegeri = A2;
                        label1.Text = "H7";
                        break;
                    case "H8":
                        geciciBoxDegeri = A1;
                        label1.Text = "H8";
                        break;
                }

                switch (iki)
                {
                    case "A1":
                        hedefBoxDegeri = H8;
                        label2.Text = "A1";
                        break;
                    case "A2":
                        hedefBoxDegeri = H7;
                        label2.Text = "A2";
                        break;
                    case "A3":
                        //hedefBoxDegeri = A6;
                        hedefBoxDegeri = H6;
                        label2.Text = "A3";
                        break;
                    case "A4":
                        hedefBoxDegeri = H5;
                        label2.Text = "A4";
                        break;
                    case "A5":
                        hedefBoxDegeri = H4;
                        label2.Text = "A5";
                        break;
                    case "A6":
                        hedefBoxDegeri = H3;
                        label2.Text = "A6";
                        break;
                    case "A7":
                        hedefBoxDegeri = H2;
                        label2.Text = "A7";
                        break;
                    case "A8":
                        hedefBoxDegeri = H1;
                        label2.Text = "A8";
                        break;
                    case "B1":
                        hedefBoxDegeri = G8;
                        label2.Text = "B1";
                        break;
                    case "B2":
                        hedefBoxDegeri = G7;
                        label2.Text = "B2";
                        break;
                    case "B3":
                        hedefBoxDegeri = G6;
                        label2.Text = "B3";
                        break;
                    case "B4":
                        hedefBoxDegeri = G5;
                        label2.Text = "B4";
                        break;
                    case "B5":
                        hedefBoxDegeri = G4;
                        label2.Text = "B5";
                        break;
                    case "B6":
                        hedefBoxDegeri = G3;
                        label2.Text = "B6";
                        break;
                    case "B7":
                        hedefBoxDegeri = G2;
                        label2.Text = "B7";
                        break;
                    case "B8":
                        hedefBoxDegeri = G1;
                        label2.Text = "B8";
                        break;
                    case "C1":
                        hedefBoxDegeri = F8;
                        label2.Text = "C1";
                        break;
                    case "C2":
                        hedefBoxDegeri = F7;
                        label2.Text = "C2";
                        break;
                    case "C3":
                        hedefBoxDegeri = F6;
                        label2.Text = "C3";
                        break;
                    case "C4":
                        hedefBoxDegeri = F5;
                        label2.Text = "C4";
                        break;
                    case "C5":
                        hedefBoxDegeri = F4;
                        label2.Text = "C5";
                        break;
                    case "C6":
                        hedefBoxDegeri = F3;
                        label2.Text = "C6";
                        break;
                    case "C7":
                        hedefBoxDegeri = F2;
                        label2.Text = "C7";
                        break;
                    case "C8":
                        hedefBoxDegeri = F1;
                        label2.Text = "C8";
                        break;
                    case "D1":
                        hedefBoxDegeri = E8;
                        label2.Text = "D1";
                        break;
                    case "D2":
                        hedefBoxDegeri = E7;
                        label2.Text = "D2";
                        break;
                    case "D3":
                        hedefBoxDegeri = E6;
                        label2.Text = "D3";
                        break;
                    case "D4":
                        hedefBoxDegeri = E5;
                        label2.Text = "D4";
                        break;
                    case "D5":
                        hedefBoxDegeri = E4;
                        label2.Text = "D5";
                        break;
                    case "D6":
                        hedefBoxDegeri = E3;
                        label2.Text = "D6";
                        break;
                    case "D7":
                        hedefBoxDegeri = E2;
                        label2.Text = "D7";
                        break;
                    case "D8":
                        hedefBoxDegeri = E1;
                        label2.Text = "D8";
                        break;
                    case "E1":
                        hedefBoxDegeri = D8;
                        label2.Text = "E1";
                        break;
                    case "E2":
                        hedefBoxDegeri = D7;
                        label2.Text = "E2";
                        break;
                    case "E3":
                        hedefBoxDegeri = D6;
                        label2.Text = "E3";
                        break;
                    case "E4":
                        hedefBoxDegeri = D5;
                        label2.Text = "E4";
                        break;
                    case "E5":
                        hedefBoxDegeri = D4;
                        label2.Text = "E5";
                        break;
                    case "E6":
                        hedefBoxDegeri = D3;
                        label2.Text = "E6";
                        break;
                    case "E7":
                        hedefBoxDegeri = D2;
                        label2.Text = "E7";
                        break;
                    case "E8":
                        hedefBoxDegeri = D1;
                        label2.Text = "E8";
                        break;
                    case "F1":
                        hedefBoxDegeri = C8;
                        label2.Text = "F1";
                        break;
                    case "F2":
                        hedefBoxDegeri = C7;
                        label2.Text = "F2";
                        break;
                    case "F3":
                        hedefBoxDegeri = C6;
                        label2.Text = "F3";
                        break;
                    case "F4":
                        hedefBoxDegeri = C5;
                        label2.Text = "F4";
                        break;
                    case "F5":
                        hedefBoxDegeri = C4;
                        label2.Text = "F5";
                        break;
                    case "F6":
                        hedefBoxDegeri = C3;
                        label2.Text = "F6";
                        break;
                    case "F7":
                        hedefBoxDegeri = C2;
                        label2.Text = "F7";
                        break;
                    case "F8":
                        hedefBoxDegeri = C1;
                        label2.Text = "F8";
                        break;
                    case "G1":
                        hedefBoxDegeri = B8;
                        label2.Text = "G1";
                        break;
                    case "G2":
                        hedefBoxDegeri = B7;
                        label2.Text = "G2";
                        break;
                    case "G3":
                        hedefBoxDegeri = B6;
                        label2.Text = "G3";
                        break;
                    case "G4":
                        hedefBoxDegeri = B5;
                        label2.Text = "G4";
                        break;
                    case "G5":
                        hedefBoxDegeri = B4;
                        label2.Text = "G5";
                        break;
                    case "G6":
                        hedefBoxDegeri = B3;
                        label2.Text = "G6";
                        break;
                    case "G7":
                        hedefBoxDegeri = B2;
                        label2.Text = "G7";
                        break;
                    case "G8":
                        hedefBoxDegeri = B1;
                        label2.Text = "G8";
                        break;
                    case "H1":
                        hedefBoxDegeri = A8;
                        label2.Text = "H1";
                        break;
                    case "H2":
                        hedefBoxDegeri = A7;
                        label2.Text = "H2";
                        break;
                    case "H3":
                        hedefBoxDegeri = A6;
                        label2.Text = "H3";
                        break;
                    case "H4":
                        hedefBoxDegeri = A5;
                        label2.Text = "H4";
                        break;
                    case "H5":
                        hedefBoxDegeri = A4;
                        label2.Text = "H5";
                        break;
                    case "H6":
                        hedefBoxDegeri = A3;
                        label2.Text = "H6";
                        break;
                    case "H7":
                        hedefBoxDegeri = A2;
                        label2.Text = "H7";
                        break;
                    case "H8":
                        hedefBoxDegeri = A1;
                        label2.Text = "H8";
                        break;
                }

                hedefBoxDegeri.Image = geciciBoxDegeri.Image;
                geciciBoxDegeri.Image = null;


                DialogResult result1 = MessageBox.Show(" Player_1 Oyunu kazandı", "ŞAH MAT KAYBETTİN", MessageBoxButtons.OK);
                if (result1 == DialogResult.OK)
                {
                    this.Close();

                }
            }
            else
            {
                String bir = stringData.Substring(0, 2);
                String iki = stringData.Substring(2, 2);
                String rakibinZamani = stringData.Substring(4);
                Oyuncu1KalanZaman.Text = rakibinZamani;

                switch (bir)
                {
                    case "A1":
                        geciciBoxDegeri = H8;
                        label1.Text = "A1";
                        break;
                    case "A2":
                        geciciBoxDegeri = H7;
                        label1.Text = "A2";
                        break;
                    case "A3":
                        geciciBoxDegeri = H6;
                        label1.Text = "A3";
                        break;
                    case "A4":
                        geciciBoxDegeri = H5;
                        label1.Text = "A4";
                        break;
                    case "A5":
                        geciciBoxDegeri = H4;
                        label1.Text = "A5";
                        break;
                    case "A6":
                        geciciBoxDegeri = H3;
                        label1.Text = "A6";
                        break;
                    case "A7":
                        geciciBoxDegeri = H2;
                        label1.Text = "A7";
                        break;
                    case "A8":
                        geciciBoxDegeri = H1;
                        label1.Text = "A8";
                        break;
                    case "B1":
                        geciciBoxDegeri = G8;
                        label1.Text = "B1";
                        break;
                    case "B2":
                        geciciBoxDegeri = G7;
                        label1.Text = "B2";
                        break;
                    case "B3":
                        geciciBoxDegeri = G6;
                        label1.Text = "B3";
                        break;
                    case "B4":
                        geciciBoxDegeri = G5;
                        label1.Text = "B4";
                        break;
                    case "B5":
                        geciciBoxDegeri = G4;
                        label1.Text = "B5";
                        break;
                    case "B6":
                        geciciBoxDegeri = G3;
                        label1.Text = "B6";
                        break;
                    case "B7":
                        geciciBoxDegeri = G2;
                        label1.Text = "B7";
                        break;
                    case "B8":
                        geciciBoxDegeri = G1;
                        label1.Text = "B8";
                        break;
                    case "C1":
                        geciciBoxDegeri = F8;
                        label1.Text = "C1";
                        break;
                    case "C2":
                        geciciBoxDegeri = F7;
                        label1.Text = "C2";
                        break;
                    case "C3":
                        geciciBoxDegeri = F6;
                        label1.Text = "C3";
                        break;
                    case "C4":
                        geciciBoxDegeri = F5;
                        label1.Text = "C4";
                        break;
                    case "C5":
                        geciciBoxDegeri = F4;
                        label1.Text = "C5";
                        break;
                    case "C6":
                        geciciBoxDegeri = F3;
                        label1.Text = "C6";
                        break;
                    case "C7":
                        geciciBoxDegeri = F2;
                        label1.Text = "C7";
                        break;
                    case "C8":
                        geciciBoxDegeri = F1;
                        label1.Text = "C8";
                        break;
                    case "D1":
                        geciciBoxDegeri = E8;
                        label1.Text = "D1";
                        break;
                    case "D2":
                        geciciBoxDegeri = E7;
                        label1.Text = "D2";
                        break;
                    case "D3":
                        geciciBoxDegeri = E6;
                        label1.Text = "D3";
                        break;
                    case "D4":
                        geciciBoxDegeri = E5;
                        label1.Text = "D4";
                        break;
                    case "D5":
                        geciciBoxDegeri = E4;
                        label1.Text = "D5";
                        break;
                    case "D6":
                        geciciBoxDegeri = E3;
                        label1.Text = "D6";
                        break;
                    case "D7":
                        geciciBoxDegeri = E2;
                        label1.Text = "D7";
                        break;
                    case "D8":
                        geciciBoxDegeri = E1;
                        label1.Text = "D8";
                        break;
                    case "E1":
                        geciciBoxDegeri = D8;
                        label1.Text = "E1";
                        break;
                    case "E2":
                        geciciBoxDegeri = D7;
                        label1.Text = "E2";
                        break;
                    case "E3":
                        geciciBoxDegeri = D6;
                        label1.Text = "E3";
                        break;
                    case "E4":
                        geciciBoxDegeri = D5;
                        label1.Text = "E4";
                        break;
                    case "E5":
                        geciciBoxDegeri = D4;
                        label1.Text = "E5";
                        break;
                    case "E6":
                        geciciBoxDegeri = D3;
                        label1.Text = "E6";
                        break;
                    case "E7":
                        geciciBoxDegeri = D2;
                        label1.Text = "E7";
                        break;
                    case "E8":
                        geciciBoxDegeri = D1;
                        label1.Text = "E8";
                        break;
                    case "F1":
                        geciciBoxDegeri = C8;
                        label1.Text = "F1";
                        break;
                    case "F2":
                        geciciBoxDegeri = C7;
                        label1.Text = "F2";
                        break;
                    case "F3":
                        geciciBoxDegeri = C6;
                        label1.Text = "F3";
                        break;
                    case "F4":
                        geciciBoxDegeri = C5;
                        label1.Text = "F4";
                        break;
                    case "F5":
                        geciciBoxDegeri = C4;
                        label1.Text = "F5";
                        break;
                    case "F6":
                        geciciBoxDegeri = C3;
                        label1.Text = "F6";
                        break;
                    case "F7":
                        geciciBoxDegeri = C2;
                        label1.Text = "F7";
                        break;
                    case "F8":
                        geciciBoxDegeri = C1;
                        label1.Text = "F8";
                        break;
                    case "G1":
                        geciciBoxDegeri = B8;
                        label1.Text = "G1";
                        break;
                    case "G2":
                        geciciBoxDegeri = B7;
                        label1.Text = "G2";
                        break;
                    case "G3":
                        geciciBoxDegeri = B6;
                        label1.Text = "G3";
                        break;
                    case "G4":
                        geciciBoxDegeri = B5;
                        label1.Text = "G4";
                        break;
                    case "G5":
                        geciciBoxDegeri = B4;
                        label1.Text = "G5";
                        break;
                    case "G6":
                        geciciBoxDegeri = B3;
                        label1.Text = "G6";
                        break;
                    case "G7":
                        geciciBoxDegeri = B2;
                        label1.Text = "G7";
                        break;
                    case "G8":
                        geciciBoxDegeri = B1;
                        label1.Text = "G8";
                        break;
                    case "H1":
                        geciciBoxDegeri = A8;
                        label1.Text = "H1";
                        break;
                    case "H2":
                        geciciBoxDegeri = A7;
                        label1.Text = "H2";
                        break;
                    case "H3":
                        geciciBoxDegeri = A6;
                        label1.Text = "H3";
                        break;
                    case "H4":
                        geciciBoxDegeri = A5;
                        label1.Text = "H4";
                        break;
                    case "H5":
                        geciciBoxDegeri = A4;
                        label1.Text = "H5";
                        break;
                    case "H6":
                        geciciBoxDegeri = A3;
                        label1.Text = "H6";
                        break;
                    case "H7":
                        geciciBoxDegeri = A2;
                        label1.Text = "H7";
                        break;
                    case "H8":
                        geciciBoxDegeri = A1;
                        label1.Text = "H8";
                        break;
                }

                switch (iki)
                {
                    case "A1":
                        hedefBoxDegeri = H8;
                        label2.Text = "A1";
                        break;
                    case "A2":
                        hedefBoxDegeri = H7;
                        label2.Text = "A2";
                        break;
                    case "A3":
                        hedefBoxDegeri = H6;
                        label2.Text = "A3";
                        break;
                    case "A4":
                        hedefBoxDegeri = H5;
                        label2.Text = "A4";
                        break;
                    case "A5":
                        hedefBoxDegeri = H4;
                        label2.Text = "A5";
                        break;
                    case "A6":
                        hedefBoxDegeri = H3;
                        label2.Text = "A6";
                        break;
                    case "A7":
                        hedefBoxDegeri = H2;
                        label2.Text = "A7";
                        break;
                    case "A8":
                        hedefBoxDegeri = H1;
                        label2.Text = "A8";
                        break;
                    case "B1":
                        hedefBoxDegeri = G8;
                        label2.Text = "B1";
                        break;
                    case "B2":
                        hedefBoxDegeri = G7;
                        label2.Text = "B2";
                        break;
                    case "B3":
                        hedefBoxDegeri = G6;
                        label2.Text = "B3";
                        break;
                    case "B4":
                        hedefBoxDegeri = G5;
                        label2.Text = "B4";
                        break;
                    case "B5":
                        hedefBoxDegeri = G4;
                        label2.Text = "B5";
                        break;
                    case "B6":
                        hedefBoxDegeri = G3;
                        label2.Text = "B6";
                        break;
                    case "B7":
                        hedefBoxDegeri = G2;
                        label2.Text = "B7";
                        break;
                    case "B8":
                        hedefBoxDegeri = G1;
                        label2.Text = "B8";
                        break;
                    case "C1":
                        hedefBoxDegeri = F8;
                        label2.Text = "C1";
                        break;
                    case "C2":
                        hedefBoxDegeri = F7;
                        label2.Text = "C2";
                        break;
                    case "C3":
                        hedefBoxDegeri = F6;
                        label2.Text = "C3";
                        break;
                    case "C4":
                        hedefBoxDegeri = F5;
                        label2.Text = "C4";
                        break;
                    case "C5":
                        hedefBoxDegeri = F4;
                        label2.Text = "C5";
                        break;
                    case "C6":
                        hedefBoxDegeri = F3;
                        label2.Text = "C6";
                        break;
                    case "C7":
                        hedefBoxDegeri = F2;
                        label2.Text = "C7";
                        break;
                    case "C8":
                        hedefBoxDegeri = F1;
                        label2.Text = "C8";
                        break;
                    case "D1":
                        hedefBoxDegeri = E8;
                        label2.Text = "D1";
                        break;
                    case "D2":
                        hedefBoxDegeri = E7;
                        label2.Text = "D2";
                        break;
                    case "D3":
                        hedefBoxDegeri = E6;
                        label2.Text = "D3";
                        break;
                    case "D4":
                        hedefBoxDegeri = E5;
                        label2.Text = "D4";
                        break;
                    case "D5":
                        hedefBoxDegeri = E4;
                        label2.Text = "D5";
                        break;
                    case "D6":
                        hedefBoxDegeri = E3;
                        label2.Text = "D6";
                        break;
                    case "D7":
                        hedefBoxDegeri = E2;
                        label2.Text = "D7";
                        break;
                    case "D8":
                        hedefBoxDegeri = E1;
                        label2.Text = "D8";
                        break;
                    case "E1":
                        hedefBoxDegeri = D8;
                        label2.Text = "E1";
                        break;
                    case "E2":
                        hedefBoxDegeri = D7;
                        label2.Text = "E2";
                        break;
                    case "E3":
                        hedefBoxDegeri = D6;
                        label2.Text = "E3";
                        break;
                    case "E4":
                        hedefBoxDegeri = D5;
                        label2.Text = "E4";
                        break;
                    case "E5":
                        hedefBoxDegeri = D4;
                        label2.Text = "E5";
                        break;
                    case "E6":
                        hedefBoxDegeri = D3;
                        label2.Text = "E6";
                        break;
                    case "E7":
                        hedefBoxDegeri = D2;
                        label2.Text = "E7";
                        break;
                    case "E8":
                        hedefBoxDegeri = D1;
                        label2.Text = "E8";
                        break;
                    case "F1":
                        hedefBoxDegeri = C8;
                        label2.Text = "F1";
                        break;
                    case "F2":
                        hedefBoxDegeri = C7;
                        label2.Text = "F2";
                        break;
                    case "F3":
                        hedefBoxDegeri = C6;
                        label2.Text = "F3";
                        break;
                    case "F4":
                        hedefBoxDegeri = C5;
                        label2.Text = "F4";
                        break;
                    case "F5":
                        hedefBoxDegeri = C4;
                        label2.Text = "F5";
                        break;
                    case "F6":
                        hedefBoxDegeri = C3;
                        label2.Text = "F6";
                        break;
                    case "F7":
                        hedefBoxDegeri = C2;
                        label2.Text = "F7";
                        break;
                    case "F8":
                        hedefBoxDegeri = C1;
                        label2.Text = "F8";
                        break;
                    case "G1":
                        hedefBoxDegeri = B8;
                        label2.Text = "G1";
                        break;
                    case "G2":
                        hedefBoxDegeri = B7;
                        label2.Text = "G2";
                        break;
                    case "G3":
                        hedefBoxDegeri = B6;
                        label2.Text = "G3";
                        break;
                    case "G4":
                        hedefBoxDegeri = B5;
                        label2.Text = "G4";
                        break;
                    case "G5":
                        hedefBoxDegeri = B4;
                        label2.Text = "G5";
                        break;
                    case "G6":
                        hedefBoxDegeri = B3;
                        label2.Text = "G6";
                        break;
                    case "G7":
                        hedefBoxDegeri = B2;
                        label2.Text = "G7";
                        break;
                    case "G8":
                        hedefBoxDegeri = B1;
                        label2.Text = "G8";
                        break;
                    case "H1":
                        hedefBoxDegeri = A8;
                        label2.Text = "H1";
                        break;
                    case "H2":
                        hedefBoxDegeri = A7;
                        label2.Text = "H2";
                        break;
                    case "H3":
                        hedefBoxDegeri = A6;
                        label2.Text = "H3";
                        break;
                    case "H4":
                        hedefBoxDegeri = A5;
                        label2.Text = "H4";
                        break;
                    case "H5":
                        hedefBoxDegeri = A4;
                        label2.Text = "H5";
                        break;
                    case "H6":
                        hedefBoxDegeri = A3;
                        label2.Text = "H6";
                        break;
                    case "H7":
                        hedefBoxDegeri = A2;
                        label2.Text = "H7";
                        break;
                    case "H8":
                        hedefBoxDegeri = A1;
                        label2.Text = "H8";
                        break;
                }

                hedefBoxDegeri.Image = geciciBoxDegeri.Image;
                geciciBoxDegeri.Image = null;
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                timer.Start();
                aktiflestir();
                remote.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
            }



        }
        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
            remote.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), remote);

        }

        private void mesajGonder_Click(object sender, EventArgs e)
        {
            String stringData2 = "PM" + "PLAYER_2" + textBox1.Text;
            byte[] message = Encoding.ASCII.GetBytes(stringData2);
            string[] row = { "PLAYER_2", textBox1.Text };
            var satir = new ListViewItem(row);
            listView1.Items.Add(satir);
            textBox1.Text = "";
            client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
        }



        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }




        private void A1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A1";
                    geciciBoxDegeri = A1;
                    sayac++;
                }

            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A1";
                        A1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A1";
                        A1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }



                }

            }

        }

        private void B1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;

            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B1";
                    geciciBoxDegeri = B1;
                    sayac++;
                }




            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B1";
                        B1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B1";
                        B1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void C1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C1";
                    geciciBoxDegeri = C1;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C1";
                        C1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C1";
                        C1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void D1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D1";
                    geciciBoxDegeri = D1;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D1";
                        D1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D1";
                        D1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void E1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E1";
                    geciciBoxDegeri = E1;
                    sayac++;
                }



            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E1";
                        E1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E1";
                        E1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void F1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F1";
                    geciciBoxDegeri = F1;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F1";
                        F1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F1";
                        F1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void G1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G1";
                    geciciBoxDegeri = G1;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G1";
                        G1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G1";
                        G1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void H1_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H1.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H1";
                    geciciBoxDegeri = H1;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H1";
                        H1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H1";
                        H1.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void A2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A2";
                    geciciBoxDegeri = A2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A2";
                        A2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A2";
                        A2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void B2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B2";
                    geciciBoxDegeri = B2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B2";
                        B2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B2";
                        B2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void C2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C2";
                    geciciBoxDegeri = C2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C2";
                        C2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C2";
                        C2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void D2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D2";
                    geciciBoxDegeri = D2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D2";
                        D2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D2";
                        D2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }

            }

        }

        private void E2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E2";
                    geciciBoxDegeri = E2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E2";
                        E2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E2";
                        E2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void F2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F2";
                    geciciBoxDegeri = F2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F2";
                        F2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F2";
                        F2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void G2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G2";
                    geciciBoxDegeri = G2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G2";
                        G2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G2";
                        G2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void H2_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H2.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H2";
                    geciciBoxDegeri = H2;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H2";
                        H2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H2";
                        H2.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void A3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A3";
                    geciciBoxDegeri = A3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A3";
                        A3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A3";
                        A3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void B3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B3";
                    geciciBoxDegeri = B3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B3";
                        B3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B3";
                        B3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void C3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C3";
                    geciciBoxDegeri = C3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C3";
                        C3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C3";
                        C3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }


        }

        private void D3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D3";
                    geciciBoxDegeri = D3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D3";
                        D3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D3";
                        D3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void E3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E3";
                    geciciBoxDegeri = E3;
                    sayac++;
                }

            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E3";
                        E3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E3";
                        E3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void F3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F3";
                    geciciBoxDegeri = F3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F3";
                        F3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F3";
                        F3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void G3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G3";
                    geciciBoxDegeri = G3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G3";
                        G3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G3";
                        G3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void H3_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H3.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H3";
                    geciciBoxDegeri = H3;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H3";
                        H3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H3";
                        H3.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void A4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A4";
                    geciciBoxDegeri = A4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A4";
                        A4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A4";
                        A4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void B4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B4";
                    geciciBoxDegeri = B4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B4";
                        B4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B4";
                        B4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void C4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C4";
                    geciciBoxDegeri = C4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C4";
                        C4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C4";
                        C4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void D4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D4";
                    geciciBoxDegeri = D4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D4";
                        D4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D4";
                        D4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void E4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E4";
                    geciciBoxDegeri = E4;
                    sayac++;
                }

            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E4";
                        E4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E4";
                        E4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void F4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F4";
                    geciciBoxDegeri = F4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F4";
                        F4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F4";
                        F4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void G4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G4";
                    geciciBoxDegeri = G4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G4";
                        G4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G4";
                        G4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void H4_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H4.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H4";
                    geciciBoxDegeri = H4;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H4";
                        H4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H4";
                        H4.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void A5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A5";
                    geciciBoxDegeri = A5;
                    sayac++;
                }

            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A5";
                        A5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A5";
                        A5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void B5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B5";
                    geciciBoxDegeri = B5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B5";
                        B5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B5";
                        B5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void C5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C5";
                    geciciBoxDegeri = C5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C5";
                        C5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C5";
                        C5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void D5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D5";
                    geciciBoxDegeri = D5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D5";
                        D5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D5";
                        D5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void E5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E5";
                    geciciBoxDegeri = E5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E5";
                        E5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E5";
                        E5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void F5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F5";
                    geciciBoxDegeri = F5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F5";
                        F5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F5";
                        F5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void G5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G5";
                    geciciBoxDegeri = G5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G5";
                        G5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G5";
                        G5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }

            }
        }

        private void H5_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H5.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H5";
                    geciciBoxDegeri = H5;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H5";
                        H5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H5";
                        H5.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void A6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A6";
                    geciciBoxDegeri = A6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A6";
                        A6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A6";
                        A6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void B6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B6";
                    geciciBoxDegeri = B6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B6";
                        B6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B6";
                        B6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void C6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C6";
                    geciciBoxDegeri = C6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C6";
                        C6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C6";
                        C6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void D6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D6";
                    geciciBoxDegeri = D6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D6";
                        D6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D6";
                        D6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void E6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E6";
                    geciciBoxDegeri = E6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E6";
                        E6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E6";
                        E6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void F6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F6";
                    geciciBoxDegeri = F6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F6";
                        F6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F6";
                        F6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void G6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G6";
                    geciciBoxDegeri = G6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G6";
                        G6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G6";
                        G6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void H6_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H6.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H6";
                    geciciBoxDegeri = H6;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H6";
                        H6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H6";
                        H6.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void A7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A7";
                    geciciBoxDegeri = A7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A7";
                        A7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A7";
                        A7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void B7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B7";
                    geciciBoxDegeri = B7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B7";
                        B7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B7";
                        B7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }

        }

        private void C7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C7";
                    geciciBoxDegeri = C7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C7";
                        C7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C7";
                        C7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void D7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D7";
                    geciciBoxDegeri = D7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D7";
                        D7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D7";
                        D7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void E7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E7";
                    geciciBoxDegeri = E7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E7";
                        E7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E7";
                        E7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void F7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F7";
                    geciciBoxDegeri = F7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F7";
                        F7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F7";
                        F7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void G7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G7";
                    geciciBoxDegeri = G7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G7";
                        G7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G7";
                        G7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void H7_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H7.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H7";
                    geciciBoxDegeri = H7;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H7";
                        H7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H7";
                        H7.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void A8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(A8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "A8";
                    geciciBoxDegeri = A8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "A8";
                        A8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "A8";
                        A8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void B8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(B8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "B8";
                    geciciBoxDegeri = B8;
                    sayac++;
                }

            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "B8";
                        B8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "B8";
                        B8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void C8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(C8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "C8";
                    geciciBoxDegeri = C8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "C8";
                        C8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "C8";
                        C8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void D8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(D8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "D8";
                    geciciBoxDegeri = D8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "D8";
                        D8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "D8";
                        D8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void E8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(E8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "E8";
                    geciciBoxDegeri = E8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "E8";
                        E8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "E8";
                        E8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void F8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(F8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "F8";
                    geciciBoxDegeri = F8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "F8";
                        F8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "F8";
                        F8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void G8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(G8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "G8";
                    geciciBoxDegeri = G8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "G8";
                        G8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "G8";
                        G8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }

        private void H8_Click(object sender, EventArgs e)
        {
            var array1 = converterDemo(Properties.Resources.piyonSiyah);
            var array2 = converterDemo(Properties.Resources.vezirSiyah);
            var array3 = converterDemo(Properties.Resources.sahSiyah);
            var array4 = converterDemo(Properties.Resources.kaleSiyah);
            var array5 = converterDemo(Properties.Resources.filSiyah);
            var array6 = converterDemo(Properties.Resources.atSiyah);
            var array = converterDemo(H8.Image);
            bool isSame1 = array.Length == array1.Length;
            bool isSame2 = array.Length == array2.Length;
            bool isSame3 = array.Length == array3.Length;
            bool isSame4 = array.Length == array4.Length;
            bool isSame5 = array.Length == array5.Length;
            bool isSame6 = array.Length == array6.Length;
            var array7 = converterDemo(Properties.Resources.sahBeyaz);
            bool isSame7 = array.Length == array7.Length;
            if (sayac == 0)
            {
                if (isSame1 || isSame2 || isSame3 || isSame4 || isSame5 || isSame6)
                {
                    geciciBoxDegeriString = "H8";
                    geciciBoxDegeri = H8;
                    sayac++;
                }


            }
            else if (sayac == 1)
            {
                if (isSame1 != true && isSame2 != true && isSame3 != true && isSame4 != true && isSame5 != true && isSame6 != true)
                {
                    if (isSame7 == true)
                    {
                        hedefBoxDegeriString = "H8";
                        H8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        timer.Stop();
                        devreDisi();
                        string sahData = "SAHMAT" + geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] sahMesaj = Encoding.ASCII.GetBytes(sahData);
                        client.BeginSend(sahMesaj, 0, sahMesaj.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        DialogResult result1 = MessageBox.Show(" Tebrikler kazandınız", "Oyun Tamamlandı. ŞAH MAT", MessageBoxButtons.OK);
                        if (result1 == DialogResult.OK)
                        {
                            this.Close();

                        }

                    }
                    else
                    {
                        hedefBoxDegeriString = "H8";
                        H8.Image = geciciBoxDegeri.Image;
                        geciciBoxDegeri.Image = null;
                        sayac = 0;
                        string stringData2 = geciciBoxDegeriString + hedefBoxDegeriString + timerSayac.ToString();
                        byte[] message = Encoding.ASCII.GetBytes(stringData2);
                        devreDisi();
                        checkBox1.Checked = true;
                        checkBox2.Checked = false;
                        timer.Stop();
                        client.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(SendData), client);
                        
                    }
                }


            }
        }




    }
}
