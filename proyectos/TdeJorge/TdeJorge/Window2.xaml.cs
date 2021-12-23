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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TdeJorge
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MainWindow padre;

        public Window2(MainWindow padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void clickEmpezar(object sender, RoutedEventArgs e)
        {
            padre.setNombre(this.txtJugador.Text);
            this.Close();
        }
    }
}
