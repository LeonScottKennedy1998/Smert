using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Smert
{
    /// <summary>
    /// Логика взаимодействия для ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        private ZooAnimalHomeEntities zoo = new ZooAnimalHomeEntities();
        public ReviewPage()
        {
            InitializeComponent();
            ReviewGrid.ItemsSource = zoo.OrderReviews.ToList();
            OrderIdCB.ItemsSource = zoo.Orders.ToList();
            var customersWithOrders = zoo.Orders.Select(order => order.Customers).Distinct().ToList();
            CustIdCB.ItemsSource = customersWithOrders;
            OrderIdCB.SelectionChanged += OrderIdCB_SelectionChanged;

        }

        private void ReviewGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReviewGrid.SelectedItem != null)
            {
                var selectedReview = ReviewGrid.SelectedItem as OrderReviews;
                RatingTB.Text = selectedReview.rating.ToString();
                CommentTB.Text = selectedReview.comment;
                var position1 = zoo.Orders.FirstOrDefault(r => r.order_id == selectedReview.id_order);
                if (position1 != null)
                {
                    OrderIdCB.SelectedItem = position1;
                }

                var position2 = zoo.Customers.FirstOrDefault(r => r.customer_id == selectedReview.id_customer);
                if (position2 != null)
                {
                    CustIdCB.SelectedItem = position2;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RatingTB.Text) || string.IsNullOrWhiteSpace(CommentTB.Text) || OrderIdCB.SelectedItem == null || CustIdCB.SelectedItem == null)
            {
                MessageBox.Show("Ошибка: все поля должны быть заполнены.");
                return;
            }

            if (!Regex.IsMatch(CommentTB.Text, @"^[^\uD800-\uDFFF\uDC00-\uDFFF]+$"))
            {
                MessageBox.Show("Ошибка: комментарий не должен содержать смайликов.");
                return;
            }

            int rating;
            if (!int.TryParse(RatingTB.Text, out rating) || rating < 0 || rating > 5)
            {
                MessageBox.Show("Ошибка: рейтинг должен быть числом от 0 до 5.");
                return;
            }
            OrderReviews review = new OrderReviews();
            review.rating = int.Parse(RatingTB.Text);
            review.comment = CommentTB.Text;
            review.id_order = (OrderIdCB.SelectedItem as Orders)?.order_id ?? 0;
            review.id_customer = (CustIdCB.SelectedItem as Customers)?.customer_id ?? 0;

            zoo.OrderReviews.Add(review);

            zoo.SaveChanges();
            ReviewGrid.ItemsSource = zoo.OrderReviews.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewGrid.SelectedItem != null)
            { 
                var selectedReview = ReviewGrid.SelectedItem as OrderReviews;
                if (string.IsNullOrWhiteSpace(RatingTB.Text) || string.IsNullOrWhiteSpace(CommentTB.Text) || OrderIdCB.SelectedItem == null || CustIdCB.SelectedItem == null)
                {
                    MessageBox.Show("Ошибка: все поля должны быть заполнены.");
                    return;
                }

                if (!Regex.IsMatch(CommentTB.Text, @"^[^\uD800-\uDFFF\uDC00-\uDFFF]+$"))
                {
                    MessageBox.Show("Ошибка: комментарий не должен содержать смайликов.");
                    return;
                }

                int rating;
                if (!int.TryParse(RatingTB.Text, out rating) || rating < 0 || rating > 5)
                {
                    MessageBox.Show("Ошибка: рейтинг должен быть числом от 0 до 5.");
                    return;
                }
                selectedReview.rating = int.Parse(RatingTB.Text);
                selectedReview.comment = CommentTB.Text;
                selectedReview.id_order = (OrderIdCB.SelectedItem as Orders)?.order_id ?? 0;
                selectedReview.id_customer = (CustIdCB.SelectedItem as Customers)?.customer_id ?? 0;
                zoo.SaveChanges();
                ReviewGrid.ItemsSource = zoo.OrderReviews.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewGrid.SelectedItem != null)
            {
                zoo.OrderReviews.Remove(ReviewGrid.SelectedItem as OrderReviews);
                zoo.SaveChanges();
                ReviewGrid.ItemsSource = zoo.OrderReviews.ToList();
            }
        }

        private void OrderIdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderIdCB.SelectedItem != null)
            {
                var selectedPosition = OrderIdCB.SelectedItem as Orders;
                OrderIdCB.Text = selectedPosition.order_date.ToString();
                CustIdCB_SelectionChanged(null, null);

            }
        }

        private void CustIdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderIdCB.SelectedItem != null)
            {
                var selectedOrder = OrderIdCB.SelectedItem as Orders;
                var customersWithOrder = zoo.Customers.Where(c => c.Orders.Any(o => o.order_id == selectedOrder.order_id)).ToList();
                CustIdCB.ItemsSource = customersWithOrder;
                if (customersWithOrder.Count > 0)
                {
                    CustIdCB.SelectedItem = customersWithOrder.First();
                }
            }
        }
    }
}
