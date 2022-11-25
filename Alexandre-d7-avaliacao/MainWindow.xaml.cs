using Alexandre_d7_avaliacao.Model;
using Alexandre_d7_avaliacao.Context;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alexandre_d7_avaliacao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        private readonly Context context;
        User newUser= new();

        public MainWindow(Context context)
        {
  
           this.context = context;
            InitializeComponent();
/*                GetProducts();
                NewProductGrid.DataContext = newProduct;
*/
        }

        private void GetProducts()
        {
  
/*                ProductDataGrid.ItemsSource = context.Products.ToList();
*/
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {

/*                context.Products.Add(newProduct);
                context.SaveChanges();

                GetProducts();

                newProduct = new Product();
                NewProductGrid.DataContext = newProduct;
*/
        }
    }
}
