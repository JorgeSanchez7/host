using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TdeJorge
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        double decremento = 1.0;
        private string nombreTamagochi;
        double score = 1.0;

        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer();
            t1.Interval += TimeSpan.FromMilliseconds(1000);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
            Window2 ventanaInicial = new Window2(this);
            ventanaInicial.ShowDialog();
           

        }
        private void reloj(object sender, EventArgs e)
        {
            this.pbAlimento.Value -= decremento;
            this.pbDiversion.Value -= decremento;
            this.pbEnergia.Value -= decremento;
            decremento += 0.1;
            score += 1.0;

            if (pbEnergia.Value <= 30.0 && pbEnergia.Value <= 35.0 )
            {
                NoDescansar();
            }

            if (pbDiversion.Value <= 30.0 && pbDiversion.Value <= 35.0)
            {
                NoJugar();               
            }
            if (pbAlimento.Value <= 30.0 && pbAlimento.Value <= 35.0)
            {
                NoComer();
            }



            if(score >= 15.0)
            {
                this.medalla.Visibility = Visibility.Visible;
                this.gafitas.Visibility = Visibility.Visible;
                this.gafitas2.Visibility = Visibility.Visible;

            }
            if (score >= 30.0)
            {
                this.trofeito.Visibility = Visibility.Visible;
                this.corbata.Visibility = Visibility.Visible;

            }
            if (score >= 40.0)
            {
                this.trofeo.Visibility = Visibility.Visible;
                this.pajarita.Visibility = Visibility.Visible;
            }

            


            if (pbAlimento.Value <= 0.0 || pbDiversion.Value <= 0.0 || pbEnergia.Value <= 0.0)
            {

                t1.Stop();
                this.txtScore.Text = "Score " + score;
                this.txtScore.Visibility = Visibility.Visible;
                this.lbGameOver.Visibility = Visibility.Visible;
                this.btAlimentar.IsEnabled = false;
                this.btDescansar.IsEnabled = false;
                this.btJugar.IsEnabled = false;

            }
        }

        private void btDescansar_Click(object sender, RoutedEventArgs e)
        {
            this.pbEnergia.Value += 20;
            Descansar();
        }

        private void btJugar_Click(object sender, RoutedEventArgs e)
        {
            this.pbDiversion.Value += 20;
            jugar();
        }

        private void btAlimentar_Click(object sender, RoutedEventArgs e)
        {
            this.pbAlimento.Value += 20;
            Comer();
        }

        private void Bambu1(object sender, MouseButtonEventArgs e)
        {
            this.Fondo.Source = ((Image)sender).Source;
        }

        private void fondo2(object sender, MouseButtonEventArgs e)
        {
            this.Fondo.Source = ((Image)sender).Source;
        }

        private void fondo3(object sender, MouseButtonEventArgs e)
        {
            this.Fondo.Source = ((Image)sender).Source;
        }

        private void fondo4(object sender, MouseButtonEventArgs e)
        {
            this.Fondo.Source = ((Image)sender).Source;
        }

        private void acercaDe(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Práctica realizada por:\nJorge Sánchez\n\n ¿Desea Salir?", "IPO2 Tamagotchi",
            MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        

    }
        private void jugar()
        {
            Storyboard sbJugar = (Storyboard)this.Resources["Jugar"];
            sbJugar.Completed += new EventHandler(finJugar);
            sbJugar.Begin();
            btJugar.IsEnabled = false;
            btAlimentar.IsEnabled = false;
            btDescansar.IsEnabled = false;
        }
        private void finJugar(object sender, EventArgs e)
        {
            btJugar.IsEnabled = true;
            btAlimentar.IsEnabled = true;
            btDescansar.IsEnabled = true;

        }
        private void Comer()
        {
            Storyboard sbComer = (Storyboard)this.Resources["Comer"];
            sbComer.Completed += new EventHandler(finComer);
            sbComer.Begin();
            btJugar.IsEnabled = false;
            btAlimentar.IsEnabled = false;
            btDescansar.IsEnabled = false;
        }
        private void finComer(object sender, EventArgs e)
        {
            btJugar.IsEnabled = true;
            btAlimentar.IsEnabled = true;
            btDescansar.IsEnabled = true;

        }
        private void Descansar()
        {
            Storyboard sbDescansar = (Storyboard)this.Resources["Descansar"];
            sbDescansar.Completed += new EventHandler(finDescansar);
            sbDescansar.Begin();
            btJugar.IsEnabled = false;
            btAlimentar.IsEnabled = false;
            btDescansar.IsEnabled = false;
        }
        private void finDescansar(object sender, EventArgs e)
        {
            btJugar.IsEnabled = true;
            btAlimentar.IsEnabled = true;
            btDescansar.IsEnabled = true;

        }
        private void NoJugar()
        {
            Storyboard sbNojugar = (Storyboard)this.Resources["Nojugar"];
            sbNojugar.Begin();
        }
        private void NoDescansar()
        {
            Storyboard sbNodescansar = (Storyboard)this.Resources["Nodescansar"];
            sbNodescansar.Begin();

        }
        private void NoComer()
        {
            Storyboard sbNocomer = (Storyboard)this.Resources["Nocomer"];
            sbNocomer.Begin();

        }
        public void setNombre(string nombre)
        {
            this.nombreTamagochi = nombre;
            
            
        }

        private void arrastrarGorro(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void soltar(object sender, DragEventArgs e)
        {
            Image aux = (Image)e.Data.GetData(typeof(Image));
            switch (aux.Name)
            {
                case "gorritochino":
                    gorroChino.Visibility = Visibility.Visible;
                    break;
                case "gorro":
                    Gorro.Visibility = Visibility.Visible;
                    break;
                case "gafitas":
                    Gafas.Visibility = Visibility.Visible;
                    break;
                case "gafitas2":
                    Gafas2.Visibility = Visibility.Visible;
                    break;
                case "corbata":
                    Corbata.Visibility = Visibility.Visible;
                    break;
                case "pajarita":
                    Pajarita.Visibility = Visibility.Visible;
                    break;

            }
        }

        private void arrastrarGafas(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void quitar1(object sender, MouseButtonEventArgs e)
        {
            gorroChino.Visibility = Visibility.Hidden;
          
        }

        private void quitar2(object sender, MouseButtonEventArgs e)
        {
            Gorro.Visibility = Visibility.Hidden;
        }

        private void quitar3(object sender, MouseButtonEventArgs e)
        {
            Gafas.Visibility = Visibility.Hidden;
        }

        private void quitar4(object sender, MouseButtonEventArgs e)
        {
            Gafas2.Visibility = Visibility.Hidden;
        }

        private void quitar5(object sender, MouseButtonEventArgs e)
        {
            Corbata.Visibility = Visibility.Hidden;
        }

        private void quitar6(object sender, MouseButtonEventArgs e)
        {
            Pajarita.Visibility = Visibility.Hidden;
        }
    }

}
