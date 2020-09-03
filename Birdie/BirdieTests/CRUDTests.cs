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

        }

		[Test]
		public void AddBallTest()
		{
			using (var db = new BirdieContext())
			{
				crud.AddBall("Test Ball", 1, 2, 450, 500, 600, 400);

				var query = db.Ball
					.Where(b => b.Name == "Test Ball");
				

				Assert.AreEqual(query.Count(), 1);
			}
		}

		[Test]
		public void BallAddedDetailsCorrectTest()
		{
			using (var db = new BirdieContext())
			{
				crud.AddBall("Test Ball", 1, 2, 450, 500, 600, 400);

				var ball = db.Ball
					.Where(b => b.Name == "Test Ball").Single();

				Assert.AreEqual("Test Ball", ball.Name);
				Assert.AreEqual(1, ball.ManufacturerId);
				Assert.AreEqual(2, ball.OfficialColourId);
				Assert.AreEqual(450, ball.BounceInMillimetres);
				Assert.AreEqual(500, ball.WeightInTenthsOfGram);
				Assert.AreEqual(600, ball.ShoreInTenthsOfDurometre);
				Assert.AreEqual(400, ball.SizeInMillimetres);
			}
		}

		[Test]
		public void AddManufacturerTest()
		{
			using (var db = new BirdieContext())
			{
				crud.AddManufacturer("Test Manufacturer");

				var query = db.Manufacturer
					.Where(m => m.Name == "Test Manufacturer");

				Assert.AreEqual(query.Count(), 1);
			}
		}

		[Test]
		public void AddOfficialColourTest()
		{
			using (var db = new BirdieContext())
			{
				var basicColour = db.BasicColour
					.Where(c => c.Name == "Red").Single();

				crud.AddOfficialColour("Test Colour", basicColour.Id);

				var query = db.OfficialColour
					.Where(oc => oc.Name == "Test Colour");

				Assert.AreEqual(query.Count(), 1);
			}
		}

		[Test]
		public void SelectAllBallsTest()
        {
			using (var db = new BirdieContext())
			{
				var balls = crud.SelectAllBalls();

				var query = db.Ball.ToList();

				Assert.AreEqual(query.Count(), balls.Count());
			}
		}

		[TearDown]
		public void TearDown()
		{
			using (var db = new BirdieContext())
			{
				var qRemoveBall = db.Ball
					.Where(b => b.Name == "Test Ball");
				foreach (var item in qRemoveBall)
				{
					db.Ball.Remove(item);
				}

				var qRemoveManufacturer = db.Manufacturer
					.Where(m => m.Name == "Test Manufacturer");
				foreach (var item in qRemoveManufacturer)
				{
					db.Manufacturer.Remove(item);
				}

				var qRemoveColour = db.OfficialColour
					.Where(oc => oc.Name == "Test Colour");
				foreach (var item in qRemoveColour)
				{
					db.OfficialColour.Remove(item);
				}

				db.SaveChanges();
			}
		}



		/*
		// Not Done

		[SetUp]
		public void SetupUpdateBall()
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

		[TearDown]
		public void TearDown()
        {

        }
		*/

		// Check if a ball is added with a new official colour, that the official colour is added to the database
		// Test to make sure you can't add a duplicate of a manufacturer, ball, or official colour
	}
}
