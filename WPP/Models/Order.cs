using WPP.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WPP.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {

        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        [DisplayName("Имя")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна")]
        [DisplayName("Фамилия")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Адрес обязателен")]
        [StringLength(70)]
        [DisplayName("Адрес")]
        public string Address { get; set; }

        [DisplayName("Город")]
        [Required(ErrorMessage = "Город обязателен")]
        [StringLength(40)]
        public string City { get; set; }

        [DisplayName("Область")]
        [Required(ErrorMessage = "Область обязательна")]
        [StringLength(40)]
        public string State { get; set; }

        [Required(ErrorMessage = "Почтовый индекс обязателен")]
        [DisplayName("Почтовый индекс")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [DisplayName("Страна")]
        [Required(ErrorMessage = "Страна обязательна")]
        [StringLength(40)]
        public string Country { get; set; }

        [DisplayName("Телефон")]
        [Required(ErrorMessage = "Телефон обязателен")]
        [StringLength(24)]
        public string Phone { get; set; }

        [Display(Name = "Срок действия карты")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Experation { get; set; }

        [Display(Name = "Номер карты")]
        [NotMapped]
        [DataType(DataType.CreditCard)]
        public String CreditCard { get; set; }

        [Display(Name = "Тип карты")]
        [NotMapped]
        public String CcType { get; set; }

        public bool SaveInfo { get; set; }


        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Status { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [Range(0, 10, ErrorMessage =  "Скидка должна быть не больше чем 10%")]
        [DefaultValue(0)]
        public int Discount { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

       

        public string ToString(Order order)
        {
            StringBuilder bob = new StringBuilder();

            bob.Append("<p>Информация о заказе: "+ order.OrderId +"<br>Дата заказа: " + order.OrderDate +"</p>").AppendLine();
            bob.Append("<p>Имя: " + order.FirstName + " " + order.LastName + "<br>");
            bob.Append("Адрес: " + order.Address + " " + order.City + " " + order.State + " " + order.PostalCode + "<br>");
            bob.Append("Контакты: " + order.Email + "     " + order.Phone + "</p>");
            bob.Append("<p>Оплата: " + order.CreditCard + " " + order.Experation.ToString("dd-MM-yyyy") + "</p>");
            bob.Append("<p>Тип карты: " + order.CcType + "</p>");

            bob.Append("<br>").AppendLine();
            bob.Append("<Table>").AppendLine();
            // Display header 
            string header = "<tr> <th>Модель</th>" + "<th>Количество</th>" + "<th>Цена</th> <th></th> </tr>";
            bob.Append(header).AppendLine();

            String output = String.Empty;
            try
            {
                foreach (var item in order.OrderDetails)
                {
                    bob.Append("<tr>");
                    output = "<td>" + item.Item.Name + "</td>" + "<td>" + item.Quantity + "</td>" + "<td>" + item.Quantity * item.UnitPrice + "</td>";
                    bob.Append(output).AppendLine();
                    Console.WriteLine(output);
                    bob.Append("</tr>");
                }
            }
            catch (Exception ex)
            {
                output = "Ничего не заказано";
            }
            bob.Append("</Table>");
            bob.Append("<b>");
            // Display footer 
            string footer = String.Format("{0,-12}{1,12}\n",
                                          "Всего", order.Total);
            bob.Append(footer).AppendLine();
            bob.Append("</b>");

            return bob.ToString();
        }
    }
}