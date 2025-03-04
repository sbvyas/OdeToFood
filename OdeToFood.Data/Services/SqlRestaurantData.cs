﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
	public class SqlRestaurantData : IRestaurantData
	{
		private OdeToFoodDbContext db;

		public SqlRestaurantData(OdeToFoodDbContext db)
		{
			this.db = db;
		}
		public void Add(Restaurant restaurant)
		{
			db.Restaurants.Add(restaurant);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			var restaurant = db.Restaurants.Find(id);
			db.Restaurants.Remove(restaurant);
			db.SaveChanges();
		}

		public Restaurant Get(int id)
		{
			return db.Restaurants.FirstOrDefault(r => r.Id == id);
		}

		public IEnumerable<Restaurant> GetAll()
		{
			return db.Restaurants;
			// return from r in db.Restaurants order r.Name select r;
		}

		public void Update(Restaurant restaurant)
		{
			//var r = Get(restaurant.Id);
			//r.Name = " ";
			var entry = db.Entry(restaurant);
			entry.State = EntityState.Modified;
			db.SaveChanges();
		}
	}
}
