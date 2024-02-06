using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
	public class Order
	{
		[BindNever] // не будет отображаться на страничках
		public int id { get; set; } // айди заказа

		[StringLength(6)] // проверка на длину
		public string name { get; set; } // имя которое введет юзер
		[Required(ErrorMessage = "Enter your name")] // обязательное поле и сообщение которое выведеться если поле пустое


		[StringLength(20)]
		public string surname { get; set; } // фамилия
		[Required(ErrorMessage = "Enter your surname")] 

		[StringLength(20)]
		public string address { get; set; } // адрес
		[Required(ErrorMessage = "Enter your address")] 

		[StringLength(15)]
		[DataType(DataType.PhoneNumber)] // проверка типа данных на телефон
		public string phone { get; set; } // телефон
		[Required(ErrorMessage = "Enter your phone")] 

		[StringLength(35)]
		[DataType(DataType.EmailAddress)] // проверка типа данных на почту
		public string email { get; set; } // почта
		[Required(ErrorMessage = "Enter your email")]

		[BindNever] // не будет отображаться на страничках
		public DateTime orderTime { get; set; } // дата создания заказа

		// лист с типом OrderDetail - класс заказаного товара
		public List<OrderDetail> orderDetails { get; set; } // сипоск товаров которые будут в заказе
	}
}
