using ECommerceLabb.Models;

namespace ECommerceLabb.Services
{
	public class CustomerStateService
	{
		public Customer? SelectedCustomer { get; private set; }

		public void SetSelectedCustomer(Customer customer)
		{
			SelectedCustomer = customer;
		}
	}
}
