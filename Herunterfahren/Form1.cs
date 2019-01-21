using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


namespace Herunterfahren
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //label4.Text(System.Windows.Forms.Timer());
        }

  
        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-a");
            //herunterfahren Label leeren
            
            label5.Text = "";
            System.Media.SystemSounds.Beep.Play(); //Beep
            MessageBox.Show("OK, das Herunterfahren/neustarten wurde beendet");          
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //https://www.youtube.com/watch?v=CVhTlx3dW5E
            timer1.Start();
            label4.Text = "es ist momentan "+DateTime.Now.ToLongTimeString()+" Uhr";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //https://www.youtube.com/watch?v=CVhTlx3dW5E
            label4.Text = "es ist momentan " + DateTime.Now.ToLongTimeString() + " Uhr";
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Deklarierung + Umkonvertieren + Initalisieren
            string t_std = numericUpDown1.Value.ToString();
            string t_min = numericUpDown2.Value.ToString();
            int t_Std = int.Parse(t_std);
            int t_Min = int.Parse(t_min);
            int t = (t_Std * 60 * 60) + (t_Min * 60); //sekunden zusammenfassen
            int AbfrageMin = 0;
            int AbfrageStd = 0;
            int StdHöher = 0;

            if (t_Min > 60) //Abfangen wenn über 60min
            {
                System.Media.SystemSounds.Beep.Play(); //Beep
                StdHöher = t_Min / 60;
                AbfrageMin = (t_Min - 60) / StdHöher;
                AbfrageStd = (t_Std + StdHöher);


                MessageBox.Show("BEACHTE! 60min = 1 Std | "+t_min+" min = "+ AbfrageStd+" std "+AbfrageMin+" min ... Bitte nochmal eingeben!", "Fehler bei der Minuten Eingabe");
                numericUpDown2.Value = AbfrageMin;
                numericUpDown1.Value = AbfrageStd;
                return;
            }

            System.Media.SystemSounds.Beep.Play(); //Beep

            int sekunden = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second + t);
            //aktuelle zeit in sekunden + die eingegebene sekunden zeit!

            TimeSpan time = TimeSpan.FromSeconds(sekunden);
            label5.Text = "der PC fährt herunter um " + time.ToString(@"hh\:mm\:ss");

            //    label4.Text = t.ToString();
            //     MessageBox.Show(t); //schmeisse zum test eine MessageBox (nur strings!)


           
            //Deklarierung + Umkonvertieren + Initalisieren der Berechnung
            int t2 = (t_Std * 60 * 60) + (t_Min * 60); //sekunden 
           //Deklaration einer neuen Klasse für eine Abfrage Box mit Ja/NEIN
            DialogResult dialogResult = MessageBox.Show("Sind sie sicher?", "Wirklich?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //wennn ja
                //Deklarierung + Umkonvertieren + Initalisieren
                t2 = (t_Std * 60 * 60) + (t_Min * 60); //sekunden zusammenfassen

                //    label4.Text = t.ToString();
                //     MessageBox.Show(t); //schmeisse zum test eine MessageBox (nur strings!)

                System.Media.SystemSounds.Beep.Play(); //Beep

                System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-s -f -t " + t2);
            }
            else if (dialogResult == DialogResult.No)
            {
                //wenn nein
                label5.Text = "";
                //Setze die EingabeBoxen wieder auf 0
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //Keys.A definierrt Taste A
            {
                button4.PerformClick(); //-> Button betätigen
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
           //Wenn Enter, dann führe aus
            AcceptButton = button4;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Wenn Enter, dann führe aus
            AcceptButton = button4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Deklarierung + Umkonvertieren + Initalisieren
            string t_std = numericUpDown1.Value.ToString();
            string t_min = numericUpDown2.Value.ToString();
            int t_Std = int.Parse(t_std);
            int t_Min = int.Parse(t_min);
            int t = (t_Std * 60 * 60) + (t_Min * 60); //sekunden zusammenfassen
            int AbfrageMin = 0;
            int AbfrageStd = 0;
            int StdHöher = 0;

            if (t_Min > 60) //Abfangen wenn über 60min
            {
                System.Media.SystemSounds.Beep.Play(); //Beep
                StdHöher = t_Min / 60;
                AbfrageMin = (t_Min - 60) / StdHöher;
                AbfrageStd = (t_Std + StdHöher);


                MessageBox.Show("BEACHTE! 60min = 1 Std | " + t_min + " min = " + AbfrageStd + " std " + AbfrageMin + " min ... Bitte nochmal eingeben!", "Fehler bei der Minuten Eingabe");
                numericUpDown2.Value = AbfrageMin;
                numericUpDown1.Value = AbfrageStd;
                return;
            }

            System.Media.SystemSounds.Beep.Play(); //Beep

            int sekunden = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second + t);
            //aktuelle zeit in sekunden + die eingegebene sekunden zeit!

            TimeSpan time = TimeSpan.FromSeconds(sekunden);
            label5.Text = "der PC startet neu um " + time.ToString(@"hh\:mm\:ss");

            //    label4.Text = t.ToString();
            //     MessageBox.Show(t); //schmeisse zum test eine MessageBox (nur strings!)



            //Deklarierung + Umkonvertieren + Initalisieren der Berechnung
            int t2 = (t_Std * 60 * 60) + (t_Min * 60); //sekunden 
                                                       //Deklaration einer neuen Klasse für eine Abfrage Box mit Ja/NEIN
            DialogResult dialogResult = MessageBox.Show("Sind sie sicher?", "Wirklich?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //wennn ja
                //Deklarierung + Umkonvertieren + Initalisieren
                t2 = (t_Std * 60 * 60) + (t_Min * 60); //sekunden zusammenfassen

                //    label4.Text = t.ToString();
                //     MessageBox.Show(t); //schmeisse zum test eine MessageBox (nur strings!)

                System.Media.SystemSounds.Beep.Play(); //Beep

                System.Diagnostics.Process.Start(System.Environment.SystemDirectory + "\\shutdown.exe", "-r -f -t " + t2);
            }
            else if (dialogResult == DialogResult.No)
            {
                //wenn nein
                label5.Text = "";
                //Setze die EingabeBoxen wieder auf 0
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process(); // Process Class - Ermöglicht den Zugriff auf lokale Prozesse und Remoteprozesse und das Starten und Anhalten lokaler Systemprozesse.
            //erzeugt ein Object process mit der Methode Process
            //man braucht halt ein Objekt(das sich die eingestellten Eigenschaften merkt), um die Befehle ausführen zu können :)
            // process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //versteckt das cmd fenster und führt den Code im Hinterrgrund aus
            process.StartInfo.FileName = "cmd.exe"; //starten der cmd anwendung (Arbeitet mit den Windows Umgebungsvariablen
            // string cmd = "/C netstat -a"; // speichert das Kommando in eine Variable
            process.StartInfo.Arguments = "/C taskkill /f / IM explorer.exe start explorer.exe"; //man kann es direkt übergeben oder in einer string variable
            
            process.Start(); //starte die cmd
            
            
        }
    }
}
