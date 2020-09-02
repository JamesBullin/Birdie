using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BirdieModels;
using BirdieBusiness;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace NorthwindTests
{
	public class CRUDTests
	{
		CRUDOperations crud = new CRUDOperations();

		[SetUp]

		public void Setup()
		{
			using (var db = new BirdieContext())
			{
				var selectedCustomer =
								from c in db.Customers
								where c.CustomerId == "MAND"
								select c;


				foreach (var c in selectedCustomer)
				{
					db.Customers.Remove(c);
				}

				db.SaveChanges();

			}
		}

		[Test]
		public void CustomerAddedTest()
		{
			using (var db = new BirdieContext())
			{
				// Call the Create method
				crud.Create("MAND", "Nish Mandal", "SpartaGlobal");

				// .Single

				// Select Nish
				var selectedCustomer =
					from c in db.Customers
					where c.CustomerId == "MAND"
					select c;

				Assert.AreEqual(selectedCustomer.Count(), 1);

				Setup();

			}
		}

		[Test]
		public void CustomerAddedDetailsCorrectTest()
		{
			using (var db = new BirdieContext())
			{

				// Call the Create method
				crud.Create("MAND", "Nish Mandal", "SpartaGlobal");

				// Select Nish
				var selectedCustomer =
					from c in db.Customers
					where c.CustomerId == "MAND"
					select c;

				foreach (var c in selectedCustomer)
				{
					Assert.AreEqual("Nish Mandal", c.ContactName);
					Assert.AreEqual("SpartaGlobal", c.CompanyName);
				}

				Setup();

			}
		}

		[Test]
		public void UpdateTest()
		{
			using (var db = new BirdieContext())
			{

				var newCustomer = new Customers()
				{
					CustomerId = "MAND",
					ContactName = "Nish Mandal",
					CompanyName = "Sparta Global",
				};

				db.Customers.Add(newCustomer);

				db.SaveChanges();

				crud.Update("MAND", "Paris");

				var updatedCustomer =
							from c in db.Customers
							where c.CustomerId == "MAND"
							select c;

				foreach (var c in updatedCustomer)
				{
					Assert.AreEqual("Paris", c.City);
				}
				Setup();

			}
		}

		[Test]
		public void UpdateSeveralDetailsTest()
		{
			using (var db = new BirdieContext())
			{
				var newCustomer = new Customers()
				{
					CustomerId = "MAND",
					CompanyName = "Sparta Global",
					ContactName = "Nish Mandal",
					City = "Birmingham",
					PostalCode = "B12 3XY",
					Country = "UK",
				};

				db.Customers.Add(newCustomer);

				db.SaveChanges();

				crud.Update("MAND", "Nelson Mandela", "Soweto", "S12 3AB", "South Africa");

				var updatedCustomer =
							from c in db.Customers
							where c.CustomerId == "MAND"
							select c;

				foreach (var c in updatedCustomer)
				{
					Assert.AreEqual("Nelson Mandela", c.ContactName);
					Assert.AreEqual("Soweto", c.City);
					Assert.AreEqual("S12 3AB", c.PostalCode);
					Assert.AreEqual("South Africa", c.Country);
				}
				Setup();

			}
		}

		[Test]
		public void RemoveTest()
		{
			using (var db = new BirdieContext())
			{
				// Add Nish
				var newCustomer = new Customers()
				{
					CustomerId = "MAND",
					ContactName = "Nish Mandal",
					CompanyName = "Sparta Global",
				};

				db.Customers.Add(newCustomer);

				db.SaveChanges();

				//RemoveNish

				crud.Delete("MAND");

				var selectedCustomer =
					from c in db.Customers
					where c.CustomerId == "MAND"
					select c;

				Assert.AreEqual(selectedCustomer.Count(), 0);

				Setup();


			}
		}
	}
}
}